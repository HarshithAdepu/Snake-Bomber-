using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5;
    private Vector3 direction;
    private Vector3 position;
    PlayerState playerstate;
    PhotonView pView;
    enum PlayerState
    {
        ready,
        playing
    }
    void Start()
    {
        direction = Vector3.zero;
        playerstate = PlayerState.ready;
        pView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

        switch(playerstate)
        {
            case PlayerState.ready:
                 if(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S))
                {
                    playerstate = PlayerState.playing;
                }
                break;
            case PlayerState.playing:
                PlayerInput();
                break;
        }

    }
    
    private void PlayerInput()
    {
        if(pView.IsMine)
        {
            if (Input.GetKey(KeyCode.A))
            {
                direction = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction = Vector3.right;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                direction = Vector3.up;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                direction = Vector3.down;
            }
        }
    }
    
    private void FixedUpdate()
    {
        position += direction * speed * Time.fixedDeltaTime;
        transform.position = new Vector3(Mathf.Ceil(position.x), Mathf.Ceil(position.y), 0);
    }
}
