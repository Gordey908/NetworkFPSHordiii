using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ConnectionToServer : MonoBehaviourPunCallbacks
{
    public static ConnectionToServer Instance{get; private set; }
    [SerializeField]
    private TMP_InputField inputRoomName;


    [SerializeField]
    private TMP_Text roomName;

    private void Awake()
    {
        Instance = this;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log($"Connected To Lobby!");
        UIManager.Instance.OpenPanel("MenuPanel");
    }

    public override void OnJoinedRoom()
    {
        UIManager.Instance.OpenPanel("GameRoomPanel");
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }
    public override void OnLeftRoom()
    {
        UIManager.Instance.OpenPanel("MenuPanel");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void CreateNewRoom()
    {
        if (string.IsNullOrEmpty(inputRoomName.text)) return;
        PhotonNetwork.CreateRoom(inputRoomName.text);
    }
}
