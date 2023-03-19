using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockY : MonoBehaviour
{
    public Transform Player;
    public float Offset;
    void Update()
    {
        transform.localPosition = new Vector3(0, -Player.position.y,-Offset);
    }
}
