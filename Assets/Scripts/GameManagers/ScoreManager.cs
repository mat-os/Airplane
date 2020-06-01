using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviourSingleton<ScoreManager>
{
    //[SerializeField] private GameplayUIController gameplayUiController;
    private int totalScore;
    public void AddScore(int score)
    {
        totalScore += score;
        //gameplayUiController.UpdateScore(totalScore);
    }
}
