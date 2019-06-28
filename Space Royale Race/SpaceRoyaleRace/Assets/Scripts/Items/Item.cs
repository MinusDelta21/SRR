using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] ItemData data;
    ItemTier tier;
    ItemsID id;

    bool hasActive;
    // Start is called before the first frame update
    void Start()
    {
        tier = ItemTier.ZERO;
        hasActive = data.HasActive;
        id = data.ID;
        transform.GetChild(0).GetComponent<Image>().sprite = data.Item;
    }
    public void TierUp()
    {
        float money = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<PlayerController>().Money;
        if (tier < ItemTier.III && (money >= data.Cost(tier + 1)))
        {
            tier++;
            GameObject.FindGameObjectWithTag("GameMaster").GetComponent<PlayerController>().SubtractMoney(data.Cost(tier));
            Debug.Log("Money pre-purchase:" + money + " Remaining: " + GameObject.FindGameObjectWithTag("GameMaster").GetComponent<PlayerController>().Money);
            //Enviar el objeto de la nave ya que todos los items la afectan.
            data.Multiplier(tier, GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject);
            
        }
    }
    public void CastActive()
    {
        if (!hasActive)
        {
            return;
        }
        Debug.Log(data.Name + "has been casted");
    }
    public ItemData Data
    {
        get { return data; }
    } 

    private void Update()
    {
        
    }
}
