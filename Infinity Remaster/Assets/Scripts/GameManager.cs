using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool red;

    public event Action OnSpawn;
    public event Action OnLevelChange;
    public event Action OnGameEnd;

    public Vector3 spawnPoint;
    


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        instance= this;
    }
    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        
        OnSpawn?.Invoke();
    }

    public void ChangeLevel()
    {
        red = !red;
        OnLevelChange?.Invoke();
    }


    public void GameOver()
    {
        OnGameEnd?.Invoke();
    }
}
