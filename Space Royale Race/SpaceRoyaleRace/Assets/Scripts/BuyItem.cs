using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public uint itemCost = 0;
    public PlayerController player;
    
    public void Yes()
    {
        if (player.money > itemCost)
        {
            player.SubtractMoney(itemCost);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void No()
    {
        Destroy(transform.parent.gameObject);
    }
}
