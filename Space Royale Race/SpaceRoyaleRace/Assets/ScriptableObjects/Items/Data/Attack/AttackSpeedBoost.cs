using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AttackSpeedBoost", menuName = "AttackSpeedBoost", order = 51)]
public class AttackSpeedBoost : ItemData
{
    [Space]
    [SerializeField]List<float> multiplier;

    public float Multiplier(ItemTier tier)
    {
        if (tier == ItemTier.I)
        {
            return multiplier[0];
        }
        else if (tier == ItemTier.II)
        {
            return multiplier[1];
        }
        else if (tier == ItemTier.III)
        {
            return multiplier[2];
        }
        else return 999999;
    }
    
}
