using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] platform;
    [SerializeField] private Vector2 spawnPosition;

    public static GameManager Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void spawnPlatform()
    {
        int platformIndex = Random.Range(0, platform.Length);
        Instantiate(platform[platformIndex], spawnPosition, Quaternion.identity);
    }
}
