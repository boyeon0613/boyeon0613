using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//지면감지기능
//1.OnCollisionEnter(Collision collision) : collsion의 GameObject의 Layer을 비교한 다음, Layer가 Ground면 Jump가 가능하도록 한다.
//2.Raycast 선을 쏴서 닿은 오브젝트 참조
//3.Boxcast 박스에 닿은 오브젝트 참조
//4.Overrap 특정 범위에 특수한 오드젝트 있으면 감지

public class PlayerController : MonoBehaviour
{
    Transform tr;
    Rigidbody2D rb;
    BoxCollider2D col;
    public float moveSpeed;
    public float jumpForce;

    PlayerState playerState;

    //Detectors
    PlayerGroundDetector groundDetector;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        groundDetector = GetComponent<PlayerGroundDetector>();
    }
    private void Update()
    {
        //키보드 좌우 입력 받아서 게임 오브젝트를 좌우로 움직이는 기능
        float h = Input.GetAxis("Horizontal");
        rb.position += new Vector2(h * moveSpeed * Time.deltaTime, 0);

        if (playerState != PlayerState.Jump && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            playerState = PlayerState.Jump;
        }
        UpdatePlayerState();
    }

    void UpdatePlayerState()
    {
        switch (playerState)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Run:
                break;
            case PlayerState.Jump:
                if(groundDetector.isGrounded)
                    playerState = PlayerState.Idle;
                break;
            default:
                break;
        }
    }

    enum PlayerState
    {
        Idle,
        Run,
        Jump,
    }
}
