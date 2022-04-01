using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSpawner : MonoBehaviour
{
    // [SerializeField]
    public GameObject playerPrefab;
    public List<Transform> playerSpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        int spawnPoints = Random.Range(0, playerSpawnPoints.Count);
        PhotonNetwork.Instantiate(playerPrefab.name,playerSpawnPoints[spawnPoints].position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }

}