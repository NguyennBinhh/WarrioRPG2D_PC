using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float speed = 1f; // Tốc độ của cầu lửa
    private Vector2 moveDirection ; // Hướng di chuyển của cầu lửa
    private Player_Controller Player_Controller;
    private Animator FireBall_Anim;

    [SerializeField] private GameObject Expolision_Range;

    void Start()
    {
        FireBall_Anim = GetComponent<Animator>();
        speed = 5f;
        Destroy(gameObject, 3f);
        Player_Controller = FindObjectOfType<Player_Controller>();
        moveDirection = Player_Controller.Move_Input;
    }

    void Update()
    {
        Pl_FireBall();
    }

    void RotateTowardsDirection(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Pl_FireBall()
    {
        if (moveDirection == Vector2.zero)
            moveDirection = new Vector2(0, 1);
        RotateTowardsDirection(moveDirection);
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            StartCoroutine(Expolision());
        }    
    }

    IEnumerator Expolision()
    {
        FireBall_Anim.SetTrigger("Expolision");
        Expolision_Range.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);  
    }
}
