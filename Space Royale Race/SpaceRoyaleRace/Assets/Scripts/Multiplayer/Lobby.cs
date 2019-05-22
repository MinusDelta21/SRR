using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;


public class Lobby : MonoBehaviourPunCallbacks
{
    public static Lobby lobby;

    public GameObject raceButton;
    public GameObject cancelButton;

    bool leaving;

    RoomInfo[] rooms;
    void Awake()
    {
        lobby = this;
        leaving = false;
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
        EnableButton(0, true);
    }
    public void OnRaceButtonClicked()
    {
        Debug.Log("Looking for a session");
        raceButton.SetActive(false);
        cancelButton.SetActive(true);
        //EnableButton(1, false);
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
        cancelButton.SetActive(false);
        //Turn on the race button
        raceButton.SetActive(true);
        //Turn off the button component
        EnableButton(0, false);
        float time = 2.5f;
        do
        {
            if (!PhotonNetwork.InRoom)
            {
                time -= Time.deltaTime;
            }
            else
            {
                PhotonNetwork.LeaveRoom();
                EnableButton(0, true);
                OnConnectedToMaster();
                time = -1;
            }
        }
        while (time > 0.0f);
        
    }
    IEnumerator LeaveRoom(float time)
    {
        yield return new WaitForSeconds(time);
        PhotonNetwork.LeaveRoom();
        EnableButton(0, true);
        OnConnectedToMaster();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room");
        base.OnJoinedRoom();
        cancelButton.GetComponent<Button>().enabled = true;
        GameObject.Find("CancelBg").GetComponent<Image>().color = Color.white;
        cancelButton.GetComponentInChildren<Text>().color = Color.white;
    }
    /// <summary>
    /// id 0 is for race button, id 1 is for cancel button.
    /// state = if button will be enabled or disabled.
    /// </summary>
    /// <param name="id"></param>
    void EnableButton(uint id, bool state)
    {
        Vector4 color;
        if (!state)
        {
            color = new Vector4(1.0f, 1.0f, 1.0f, 0.25f);
        }
        else
        {
            color = Color.white;
        }
        if (id ==0)
        {
            raceButton.GetComponent<Button>().enabled = state;
            GameObject.Find("RaceBg").GetComponent<Image>().color = color;
            raceButton.GetComponentInChildren<Text>().color = color;
        }
        else
        {
            cancelButton.GetComponent<Button>().enabled = state;
            GameObject.Find("CancelBg").GetComponent<Image>().color = color;
            cancelButton.GetComponentInChildren<Text>().color = color;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
