using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerSpawner : MonoBehaviour
{
   // [SerializeField]
   // //GameObject playerPrefab;
  public  List<Transform> playerSpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        int spawnPoints = Random.Range(0, playerSpawnPoints.Count);
        PhotonNetwork.Instantiate("Astro Boi", playerSpawnPoints[spawnPoints].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
