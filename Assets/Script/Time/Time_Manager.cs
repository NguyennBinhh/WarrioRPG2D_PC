using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Time_Manager : MonoBehaviour
{
    public static Time_Manager TimeManager;
    public TextMeshProUGUI text;
    public TextMeshProUGUI Txt_CdSkill;

    float Elsetime;
    public bool Check_CD = true;
    [SerializeField] private GameObject GP_SkillCD;
    [SerializeField] private Image Img_CD;
    [HideInInspector] public float time;
    public float time_max;


    private void Update()
    {
        Elapsed_Time();
        Countdown_Time();
    }
    public void Countdown_Time()
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int second = Mathf.FloorToInt(time % 60);
        if (time > 0)
        {
            time -= Time.deltaTime;
            Check_CD = false;
            Txt_CdSkill.text = string.Format("{0}", second);
            Update_CD(time);
            GP_SkillCD.SetActive(true);
        }
        else if (time < 0)
        {
            time = 0;
            Check_CD = true;
            GP_SkillCD.SetActive(false);
        }
        
    }

    public void Elapsed_Time()
    {
        Elsetime += Time.deltaTime;
        text.text = Elsetime.ToString();
        int minutes = Mathf.FloorToInt(Elsetime / 60);
        int second = Mathf.FloorToInt(Elsetime % 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, second);
    }

    public void Update_CD(float i)
    {
        i = Mathf.Clamp(i, 0, time_max);
        float a;
        if (time_max > 0)
        {
            a = (float)(i / time_max);
            LeanTween.value(GP_SkillCD, Img_CD.fillAmount, a, 0f).setOnUpdate((float val) =>
            {
                Img_CD.fillAmount = val;
            });
        }
        

    }
}
