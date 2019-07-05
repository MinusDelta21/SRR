using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreButton : MonoBehaviour
{
    public GameObject prefab;
    private GameObject clone;
    public PlayerController prefabPlayer;
    public uint price;

    public void Confirmation()
    {
        clone = Instantiate(prefab, new Vector3(1000.0f, 450.0f, 0.0f), Quaternion.identity) as GameObject;
        clone.transform.parent = GameObject.Find("StoreCanvas").transform;
       
        for(int i=0;i<prefab.transform.childCount;i++)
        {
            Transform currentItem = prefab.transform.GetChild(i);

            if(currentItem.name.Equals("Yes"))
            {
                currentItem.GetComponent<BuyItem>().player = prefabPlayer;
                currentItem.GetComponent<BuyItem>().itemCost = price;
            }

            else if(currentItem.name.Equals("No"))
            {
                currentItem.GetComponent<BuyItem>().player = prefabPlayer;
                currentItem.GetComponent<BuyItem>().itemCost = price;
            }
        }
    }
}
