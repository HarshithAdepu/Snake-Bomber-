using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5;
    private Vector3 direction;
    private Vector3 position;
    public Animator anim_Astro_Boi;
    
    PlayerState playerstate;
    PhotonView pView;
    enum PlayerState
    {
        ready,
        playing
    }
    void Start()
    {
        // direction = Vector3.zero;
        playerstate = PlayerState.ready;
        pView = GetComponent<PhotonView>();
        anim_Astro_Boi = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {

        switch (playerstate)
        {
            case PlayerState.ready:
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
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
        if (pView!=null && pView.IsMine)
        {
            if (Input.GetKey(KeyCode.A))
            {
                direction = Vector3.left;
                anim_Astro_Boi.Play("Left");
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;

            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction = Vector3.right;
                anim_Astro_Boi.Play("Right");
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                direction = Vector3.up;
                anim_Astro_Boi.Play("Up");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                direction = Vector3.down;
                anim_Astro_Boi.Play("Down");
            }
        }
       
    }

    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.fixedDeltaTime;

        //transform.position = new Vector3(Mathf.Ceil(position.x), Mathf.Ceil(position.y), 0);

    }
}
