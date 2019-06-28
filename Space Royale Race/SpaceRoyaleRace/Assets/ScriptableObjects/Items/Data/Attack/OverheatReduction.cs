using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "OverheatReduction", menuName = "OverheatReduction", order = 51)]
public class OverheatReduction : ItemData
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
            float rand = Random.Range(0, 1);
            if(rand <= 0.10f)
            {
                return 0.0f;
            }
            return multiplier[1];
        }
        else if (tier == ItemTier.III)
        {
            float rand = Random.Range(0, 1);
            if (rand <= 0.3f)
            {
                return 0.0f;
            }
            return multiplier[2];
        }
        else return 999999;
    }
    
}
