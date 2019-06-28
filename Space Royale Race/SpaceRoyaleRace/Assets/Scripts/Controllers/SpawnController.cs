using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour
{
    List<SpacecraftData> spacecraftDatas;
    [SerializeField] List<Image> buttons;

    SpacecraftData currentSelection;
    float selectionTime;


    public void SelectedSpacecraft(int index)
    {
        if (spacecraftDatas[index] == currentSelection || spacecraftDatas[index].Locked)
        {
            return;
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player.transform.childCount > 0)
            {
                Destroy(player.transform.GetChild(0).gameObject);
            }
            GameObject spacecraft = 
                Instantiate(spacecraftDatas[index].Spacecraft, transform.position, Quaternion.identity, player.transform);

            spacecraft.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            player.transform.position = new Vector3(0, 4, 5);
            spacecraft.transform.position = player.transform.position;

            spacecraft.GetComponent<PlayerMovement>().enabled = false;
            spacecraft.GetComponent<PlayerShoot>().enabled = false;
            spacecraft.transform.GetChild(0).GetComponent<RollSpaceship>().enabled = false;
            currentSelection = spacecraftDatas[index];
        }
        
    }

    public SpacecraftData Data
    {
        get { return currentSelection; }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        spacecraftDatas = GameObject.Find("GameMaster").GetComponent<SpacecraftsController>().Spacecrafts;
        for(int i=0; i < spacecraftDatas.Count;i++)
        {
            if (spacecraftDatas[i].Locked)
            {
                string name = spacecraftDatas[i].Name;
                Debug.Log("Changing button color");
                
                GameObject.Find("Img_" + name).GetComponent<Image>().color = Color.gray;            }
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        selectionTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        selectionTime -= Time.deltaTime;
        if(selectionTime <= 0.0f)
        {
            if(currentSelection == null)
            {
                //Selection time ran out, assign craft.
                int index = Random.Range(0, spacecraftDatas.Count);
                currentSelection = spacecraftDatas[index];
            }

            GameObject.Find("RoomController").GetComponent<PhotonRoom>().StartGame();
            enabled = false;
        }
    }
}
