using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "New Proyectile Data", menuName = "Proyectile", order = 52)]
[System.Serializable]
public class ProjectileData : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float speed; //Speed at which bullet travels
    [SerializeField]
    uint damage; //Damage projectile deals to spacecrafts
    [SerializeField]
    float fireRate; //Rate at which it can be fired
    [SerializeField]
    uint heatAmount; //how much heat goes up per shot
    [SerializeField]
    uint maxHeat; //Amount of heat before having to cool down


    public float Speed
    {
        get { return speed; }
    }
    public uint Damage
    {
        get { return damage; }
    }
    public float FireRate
    {
        get { return fireRate; }
    }
    public uint HeatAmount
    {
        get { return heatAmount; }
    }
    public uint MaxHeat
    {
        get { return maxHeat; }
    }
    public GameObject Projectile
    {
        get { return prefab; }
    }
}
