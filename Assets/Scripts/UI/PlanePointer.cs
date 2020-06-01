using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlanePointer : MonoBehaviour
{
    [SerializeField] private GameObject offScreenPointer;
    [SerializeField] private GameObject onScreenIndicator;
    [SerializeField] private TMP_Text indicatorText;

    private bool isMadeEffect;
    public void SetIndicatorOnScreen(Vector3 screenPos, float distance)
    {
        SwitchIndicator(true);

        onScreenIndicator.transform.position = screenPos;
        indicatorText.text = distance.ToString("F0");

        if (!isMadeEffect)
        {
            MakeVisualEffect();
        }
    }

    public void SetIndicatorOffScreen(Vector3 screenPos, float angle)
    {
        SwitchIndicator(false);
        
        offScreenPointer.transform.localPosition = screenPos;
        offScreenPointer.transform.localRotation = Quaternion.Euler(0,0, angle*Mathf.Rad2Deg);

        isMadeEffect = false;
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

    void MakeVisualEffect()
    {
        onScreenIndicator.transform.localScale = Vector3.one * 2;
        onScreenIndicator.transform.DOScale(1, 0.5f);

        indicatorText.DOFade(0, 0);
        indicatorText.DOFade(1, 1f);
        isMadeEffect = true;
    }
}
