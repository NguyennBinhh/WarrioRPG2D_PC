using Pathfinding;
using System.Collections;
using System.Drawing.Text;
using Unity.VisualScripting;
using UnityEngine;
//using Pathfinding;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] private bool isLongATK;
    [SerializeField] private Seeker Seeker;
    private Transform Player;
    [SerializeField] public float Speed_Monter;
    [SerializeField] public float Next_DistancePoint;
    [SerializeField] public bool Update_Path;

    private Path Path;
    private bool Check_MoveEnd;
    private Coroutine Coroutine;



    private void Start()
    {
        InvokeRepeating("Path_Calculation", 0f, 0.5f);
        Check_MoveEnd = true;
        
        Player = GameObject.FindWithTag("Player").transform;
        if (Player == null)
            Destroy(gameObject);
    }
    private void Path_Calculation()
    {
        Vector2 Target_Point = Target_Pl();
        if(Seeker.IsDone() && (Check_MoveEnd || Update_Path))
            Seeker. StartPath(transform.position, Target_Point, OnPathCompl);  
    }  
    
    private void OnPathCompl(Path p)
    {
        if (p.error)
            return;
        Path = p;
        Monster_Movement();
    }    
    private Vector3 Target_Pl()
    {
        if (isLongATK)
        {
            return (Vector2)Player.position + (Random.Range(5f, 5f) * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized);
        }
        else
        {
            return Player.position;
        }
    }

    private void Monster_Movement()
    {
        if (Coroutine != null)
            StopCoroutine(Coroutine);
        Coroutine = StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        int a = 0;
        Check_MoveEnd = false;
        while (a < Path.vectorPath.Count)
        {
            Vector2 Direction = ((Vector2)Path.vectorPath[a] - (Vector2)transform.position).normalized;
            Vector3 Force = Direction * Speed_Monter * Time.deltaTime;
            transform.position += Force;
            float Distance = Vector2.Distance(transform.position, Path.vectorPath[a]);
            if (Distance < Next_DistancePoint)
                a++;
            if(Force.x < 0)
                transform.localScale = new Vector3(-1, 1, 1);
            else if(Force.x > 0)
                transform.localScale = new Vector3(1, 1, 1);
            yield return null;
        }

        Check_MoveEnd = false;
    }

}
