using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView photonView;
    [SerializeField]
    private float PlayerSpeed = 8f;
    [SerializeField]
    private float NormalSpeed;
    [SerializeField]
    private float AirSpeed;
    [SerializeField]
    private float jumpPower;
    private float XMove;
    private Rigidbody2D rb;
    private Camera MyCamera;
    public bool OnGround = false;
    public GameObject BeGround;
    private SpriteRenderer spriteRenderer;
    private bool CanStatic = true;
    public GameObject StaticText;
    private PlayerCollision playerCollision;

    void Start()
    {
        playerCollision = GetComponent<PlayerCollision>();
        StaticText = GameObject.Find("StaticStatus");
        MyCamera = GetComponentInChildren<Camera>();
        photonView = GetComponent<PhotonView>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!photonView.IsMine)
        {
            MyCamera.enabled = false;
        }
        rb = GetComponent<Rigidbody2D>();
        StaticText.SetActive(false);
    }

    void Update()
    {
        if (!photonView.IsMine || !SpawnPlayers.UcanMove)
        {
            return;
        }
        if ((Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.UpArrow)) && OnGround)
        {
            rb.velocity = Vector2.zero;
            if (Physics2D.gravity.y > 0)
            {
                rb.AddForce(new Vector2(0, -jumpPower), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && CanStatic)
        {
            photonView.RPC("TurnGround", RpcTarget.All);
            CanStatic = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = playerCollision.RespawnPoint;
        }
        if (OnGround)
        {
            PlayerSpeed = NormalSpeed;
        }
        else
        {
            PlayerSpeed = AirSpeed;
        }
        XMove = Input.GetAxisRaw("Horizontal") * PlayerSpeed;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(XMove * Time.deltaTime, rb.velocity.y);
    }
    [PunRPC]
    private void TurnGround()
    {
        rb.bodyType = RigidbodyType2D.Static;
        BeGround.SetActive(true);
        StaticText.SetActive(true);
        StartCoroutine(StaticModeReset());
    }
    [PunRPC]
    private void TurnGroundOff()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        BeGround.SetActive(false);
        StaticText.SetActive(false);
    }
    private IEnumerator StaticModeReset()
    {
        yield return new WaitForSeconds(4);
        photonView.RPC("TurnGroundOff", RpcTarget.All);
        CanStatic = true;
    }
}
