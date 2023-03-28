using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class GamePanelManager : MonoBehaviour
{
    public TMP_Text NameText;
    private void Start()
    {
        NameText.text = PhotonNetwork.CurrentRoom.Name;
    }
}