using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class EffectController : MonoBehaviourSingleton<EffectController>
{
    [SerializeField] private GameObject explosionPrefab;
    
    [Header("CM cam settings")]
    [SerializeField]private CinemachineVirtualCamera cmMain;
    [Range(60,100)]
    [SerializeField] private float cameraFOVWhenBoost = 65;
    [SerializeField] private float FOVSpeedOfChange = 1;
    private float startCameraFOV;
    private void OnEnable()
    {
        startCameraFOV = cmMain.m_Lens.FieldOfView;
    }

    private void OnValidate()
    {
        if (FOVSpeedOfChange < 1)
        {
            FOVSpeedOfChange = 1;
        }
    }

    public void SpawnExplosionPrefab(Vector3 posToSpawn)
    {
        Instantiate(explosionPrefab, posToSpawn, Quaternion.identity);
    }

    public void ChangeCamFOV(bool isChange)
    {
        switch (isChange)
        {
            case true:
                if (cmMain.m_Lens.FieldOfView < cameraFOVWhenBoost)
                {
                    cmMain.m_Lens.FieldOfView += FOVSpeedOfChange * Time.deltaTime;
                }
                break;
            case false:
                if (cmMain.m_Lens.FieldOfView > startCameraFOV)
                {
                    cmMain.m_Lens.FieldOfView -= FOVSpeedOfChange * Time.deltaTime;
                }
                break;
        }

    }
}
