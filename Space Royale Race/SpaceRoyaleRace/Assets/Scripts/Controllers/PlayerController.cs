using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour
{

    PlayerData playerData;
    public ItemManager itemManager;
    float money;

    public GameObject debug;
    public Text moneyText;
    bool isDebugging;

    List<Item> attackItems;
    List<Item> defenseItems;
    List<Item> mobilityItems;


    [SerializeField] PhotonRoom roomController;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        playerData = ScriptableObject.CreateInstance("PlayerData") as PlayerData;
        playerData.Load();
        debug.SetActive(false);
        isDebugging = false;
    }

    void SetMoneyText()
    {
        moneyText.text = money.ToString();
    }
    /*public void AddMoney(int amount)
    {
        money += amount;
        //playerData.Money = money;
    }*/
    public void SubtractMoney(float amount)
    {
        money -= amount;
        SetMoneyText();
    }

    public void ShowDebug(bool state)
    {
        if (state)
        {
            debug.SetActive(true);
            isDebugging = true;
        }
        else
        {
            debug.SetActive(false);
            isDebugging = false;
        }
    }
    void SetDebugText()
    {
        SetMoneyText();
        debug.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = 
            GameObject.FindGameObjectWithTag("Spacecraft").GetComponent<PlayerMovement>().Speed.ToString();
        debug.transform.GetChild(3).GetChild(0).GetComponent<Text>().text =
            GameObject.FindGameObjectWithTag("Spacecraft").GetComponent<PlayerMovement>().MaxSpeed.ToString();
        debug.transform.GetChild(2).GetChild(0).GetComponent<Text>().text =
            GameObject.FindGameObjectWithTag("Spacecraft").GetComponent<PlayerHealth>().Shield.ToString();
        debug.transform.GetChild(1).GetChild(0).GetComponent<Text>().text =
            GameObject.FindGameObjectWithTag("Spacecraft").GetComponent<PlayerShoot>().FireRate.ToString();
        debug.transform.GetChild(0).GetChild(0).GetComponent<Text>().text =
            GameObject.FindGameObjectWithTag("Spacecraft").GetComponent<PlayerShoot>().Damage.ToString();
    }
    private void Update()
    {
        if (roomController.CurrentScene == roomController.MultiplayerScene)
        {
            StartCoroutine(AddMoney(10.0f * Time.deltaTime));
        }
        //Open or close item canvas
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab pressed");
            if (itemManager.State == (int)ItemCategory.NONE)
            {
                itemManager.SetState(ItemCategory.CATEGORIES);
                Debug.Log(itemManager.State);
            }
            else
            {
                itemManager.SetState(ItemCategory.NONE);
            }
            return;
        }

        if (itemManager.State == (int)ItemCategory.CATEGORIES)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                {
                itemManager.SetState(ItemCategory.ATTACK);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)){
                itemManager.SetState(ItemCategory.DEFENSE);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)){
                itemManager.SetState(ItemCategory.MOBILITY);
            }
            return;
        }
        if(itemManager.State > (int)ItemCategory.CATEGORIES)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                itemManager.PurchaseItem(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                itemManager.PurchaseItem(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                itemManager.PurchaseItem(2);
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowDebug(!isDebugging);
            return;
        }
        
    }
    public IEnumerator AddMoney(float amount)
    {
        yield return new WaitForSeconds(1f);
        money += amount;
        SetDebugText();
    }
    public float Money
    {
        get { return money; }
    }
}
