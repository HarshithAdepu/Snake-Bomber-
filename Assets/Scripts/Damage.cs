using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class Damage : MonoBehaviour
{
    bool die;
    PhotonView view;

    int team = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(die)
        {
            if(view.IsMine)
            {
                view.RPC("PlayerKilled", RpcTarget.All, team);
                //StartCoroutine(Respawn());
            }
        }
    }

    private void Respawn()
    {
        //throw new NotImplementedException();
    }

    [PunRPC]

    void PlayerKilled(int team)
    {
        if(team==0)
        {
            ScoreUpdater.playerScore_1++;
        }
        else
            ScoreUpdater.playerScore_2++;
    }
}
