using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanePointer : MonoBehaviour
{
    [SerializeField] private GameObject offScreenPointer;
    [SerializeField] private GameObject onScreenIndicator;
    [SerializeField] private TMP_Text indicatorText;

    private bool isGetEnemy;
    public bool IsGetEnemy
    {
        get => isGetEnemy;
        set => isGetEnemy = value;
    }

    public void SetIndicatorOnScreen(Vector3 screenPos, float distance)
    {
        SwitchIndicator(true);

        onScreenIndicator.transform.position = screenPos;
        indicatorText.text = distance.ToString("F0");
    }

    public void SetIndicatorOffScreen(Vector3 screenPos, float angle)
    {
        SwitchIndicator(false);
        
        offScreenPointer.transform.localPosition = screenPos;
        offScreenPointer.transform.localRotation = Quaternion.Euler(0,0, angle*Mathf.Rad2Deg);
    }

    void SwitchIndicator(bool isOnScreen)
    {
        switch (isOnScreen)
        {
            case true:
                onScreenIndicator.SetActive(true);
                offScreenPointer.SetActive(false);
                break;
            case false:
                onScreenIndicator.SetActive(false);
                offScreenPointer.SetActive(true);
                break;
        }
    }
}
