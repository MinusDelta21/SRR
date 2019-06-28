using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum ItemTier
{
    ZERO = -1,
    I,
    II,
    III
};

public enum ItemsID
{
    NONE = -1,
    //Attack items
    DamageBoost,
    FireRateBoost,
    HeatShot,
    FrostShot,
    OverheatReduction,
    SecondaryCooldown
    //Defense items


};


[CreateAssetMenu(fileName = "New Item", menuName = "Items", order = 51)]
[System.Serializable]
public class ItemData : ScriptableObject
{
    //Spacecraft string info
    [SerializeField]
    new string name;
    ItemsID id;
    [SerializeField] Sprite item;
    [TextArea] [SerializeField] string description;
    [Space] //Spaces for unlocked bool in editor
    [Space]
    [SerializeField] List<uint> cost;
    [SerializeField] bool hasActive;
    /// <summary>
    /// Returns the items name
    /// </summary>
    public string Name
    {
        get { return name; }
    }
    public bool HasActive
    {
        get { return hasActive; }
    }
    /// <summary>
    /// Returns the items description
    /// </summary>
    public string Description
    {
        get { return description; }
    }
    /// <summary>
    /// Returns the items sprite
    /// </summary>
    public Sprite Item
    {
        get { return item; }
    }
    public uint Cost(ItemTier tier)
    {
        if (tier == ItemTier.I)
        {
            return cost[0];
        }
        else if (tier == ItemTier.II)
        {
            return cost[1];
        }
        else if (tier == ItemTier.III)
        {
            return cost[2];
        }
        else return 999999;
    }
    
    public virtual void Multiplier(ItemTier tier, GameObject player)
    {
    }
    public ItemsID ID
    {
        get { return id; }
    }
}
