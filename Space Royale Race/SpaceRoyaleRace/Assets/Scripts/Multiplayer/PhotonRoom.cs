using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

using System.IO;
using UnityEngine.SceneManagement;


//If object doesn't have a PhotonView attatch one.
[RequireComponent(typeof(PhotonView))]

public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    //Room Info
    public static PhotonRoom room;
    private PhotonView photonView;

    //[SerializeField] bool isGameLoaded;
    [SerializeField] int currentScene;
    [SerializeField] int selectionScene;
    [SerializeField] int multiplayerScene;

    //Player Info
    //Player[] photonPlayers;
    //uint playersInRoom;
    //uint myNumberInRoom;
    //string nickname;

    void Awake()
    {
        //Set up singleton
        if(PhotonRoom.room == null)
        {
            PhotonRoom.room = this;
        }
        else
        {
            Destroy(PhotonRoom.room.gameObject);
            PhotonRoom.room = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("We are now in a room");
        //photonPlayers = PhotonNetwork.PlayerList;
        //roomPlayers = photonPlayers.Lenght;
        //numberInRoom = roomPlayers;
        //PhotonNetwork.NickName = nickname;
        StartGame();
    }
    public void StartGame()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        if(currentScene == 0)
        {
            PhotonNetwork.LoadLevel(selectionScene);
        }
        else if(currentScene == selectionScene)
        {
            PhotonNetwork.LoadLevel(multiplayerScene);
        }
    }
    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.buildIndex;
        if(currentScene == selectionScene)
        {

        }
        else if(currentScene == multiplayerScene)
        {
            CreatePlayer();
        }
    }
    private void CreatePlayer()
    {
        GameObject[] spacecrafts = GameObject.FindGameObjectsWithTag("Spacecraft");
        foreach(GameObject spacecraft in spacecrafts)
        {
            spacecraft.transform.parent.rotation = Quaternion.Euler(0, 0, 0);
            spacecraft.transform.rotation = Quaternion.Euler(0, 0, 0);
            spacecraft.GetComponent<PlayerMovement>().enabled = true;
            spacecraft.transform.GetChild(0).GetComponent<RollSpaceship>().enabled = true;
        }

    }
    void Start()
    {
        photonView = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int CurrentScene
    {
        get { return currentScene; }
    }
}
