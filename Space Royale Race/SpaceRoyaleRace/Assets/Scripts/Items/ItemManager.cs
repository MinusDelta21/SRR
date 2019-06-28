using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemCategory
{
    NONE,
    CATEGORIES,
    ATTACK,
    DEFENSE,
    MOBILITY
};

public class ItemManager : MonoBehaviour
{
    public GameObject itemsCanvas;
    public List<GameObject> items;
    int state;
    // Start is called before the first frame update
    void Start()
    {
        itemsCanvas.SetActive(true);
        state = 0;
        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetActive(false);
        }
    }

    public void SetState(ItemCategory id)
    {
        ItemCategory inputCategory = id;
        if(inputCategory == ItemCategory.NONE)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].SetActive(false);
            }
        }
        else if(inputCategory == ItemCategory.CATEGORIES)
        {
            for (int i = 1; i < items.Count; i++)
            {
                items[i].SetActive(false);
            }
            items[0].SetActive(true);
        }
        else{
            StartCoroutine(SelectedCategory(inputCategory));
            
        }
        state = (int)id;
        return;
    }
    public void PurchaseItem(int index)
    {
        if(state <= 1)
        {
            return;
        }
        StartCoroutine(SelectedItem(index));
    }
    public int State
    {
        get { return state; }
    }
    IEnumerator SelectedCategory(ItemCategory id)
    {
        items[0].transform.GetChild((int)id - 2).GetComponent<Image>().color = new Color(0, 0.93f, 1, 1);
        yield return new WaitForSeconds(0.25f);
        // Do some stuff
        items[0].SetActive(false);
        items[(int)id - 1].SetActive(true);
        items[0].transform.GetChild((int)id - 2).GetComponent<Image>().color = Color.white;

    }
    IEnumerator SelectedItem(int index)
    {
        items[state - 1].transform.GetChild(index).GetComponent<Image>().color = new Color(0, 0.93f, 1, 1);
        yield return new WaitForSeconds(0.25f);
        // Do some stuff
        items[state-1].SetActive(false);
        items[state - 1].transform.GetChild(index).GetComponent<Image>().color = Color.white;
        items[state - 1].transform.GetChild(index).GetComponent<Item>().TierUp();
        state = (int)ItemCategory.NONE;
    }
}
