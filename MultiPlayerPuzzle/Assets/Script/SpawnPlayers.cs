using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject PlayerPrefabs;
    public Vector2 StartPosition;

    private void Start()
    {
        PhotonNetwork.Instantiate(PlayerPrefabs.name, StartPosition, Quaternion.identity);
    }
}
