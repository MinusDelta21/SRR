using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    ProjectileData currentProjectile;
    float currentHeat;
    GameObject projectilePrefab;
    bool overheated;

    // Start is called before the first frame update
    void Start()
    {
        currentHeat = 0;
        overheated = false;
        projectilePrefab = currentProjectile.Projectile;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !overheated)
        {
            if (currentProjectile)
            {
                Shoot();
            }
        }
        currentHeat = Mathf.Lerp(currentHeat, 0, Time.deltaTime * 2.0f);
        if(currentHeat + currentProjectile.HeatAmount <= currentProjectile.MaxHeat)
        {
            overheated = false;
        }
    }

    public void Shoot()
    {
        GameObject shot = Instantiate(projectilePrefab, gameObject.transform);
        shot.GetComponent<Rigidbody>().AddForce(shot.transform.forward * currentProjectile.Speed*10);

        currentHeat += currentProjectile.HeatAmount;
        if(currentHeat >= currentProjectile.MaxHeat)
        {
            overheated = true;
        }
    }
}
