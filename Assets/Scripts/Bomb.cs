using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bomb : MonoBehaviour
{

    [SerializeField]
    float bombTimer, explosionRange;
    [SerializeField]
    public LayerMask whatToDestroy;
    [SerializeField]
    Animator bombExplosion;

   // public string bombDropper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bombTimer -= Time.deltaTime; 

        if(bombTimer <= 0)
        { 
            Explosion();
            Debug.Log("Allahu akbar");
            this.gameObject.SetActive(false);
        }
    }

    void Explosion()
    {
        Debug.Log("Akbar be like ");
        bombExplosion.Play("Explosion");
        Collider2D[] objectToDestroy = Physics2D.OverlapCircleAll(transform.position, explosionRange, whatToDestroy);
        //foreach (var item in objectToDestroy)
        //{
        //    Debug.Log(item.gameObject.name);
        //    // how should i kill enemy? shoud i use tag or script or how do i differentiate enemy

        //}
        for (int i = 0; i < objectToDestroy.Length; i++)
        {
            Debug.Log(objectToDestroy[i].gameObject.name);
            if(objectToDestroy[i].gameObject.GetComponent<PhotonView>())
            {

            }
        }
        //Wait For Explosion to finish then set it do deactive

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;   
        Gizmos.DrawSphere(transform.position, explosionRange);
    }


}
