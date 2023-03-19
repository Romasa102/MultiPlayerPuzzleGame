using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GravityController : MonoBehaviour
{
    public PhotonView photonView;
    public void CallChangeGravity()
    {
        photonView.RPC("ChangeGravity", RpcTarget.All);
    }
    [PunRPC]
    public void ChangeGravity()
    {
        Physics2D.gravity = new Vector2(0, -Physics2D.gravity.y);
    }

}
