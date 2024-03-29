﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour
{

    PlayerData playerData;
    uint money;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        playerData = ScriptableObject.CreateInstance("PlayerData") as PlayerData;
        playerData.Load();
    }

    void SetMoneyText()
    {
        GameObject.FindGameObjectWithTag("Money").GetComponent<Text>().text = playerData.Money.ToString();
    }
    public void AddMoney(uint amount)
    {
        money += amount;
        playerData.Money = money;
    }
    public void SubtractMoney(uint amount)
    {
        money -= amount;
        playerData.Money = money;
    }


    private void Update()
    {
        
    }
}
