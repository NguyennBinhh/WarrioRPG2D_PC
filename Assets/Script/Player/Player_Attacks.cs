
using System;
using System.Collections;
using UnityEngine;

public class Player_Attacks : MonoBehaviour
{
    [SerializeField] private GameObject Sword_Zone;
    [HideInInspector] public float Damage;
    [SerializeField] private GameObject Surfing_Range;
    [SerializeField] private GameObject Fireball_Prefab;
    [SerializeField] private Transform FB_Point;
    private Rigidbody2D Rb_Player;
    private Player_Controller Player_Controller;
    private bool IsDashing;

    private void Awake()
    {
        Rb_Player = GetComponent<Rigidbody2D>();
        Player_Controller = GetComponent<Player_Controller>();
        IsDashing = false;
    }
    public void Pl_ATKSword()
    {
        Sword_Zone.SetActive(true);
        Invoke("Disable_SWzone", 0.3f);
        
    }
    private void Update()
    {
        
    }

    public void Pl_SkillK(Vector2 Move_Direction)
    {
        Instantiate(Fireball_Prefab, FB_Point.position , Quaternion.identity);
    }    

    private void Disable_SWzone()
    {
        Sword_Zone.SetActive(false);
    } 
    
    public void Pl_SkillU(float hp)
    {
        Player_Controller.Hp_Player += hp;
    }   
    
    public void Pl_AtkL()
    {
        if (!IsDashing)
            StartCoroutine(Perform_Dash());
    }    

       
    private IEnumerator Perform_Dash()
    {
        IsDashing = true;
        Rb_Player.velocity = new Vector2(transform.localScale.x * 10f, 0);
        Surfing_Range.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        Rb_Player.velocity = Vector2.zero;
        Surfing_Range.SetActive(false);
        IsDashing = false;
    }    
}
