using System;
using UnityEngine;

[RequireComponent(typeof(Airplane))]
[RequireComponent(typeof(WeaponOnAirplane))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Airplane airplane;
    [SerializeField] private GameObject target;

    private IEnemyState currentState;
    private void Awake()
    {
        IDriver driver = new AIDriver();
        airplane.SetDriver(driver);
        airplane.StartEngine();

        //currentState = new NormalEnemyState();

        TriggerFightState();
    }

    private void TriggerFightState()
    {
        currentState = new FightingEnemyState(); }
    
    private void FixedUpdate()
    {
        currentState.Execute(airplane, target);
    }

    private void OnDestroy()
    {
        EnemyController.enemyList.Remove(this);
    }
}
