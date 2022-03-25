using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;

public class CoinManager : MonoBehaviour
{
    //public CanvasUpdater up;
    void OnTriggerEnter(Collider other)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (other.tag == "Player")
            {
                //up.AddScore();
                PhotonNetwork.Destroy(this.gameObject);
            }
        }

    }

}
