using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometrUIController : MonoBehaviour
{
    [SerializeField]private Image speedBar;
    
    [SerializeField] private TMP_Text speedText;
    
    public void UpdateSpeedometr(float speed)
    {
        ChangeValue(speed);
        ChangeTextValue(speed);
    }

    private void ChangeValue(float speedValue)
    {
        float amount = (speedValue / 100) * 180 / 360;
        speedBar.fillAmount = amount;
        
        if (amount > 0.5f)
        {
            speedBar.DOColor(Color.red, 1f);
        }
        else
        {
            speedBar.DOColor(Color.white, 1f);
        }
    }

    private void ChangeTextValue(float speedValue)
    {
        speedText.text = speedValue.ToString("F0");
    }
}
