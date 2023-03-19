using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public Transform[] MovePosition;
    private int PlaceNow = 0;
    private int NextPlace(int Now)
    {
        if (Now + 1 == MovePosition.Length)
        {
            return Now+1;
        }
        else
        {
            return 0;
        }
    }
    public void Update()
    {
        transform.position = Vector2.Lerp(MovePosition[PlaceNow].position, MovePosition[NextPlace(PlaceNow)].position, 2f);
        if (Vector2.Distance(transform.position, MovePosition[NextPlace(PlaceNow)].position) <= 1)
        {
            PlaceNow++;
        }
    }
}
