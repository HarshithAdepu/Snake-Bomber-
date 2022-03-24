using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5;
    private Vector3 direction;
    private Vector3 position;
    PlayerState playerstate;

    private Animator animator;
    enum PlayerState
    {
        ready,
        playing
    }
    void Start()
    {
        direction = Vector3.zero;
        playerstate = PlayerState.ready;
        animator = GetComponent<Animator>();
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
            animator.SetTrigger("RunUp");
            direction = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger("RunDown");
            direction = Vector3.down;
        }
    }
    
    private void FixedUpdate()
    {
       position += direction * speed * Time.fixedDeltaTime;
       transform.position = new Vector3(Mathf.Ceil(position.x), Mathf.Ceil(position.y), 0);
    }
}
