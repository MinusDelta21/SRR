using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AttackSpeedBoost", menuName = "AttackSpeedBoost", order = 51)]
public class AttackSpeedBoost : ItemData
{
    [Space]
    [SerializeField]List<float> multiplier;
    [SerializeField] List<float> multishotChance;


    public override void Multiplier(ItemTier tier, GameObject player)
    {
        //Get component to be changed
        player.GetComponent<PlayerShoot>().Damage = player.GetComponent<PlayerShoot>().Damage * multiplier[(int)tier];
        float chance = Random.Range(0,101);
        switch (tier)
        {
            case ItemTier.I:
                if ((100 - chance) <= multishotChance[0]){
                    player.GetComponent<PlayerShoot>().MultiShot = true;
                }
                break;
            case ItemTier.II:
                if((1 - chance) <= multishotChance[1]){
                    player.GetComponent<PlayerShoot>().MultiShot = true;
                }
                break;
            case ItemTier.III:
                if ((1 - chance) <= multishotChance[2])
                {
                    player.GetComponent<PlayerShoot>().MultiShot = true;
                }
                break;
            default:
                player.GetComponent<PlayerShoot>().MultiShot = true;
                break;
        }
    }

}
