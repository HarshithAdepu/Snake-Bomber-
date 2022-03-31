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

    public static PlayerMovement _Instance;
    enum PlayerState
    {
        ready,
        playing
    }

    private void Awake()
    {
       // pView.Owner.NickName = "";
    }
    void Start()
    {

        
        // direction = Vector3.zero;
        playerstate = PlayerState.ready;
        pView = GetComponent<PhotonView>();
        anim_Astro_Boi = GetComponent<Animator>();
        _Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

//        Debug.Log(pView.Owner.NickName);

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
        PlayerGoesOutOfBounds();

       

    }
    public void PlayerGoesOutOfBounds()
    {
        if(transform.position.x < -10.0f)
        {
            transform.position = new Vector3(9.5f,transform.position.y,transform.position.z);

        }else if (transform.position.x > 10.0f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);

        }

        if (transform.position.y <= -6.5f )
        {
            transform.position = new Vector3(transform.position.x, 4.0f, transform.position.z);
        }else if(transform.position.y >= 4.5f)
        {
            transform.position = new Vector3(transform.position.x, -6.0f, transform.position.z);
        }
    }
    private void PlayerInput()
    {
        if (pView!=null && pView.IsMine)
        {
            if (Input.GetKey(KeyCode.A))
            {
                direction = Vector3.left;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
               
                    anim_Astro_Boi.Play("Left");

            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction = Vector3.right;
               
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
             
                    anim_Astro_Boi.Play("Right");
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
