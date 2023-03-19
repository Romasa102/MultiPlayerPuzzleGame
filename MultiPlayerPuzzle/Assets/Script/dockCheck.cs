using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dockCheck : MonoBehaviour
{
    public bool CanDock = false;
    public GameObject otherPlayer;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DockingCheck")
        {
            CanDock = true;
            otherPlayer = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DockingCheck")
        {
            CanDock = false;
        }
    }
}
