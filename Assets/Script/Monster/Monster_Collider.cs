using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Monster_Collider : MonoBehaviour
{
    private Transform Player;
    [SerializeField] private int Min_Dmg, Max_Dmg;
    private Player_Controller Player_Controller;
    [HideInInspector] public float Atk_FromPlayer;
    [HideInInspector] public bool Check_Takedame;

    private void Awake()
    {
        Player_Controller = FindObjectOfType<Player_Controller>();
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword"))
        {
            if (Player.transform.localScale.x == 1)
                transform.position += new Vector3(0.8f, 0, 0);
            else if (Player.transform.localScale.x == -1)
                transform.position += new Vector3(-0.8f, 0, 0);
            Atk_FromPlayer = Random.Range(30, 40);
            Check_Takedame = true;
        }
        if (other.CompareTag("Sword_Stab"))
        {
            Atk_FromPlayer = 100;
            Check_Takedame = true;
        }  
        
        if (other.CompareTag("Player"))
        {
            Player_Controller = other.GetComponent<Player_Controller>();
            InvokeRepeating("Damage_Player", 0, 1f);
        }
        if(other.CompareTag("Expolision_Range"))
        {
            Atk_FromPlayer = 80;
            Check_Takedame = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
       if(other.CompareTag("Player"))
       {
            Player_Controller = null;
            CancelInvoke("Damage_Player");
       }    
    }

    private void Damage_Player()
    {
        int Damage = Random.Range(Min_Dmg, Max_Dmg);
        Player_Controller.Take_Damage(Damage);
    }    
}
