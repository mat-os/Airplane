using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public readonly static List<EnemyAI> enemyList = new List<EnemyAI>();
    
    void Start()
    {
        enemyList.AddRange(GameObject.FindObjectsOfType(typeof(EnemyAI)) as EnemyAI[] ?? throw new NotImplementedException());
    }
}
