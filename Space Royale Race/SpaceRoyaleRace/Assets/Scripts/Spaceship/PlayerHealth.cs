using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    SpacecraftData data;

    float health;
    //Shield variables
    float shield;
    float shieldMultiplier;
    float recoveryRate;
    float recoveryTimer;

    private void Start()
    {
        health = data.Health;
        shield = data.Shield;
        recoveryRate = data.RecoveryRate;
        recoveryTimer = 10.0f;
        shieldMultiplier = 1.0f;
    }
    private void Update()
    {
        recoveryTimer -= Time.deltaTime;
        if(recoveryTimer <= 0.0f)
        {
            RecoverShields();
            recoveryTimer = 0.0f;

        }
        if (Input.GetKeyDown(KeyCode.H))
        {

            Hit();
            Debug.Log("Spacecract hit" + recoveryTimer);
            Damage(150);
            Debug.Log("Shields = " + shield);
            Debug.Log("Health = " + health);

        }
    }
    /// <summary>
    /// Public hit functions
    /// </summary>
    void Hit()
    {
        recoveryTimer = 10.0f;
    }
    /// <summary>
    /// Health functions
    /// </summary>
    public float Health
    {
        get { return health; }
    }
    public void DamageHealth(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Kill();
        }
    }
    public void Kill()
    {
        //Do whatever the thing has to do when killed.
        Destroy(gameObject);
        Debug.Log("Killed.   " + "Health = " + health);
    }
    /// <summary>
    /// Shield functions
    /// </summary>
    public float Shield
    {
        get{return shield;}
    }
    void RecoverShields()
    {
        if(recoveryTimer > 0.0f)
        {
            //Don't do anything and return.
            return;
        }
        if(shield < data.Shield * shieldMultiplier)
        {
            shield += recoveryRate * Time.deltaTime;
            Debug.Log("Recovering Shields. Current shield = " + shield);
        }
        else
        {
            Debug.Log("Shields full");
            shield = data.Shield * shieldMultiplier;
        }
    }
    public void Damage(float amount)
    {
        Hit();
        shield -= amount;
        if(shield < 0)
        {
            DamageHealth(-shield);
            shield = 0;
        }
    }
}
