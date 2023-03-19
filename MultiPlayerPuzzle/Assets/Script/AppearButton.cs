using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearButton : MonoBehaviour
{
    [SerializeField]
    private bool SetActiveOrNot;
    public GameObject AppearObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AppearObject.SetActive(SetActiveOrNot);
        }
    }
}
