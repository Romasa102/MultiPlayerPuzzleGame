using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public GravityController gravityController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gravityController.CallChangeGravity();
    }
}