using Photon.Pun;
using TMPro;
using UnityEngine;

public class RoomCreate : MonoBehaviourPunCallbacks
{
    public TMP_InputField createdRoomName;
    public TMP_InputField enteredRoomName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createdRoomName.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(enteredRoomName.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Calale");
        PhotonNetwork.LoadLevel(3);
    }
}
