using UnityEngine;
using TMPro;

public class End_Anim : MonoBehaviour
{
    [SerializeField] private GameObject Form_GameOver;
    [SerializeField] private TextMeshProUGUI  txt_Coin;
    [SerializeField] private TextMeshProUGUI txt_Time;

    [SerializeField] private TextMeshProUGUI txt_CoinEnd;
    [SerializeField] private TextMeshProUGUI txt_TimeEnd;

    private void Start()
    {
        
    }
    public void Start_EndAnim()
    {
       LeanTween.moveLocal(Form_GameOver, new Vector3(448f, 228f, 0f), .5f).setDelay(.2f).setEase(LeanTweenType.easeInOutCirc);
    }
    
    public void Show_Results()
    {
        Form_GameOver.SetActive(true);
        string Time_Plays = txt_Time.text;
        int Coin = int.Parse(txt_Coin.text);
        txt_TimeEnd.text = Time_Plays;
        txt_CoinEnd.text = Coin.ToString();
        PlayerPrefs.SetString("TimePlays", Time_Plays);
        if (PlayerPrefs.GetInt("Coin") >= 0)
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + Coin);
    }

    public void Hide_Results()
    {
        Form_GameOver.SetActive(false);

    }
}
