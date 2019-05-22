using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    SpacecraftData data;

    int health;
    int shield;

    private void Start()
    {
        health = Mathf.Abs((int)data.Health);
    }

    public void Damage(uint amount)
    {
        if(shield > 0)
        {
            shield -= (int)amount;
        }
        if (shield <= 0)
        {
            health -= shield;
            shield = 0;
        }
    }
    public void Shield(uint amount)
    {
        shield += (int)amount;
    }
    
}
