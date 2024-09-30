using TMPro;
using System.Collections;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D Rb_Player;
    [HideInInspector]public Vector3 Move_Input;
    private Player_Animation Player_Animation;
    private Player_Attacks Player_Attacks;
    private HearthBar HearthBar;
    private BoxCollider2D Cld_Player;


    [SerializeField] private TextMeshProUGUI Txt_Coin;
    [SerializeField] private float Speed_Pl;
    [SerializeField] private Time_Manager CD_SkillJ;
    [SerializeField] private Time_Manager CD_SkillU;
    [SerializeField] private Time_Manager CD_SkillL;
    [SerializeField] private Time_Manager CD_SkillK;
    [SerializeField] private Load_Scene Load_Scene;


    private bool Check_PlayerATKSword; // Đánh thường J
    private bool Check_IsFacingRight;
    private bool Check_PlayerUdown; //Skill U
    private bool Check_PlayerLdown;// Skill L
    private bool Check_PlayerKdown;// Skill K

    public float Hp_Player;
    private int Coin;

    private void Awake()
    {
        Player_Animation = GetComponent<Player_Animation>();
        Player_Attacks = GetComponent<Player_Attacks>();
        Cld_Player = GetComponent<BoxCollider2D>();
        Hp_Player = 100;
        Check_IsFacingRight = true;
        HearthBar = GetComponent<HearthBar>();
        Coin = 0;
    }
    private void Update()
    {
        Ctrl_Player_Movement();
        Ctrl_Player_Skill();
        Player_Die();
    }

    private void Ctrl_Player_Movement()
    {
        Player_Input();
        Direction_Player();
        transform.position += Move_Input * Speed_Pl * Time.deltaTime;
        Player_Animation.Idle_Walk_Anim(Move_Input.sqrMagnitude);
    }  
    
    private void Player_Input()
    {
        Move_Input.x = Input.GetAxis("Horizontal");
        Move_Input.y = Input.GetAxis("Vertical");
        Check_PlayerATKSword = Input.GetKeyDown(KeyCode.J);
        Check_PlayerUdown = Input.GetKeyDown(KeyCode.U);
        Check_PlayerLdown = Input.GetKeyDown(KeyCode.L);
        Check_PlayerKdown = Input.GetKeyDown(KeyCode.K);
    }
    
   
    private void Ctrl_Player_Skill()
    {
        if(Check_PlayerATKSword && CD_SkillJ.Check_CD)
        {
            Player_Animation.Player_IdleAttack();
            Player_Attacks.Pl_ATKSword();
            transform.position += new Vector3(0.0001f, 0, 0);
            Check_PlayerATKSword = false;
            CD_SkillJ.time = 1f;
            CD_SkillJ.Countdown_Time();
        }
        else if(Check_PlayerLdown && CD_SkillL.Check_CD)
        {
            Player_Attacks.Pl_AtkL();
            Player_Animation.Player_StrikerAttack();
            Check_PlayerLdown = false;
            CD_SkillL.time = 5f;
            CD_SkillL.time_max = 5f;
            CD_SkillL.Countdown_Time();
        } 
        else if(Check_PlayerKdown && CD_SkillK.Check_CD)
        {
            Player_Attacks.Pl_SkillK(Move_Input);
            CD_SkillK.time = 7f;
            CD_SkillK.time_max = 7f;
            CD_SkillK.Countdown_Time();
        }  
        else if (Check_PlayerUdown && CD_SkillU.Check_CD)
        {
            Player_Attacks.Pl_SkillU(50);
            if(Hp_Player > 100)
            {
                Hp_Player = Hp_Player - (Hp_Player - 100);
            }
            HearthBar.Update_Health(Hp_Player);
            CD_SkillU.time = 10f;
            CD_SkillU.time_max = 10f;
            CD_SkillU.Countdown_Time();

        }
        
    }


    public void Take_Damage(float dame)
    {
        if (0 < Hp_Player && Hp_Player <= 100)
        {
            Hp_Player -= dame;
            HearthBar.Update_Health(Hp_Player);
        }
    }

    private void Player_Die()
    {
        if (Hp_Player < 0)
        {
            StartCoroutine(Player_DieAnim());
            
        }
    }   
    
    public void Update_Coin(int i)
    {
        Coin = Coin + i;
        Txt_Coin.text = Coin.ToString();
    }
    
    IEnumerator Player_DieAnim()
    {
        Player_Animation.Player_Die();
        yield return new WaitForSeconds(1f);
        Cld_Player.enabled = false;
        Load_Scene.End_Game();
    }    
    private void Direction_Player()
    {
        if (Move_Input.x > 0 && Check_IsFacingRight == false)
        {
            transform.localScale = new Vector3(1, 1, 1);
            Check_IsFacingRight = true;
        }
        if (Move_Input.x < 0 && Check_IsFacingRight == true)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            Check_IsFacingRight = false;
        } 
    }
}
