using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HearthBar : MonoBehaviour
{
    private int Max_Health;

    [SerializeField] private Image Img_Hp;
    [SerializeField] private GameObject GO_Hp;
  
    private void Start()
    {
        Max_Health = 100;
    }

    public void Update_Health(float i)
    {
        i = Mathf.Clamp(i, 0, Max_Health);
        float a = (float)(i / Max_Health);
        LeanTween.value(GO_Hp, Img_Hp.fillAmount, a, 0.5f).setOnUpdate((float val) =>
        {
            Img_Hp.fillAmount = val;
        });
    }
    

    
}
