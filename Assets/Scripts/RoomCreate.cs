using Photon.Pun;
using UnityEngine.UI;

public class RoomCreate : MonoBehaviourPunCallbacks
{
    public InputField createdRoomName;
    public InputField enteredRoomName;
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
        PhotonNetwork.LoadLevel(2);
    }
}
