using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NickNames : MonoBehaviour
{

    PhotonView pView;
    // Start is called before the first frame update
    void Start()
    {
        pView= gameObject.GetComponent<PhotonView>();
        pView.Owner.NickName = PlayerChanger._instance.nickNameText.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
