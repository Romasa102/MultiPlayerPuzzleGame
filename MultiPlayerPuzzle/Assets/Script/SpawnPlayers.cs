using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject PlayerPrefabs;
    public Vector2 StartPosition;
    public GameObject Waiting;
    public static bool UcanMove;

    private void Start()
    {
        PhotonNetwork.Instantiate(PlayerPrefabs.name, StartPosition, Quaternion.identity);
    }
    private void Update()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount <= 1)
        {
            Waiting.SetActive(true);
            UcanMove = false;
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Waiting.SetActive(false);
            UcanMove = true;
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
    }
}
