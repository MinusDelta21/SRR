using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpacecraft : MonoBehaviour
{
    PhotonRoom roomController;
    [SerializeField] SpacecraftData data;
    Transform spacecraftTransform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this);
        roomController = GameObject.FindGameObjectWithTag("RoomController").GetComponent<PhotonRoom>();
        if (roomController.CurrentScene == 1)
        {
            transform.position = new Vector3(0, 4, 5);
        }
        transform.position = new Vector3(0, 0, -2);
        transform.rotation = Quaternion.Euler(-15, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(roomController.CurrentScene == 1)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 50.0f);
        }
        else if(roomController.CurrentScene == 1)
        {
            transform.position = transform.GetChild(0).transform.position;
        }
    }
    
}
