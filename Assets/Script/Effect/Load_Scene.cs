
using UnityEngine;
using UnityEngine.SceneManagement;
public class Load_Scene : MonoBehaviour
{
    [SerializeField] private End_Anim End_Anim;

    public void Btn_Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        End_Anim.Hide_Results();
    }   
    public void End_Game()
    {
        
        End_Anim.Show_Results();
        Time.timeScale = 0;
    }    
}
