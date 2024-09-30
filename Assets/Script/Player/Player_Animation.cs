using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    private Animator Anim_Player;

    private void Awake()
    {
        Anim_Player = GetComponent<Animator>();
    }
    public void Idle_Walk_Anim(float i)
    {
        Anim_Player.SetFloat("PL_Move", i);
    } 
    
    public void Player_RunAttack()
    {
        Anim_Player.SetTrigger("PL_RunAttack");
    }

    public void Player_IdleAttack()
    {
        Anim_Player.SetTrigger("PL_IdleAttack");
    }

    public void Player_StrikerAttack()
    {
        Anim_Player.SetTrigger("PL_StrikerAttack");
    }

    public void Player_Die()
    {
        Anim_Player.SetTrigger("PL_Die");
    }
}
