using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Camera camera;
    public GameObject prefab;

    public LevelData data;
    private Transform actuelObstacle;
    private Transform nextObstacle;



    private void Awake()
    {
        camera  ??= Camera.main;        

  
    }

    private void Start()
    {
                    GameManager.instance.OnSpawn += StartSpawn;
        GameManager.instance.OnLevelChange += NextLevel;
    }

    private void StartSpawn()
    {
        actuelObstacle = CreateObstacles();
        actuelObstacle.gameObject.SetActive(true);
        nextObstacle = CreateObstacles();
    }

    private void NextLevel()
    {
        actuelObstacle.gameObject.SetActive(false);
        actuelObstacle = nextObstacle;
        actuelObstacle.gameObject.SetActive(true);
        nextObstacle = CreateObstacles();
    }
    [ContextMenu("Create")]
    public Transform CreateObstacles()
    {
        var parent = new GameObject("Level").transform;

        float height = 2f * camera.orthographicSize;
        float width = height * camera.aspect;

        var startpoint = height/2 - data.startDis;
        var endpoint = - height/2 + data.startDis;

        for (int i = 1; startpoint - (i * data.disObstacle) > endpoint; i++)
        {
            var holes = data.minMaxHoles.x + (data.minMaxHoles.y - data.minMaxHoles.x) * Random.value;
            var o = new Obstacle(prefab, new Vector2(width / 2, data.obstacleHigh), holes, data.minMaxHoleSize);
            o.obstacle.transform.position = new Vector2(0,startpoint - (i * data.disObstacle));
            o.obstacle.transform.SetParent(parent);
            
        }
        parent.gameObject.SetActive(false);
        return parent;
        
    }

}
