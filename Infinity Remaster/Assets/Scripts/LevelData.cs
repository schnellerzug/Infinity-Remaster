using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ObstacleSpawnerScriptableObject", order = 1)]
public class LevelData : ScriptableObject
{
    public float disObstacle;
    public float obstacleHigh;
    public float startDis;
    public Vector2 minMaxHoles;
    public Vector2 minMaxHoleSize;

}
