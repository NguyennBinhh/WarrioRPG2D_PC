
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player_Controller Player_Controller;
    [SerializeField] private GameObject Monster;
    private void Awake()
    {
        Player_Controller = FindObjectOfType<Player_Controller>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player_Controller.Update_Coin(Random.Range(1, 3));
            Destroy(Monster);
        }    
    }
}
