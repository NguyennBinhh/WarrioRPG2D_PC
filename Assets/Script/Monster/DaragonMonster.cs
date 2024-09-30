    using System.Collections;
    using UnityEngine;

    public class DaragonMonster : MonoBehaviour
    {
        private float Hp_Monster;
        [SerializeField] private Transform Player;
        [SerializeField] private Player_Controller Player_Controller;
        [SerializeField] private GameObject Coin;
        
        private SpawnMonster spawnMonster;
        private Monster_Collider Monster_Collider;
        private Animator Mon_Animator;
        private bool isDead;
        private MonsterAI MonsterAI;
        private BoxCollider2D BoxCollider2D;
        
        
        void Start()
        {
            Hp_Monster = 80;
            Monster_Collider = GetComponent<Monster_Collider>();
            BoxCollider2D = GetComponent<BoxCollider2D>();
            Mon_Animator = GetComponent<Animator>();
            MonsterAI = GetComponent<MonsterAI>();
            spawnMonster = FindObjectOfType<SpawnMonster>();
        }

        private void Update()
        {
            Take_Damage();
        }

        public void Take_Damage()
        {
            if (Monster_Collider.Check_Takedame)
            {
                if (Hp_Monster > 0)
                {
                    Hp_Monster -= Monster_Collider.Atk_FromPlayer;
                }
            
                Monster_Collider.Check_Takedame = false;
                Debug.Log(Hp_Monster);
            }
            if (Hp_Monster <= 0)
            {
                BoxCollider2D.enabled = false;
                MonsterAI.Speed_Monter = 0f;
                StartCoroutine(Monster_Die());
            
            }

        }
    
        IEnumerator Monster_Die()
        {
            Mon_Animator.SetTrigger("Dragon_Die");
            yield return new WaitForSeconds(1f);
            Coin.SetActive(true);
            Coin.transform.position = transform.position;
            Destroy(gameObject);
            spawnMonster.currentEnemyCount--;
        
        }    
    
     

    }
