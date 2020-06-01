using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetIndicatorController : MonoBehaviour
{
    [SerializeField] private PlanePointer planePointer;
    [SerializeField] private GameObject enemyPointersContainer;

    [SerializeField] private Player player;

    private List<PlanePointer> planeIndicators = new List<PlanePointer>();
    private int planeIndicatorsPointer;
    
    private void Awake()
    {
        if (player == null)
        {
            player = (Player)FindObjectOfType(typeof(Player));
        }
        

        for (int i = 0; i < EnemyController.enemyList.Count; i++)
        {
            PlanePointer pointer = Instantiate(planePointer, transform.position, Quaternion.identity);
            pointer.transform.SetParent(enemyPointersContainer.transform);
            pointer.gameObject.SetActive(true);
            pointer.name = "Pointer " + i.ToString();
            planeIndicators.Add(pointer);
        }
    }
    
    private void Update()
    {
        if (EnemyController.enemyList.Count > 0)
        {
            ShowIndicatorArrow();
        }

        if (EnemyController.enemyList.Count != planeIndicators.Count)
        {
            HideIndicator(EnemyController.enemyList.Count);
        }
    }

    PlanePointer GetIndicator()
    {
        PlanePointer pointer = null;
        
        if (planeIndicatorsPointer < planeIndicators.Count)
        {
            pointer = planeIndicators[planeIndicatorsPointer];
        }
        else
        {
            pointer = Instantiate(planePointer, transform.position, Quaternion.identity);
            pointer.transform.SetParent(enemyPointersContainer.transform);
            planeIndicators.Add(pointer);
        }
        
        pointer.gameObject.SetActive(true);

        planeIndicatorsPointer++;

        return pointer;
    }
    
    void ShowIndicatorArrow()
    {
        planeIndicatorsPointer = 0;

        foreach (var enemy in EnemyController.enemyList)
        {
            var screenPos = Camera.main.WorldToScreenPoint(enemy.transform.position);

            if (screenPos.z > 0 &&    //Обьект в пределах экрана
                screenPos.x > 0 && screenPos.y < Screen.width &&
                screenPos.y > 0 && screenPos.y < Screen.height)
            {
                screenPos.z = 0;
                var distance =  Vector3.Distance(player.transform.position, enemy.transform.position);
                
                GetIndicator().SetIndicatorOnScreen(screenPos, distance);
            }
            else  //Обьект за границей экрана
            {
                if (screenPos.z < 0)
                {
                    screenPos *= -1;
                }
                Vector3 center = new Vector3(Screen.width, Screen.height, 0) / 2;

                //Задаем координаты 00 не в левом углу а вцентре экрана
                screenPos -= center;

                float angle = Mathf.Atan2(screenPos.y, screenPos.x);
                angle -= 90 * Mathf.Deg2Rad;

                float cos = Mathf.Cos(angle);
                float sin = -Mathf.Sin(angle);

                screenPos = center + new Vector3(sin * 150, cos * 150, 0);

                float m = cos / sin;

                Vector3 screenBounds = center * 0.9f;

                if (cos > 0)
                {
                    screenPos = new Vector3(screenBounds.y / m, screenBounds.y, 0);
                }
                else
                {
                    screenPos = new Vector3(-screenBounds.y / m, -screenBounds.y, 0);
                }               
                
                if (screenPos.x > screenBounds.x)
                {
                    screenPos = new Vector3(screenBounds.x, screenBounds.x * m, 0);
                }
                else if(screenPos.x < -screenBounds.x)
                {
                    screenPos = new Vector3(-screenBounds.x, -screenBounds.x * m, 0);
                }
                
                screenPos += center;

                GetIndicator().SetIndicatorOffScreen(screenPos, angle);

                //Debug.Log("IT IS OFF SCREEN");
            }
        }
    }

    void HideIndicators()
    {
        foreach (var indicator in planeIndicators)
        {
            indicator.gameObject.SetActive(false);
        }
    }    
    void HideIndicator(int number)
    {
        planeIndicators[number].gameObject.SetActive(false);
    }
}
