using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private GameObject shootTargetPrefab;
    [SerializeField] private Transform playerShootSpawn;
    enum State {
        onGamePaused,
        onGameUnPaused,
    }

    private void Start()
    {
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        Instantiate(shootTargetPrefab, playerShootSpawn.position + new Vector3(3,0,3), shootTargetPrefab.transform.rotation );
    }
    
    // public delegate void DrawLineAction(Vector3 startPoint, Vector3 endPoint);
    // public static event DrawLineAction OnDrawLineAction;
    //
    // public static void TriggerDrawLine(Vector3 start, Vector3 end)
    // {
    //     OnDrawLineAction?.Invoke(start, end);
    // }
}
