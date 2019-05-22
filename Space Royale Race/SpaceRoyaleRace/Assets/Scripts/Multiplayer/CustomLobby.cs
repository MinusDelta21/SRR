using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;


public class CustomLobby : MonoBehaviourPunCallbacks
{
    public static CustomLobby lobby;

    public string roomName;
    public uint roomSize;


    RoomInfo[] rooms;
    void Awake()
    {
        lobby = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to Photon master server");
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public void OnRaceButtonClicked()
    {
        Debug.Log("Looking for a session");

        PhotonNetwork.JoinRandomRoom(); //Joins a random available room.
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join game. Creating session");
        CreateRoom();
    }
    void CreateRoom()
    {
        int randomName = Random.Range(0, 1000);
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 8 };
        PhotonNetwork.CreateRoom("Room " + randomName, roomOptions);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create session. Will retry...");
        CreateRoom();
    }
    public void OnCancelButtonClicked()
    {
        Debug.Log("Canceled joining a session");
        PhotonNetwork.LeaveRoom();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room");
        base.OnJoinedRoom();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
