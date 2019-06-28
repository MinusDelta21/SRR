using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    ProjectileData currentProjectile;
    GameObject projectilePrefab;

    //Heat interaction variables. 
    float currentHeat;
    bool overheated;
    //Rate of fire variables.
    float fireRate;
    float shootTimer;
    float attackSpeed;
    //Damage modifier variables.
    float damage;

    /// <summary>
    /// Item Modifiers.
    /// </summary>

    // Damage Boost
    float bypassPercentage;


    // Start is called before the first frame update
    void Start()
    {
        //Reference the prefab.
        projectilePrefab = currentProjectile.Projectile;


        //Set the heat variables to what they should be when game starts.
        currentHeat = 0;
        overheated = false;

        //Set fire rate variables.
        attackSpeed = currentProjectile.FireRate;
        fireRate = 1.0f / attackSpeed;
        shootTimer = fireRate;

        //set damage variables.
        damage = currentProjectile.Damage;

        //Set item modifiers
        bypassPercentage = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if(shootTimer <= -1.0f)
        {
            if(currentHeat > 0)
            {
                currentHeat -= 5 * Time.deltaTime;

            }
        }
        if(currentHeat <= 0.0f)
        {
            overheated = false;
        }
        if (Input.GetMouseButton(0) && !overheated)
        {
            if (currentProjectile)
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        if(shootTimer > 0.0f)
        {
            return;
        }
        GameObject shot = Instantiate(projectilePrefab, transform.position - new Vector3(0, 3, 0), Quaternion.identity);
        shot.GetComponent<Rigidbody>().velocity =
            (transform.forward * currentProjectile.Speed) * Time.deltaTime;
        shot.GetComponent<Projectile>().parent = GetComponent<PlayerShoot>();
        currentHeat += currentProjectile.HeatAmount;
        if (currentHeat >= currentProjectile.MaxHeat)
        {
            overheated = true;
        }
        shootTimer = fireRate;
    }
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float FireRate
    {
        get { return attackSpeed; }
    }
    public ProjectileData Projectile
    {
        get { return currentProjectile; }
    }

    //Item Getters
    public float ShieldBypass
    {
        get { return bypassPercentage; }
        set { bypassPercentage = value; }
    }
}
