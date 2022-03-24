using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5;
    private Vector3 direction;
    PlayerState playerstate;

    enum PlayerState
    {
        ready,
        playing
    }
    void Start()
    {
        direction = Vector3.zero;
        playerstate = PlayerState.ready;
    }

    // Update is called once per frame
    void Update()
    {

        switch(playerstate)
        {
            case PlayerState.ready:
                 if(Input.anyKeyDown)
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
    
    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.fixedDeltaTime;
    }
}
