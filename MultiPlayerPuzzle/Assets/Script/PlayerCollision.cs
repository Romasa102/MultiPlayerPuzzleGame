using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public Vector3 RespawnPoint;
    private PhotonView photonView;
    private Rigidbody2D rb;
    private float PlayerCount;
    public bool Cleared = false;
    [SerializeField]
    private float JumpPadPower;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        photonView = GetComponent<PhotonView>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!photonView.IsMine)
        {
            return;
        }
        if(collision.gameObject.tag == "Obstacle")
        {
            transform.position = RespawnPoint;
        }
        if(collision.gameObject.tag == "Flag")
        {
            photonView.RPC("SetRP", RpcTarget.All,collision.gameObject.transform.position);
        }
        if(collision.gameObject.tag == "JumpPad")
        {
            rb.velocity = Vector2.zero;
            if (Physics2D.gravity.y > 0)
            {
                rb.AddForce(new Vector2(0, -JumpPadPower), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(0, JumpPadPower), ForceMode2D.Impulse);
            }
        }
        if (collision.gameObject.tag == "GravityChanger")
        {
            Debug.Log("yo");
            rb.velocity = Vector2.zero;
            photonView.RPC("ChangeGravity", RpcTarget.All, -Physics2D.gravity.y);
        }
    }
    [PunRPC]
    private void ChangeGravity(float G)
    {
        Physics2D.gravity = new Vector2(0, G);
    }
    [PunRPC]
    private void SetRP(Vector3 newRP)
    {
        RespawnPoint.x = newRP.x;
        RespawnPoint.y = newRP.y;
    }
}