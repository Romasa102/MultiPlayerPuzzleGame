using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ClearObject : MonoBehaviour
{
    private float playerCount = 0;
    public GameObject ClearPanel;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerCount++;
        }
        if (playerCount >= 2)
        {
            ClearIt();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerCount--;
        }
        if(playerCount < 0)
        {
            playerCount = 0;
        }
    }
    void ClearIt()
    {
        StartCoroutine(EndLevel());
    }
    IEnumerator EndLevel()
    {
        ClearPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex+1);
    }
}
