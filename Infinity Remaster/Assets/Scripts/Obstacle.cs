using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Obstacle: MonoBehaviour
{
    public GameObject prefab;
    public GameObject obstacle;
    private List<Hole> holes;
    private float actuelPosition;

    public Obstacle(GameObject obstaclePre, Vector2 size, float holeamount, Vector2 minMaxHoleSize)
    {
        prefab= obstaclePre;
        holes= new List<Hole>();
        obstacle = new GameObject();
        for (int i = 0; i < holeamount; i++)
        {
            var hole = new Hole();


            hole.holeSize = new Vector2((minMaxHoleSize.x + (minMaxHoleSize.y - minMaxHoleSize.x) * Random.value), size.y);
                hole.position = new Vector2((-size.x + hole.holeSize.x/2) + ((size.x - hole.holeSize.x/2) - (-size.x + hole.holeSize.x/2)) * Random.value, 0);

            holes.Add(hole);
        }
        holes.OrderBy(x => -(x.position.x - x.holeSize.x)).ToList();


        actuelPosition = - size.x ;
        foreach (var hole in holes)
        {
            //if (actuelPosition > size.x || actuelPosition < -size.x)
            //{
            //    return;

            var beginnHole = (hole.position.x - hole.holeSize.x / 2);
            if (beginnHole < actuelPosition)
            {
                if (beginnHole + hole.holeSize.x < actuelPosition)
                {
                    print("hello" + beginnHole + hole.holeSize.x);
                    break;
                }

                beginnHole = actuelPosition;
                //actuelPosition = actuelPosition + hole.size.x;
            }

            var newO = Instantiate(prefab, obstacle.transform);
            newO.transform.position = new Vector2(actuelPosition, 0);

            newO.transform.localScale = new Vector2(beginnHole -actuelPosition, size.y);
            actuelPosition = beginnHole + hole.holeSize.x;

           
        }
        if(actuelPosition > size.x)
            return;
        var lastO = Instantiate(prefab, obstacle.transform);
        lastO.transform.position = new Vector2(actuelPosition, 0);
        lastO.transform.localScale = new Vector2(size.x - actuelPosition, size.y);
        
    }


}
