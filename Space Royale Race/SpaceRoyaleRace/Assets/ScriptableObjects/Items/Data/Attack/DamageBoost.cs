using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DamageBoost", menuName = "DamageBoost", order = 51)]
public class DamageBoost : ItemData
{
    [Space]
    [SerializeField]List<float> multiplier;
    [SerializeField] List<float> bypassDamage;

    public override void Multiplier(ItemTier tier, GameObject player)
    {
        //Get component to be changed
        player.GetComponent<PlayerShoot>().Damage = player.GetComponent<PlayerShoot>().Damage * multiplier[(int)tier];

        switch(tier)
        {
            case ItemTier.I:
                player.GetComponent<PlayerShoot>().ShieldBypass = bypassDamage[0];
                break;
            case ItemTier.II:
                player.GetComponent<PlayerShoot>().ShieldBypass = bypassDamage[1];
                break;
            case ItemTier.III:
                player.GetComponent<PlayerShoot>().ShieldBypass = bypassDamage[2];
                break;
            default:
                player.GetComponent<PlayerShoot>().ShieldBypass = 0;
                break;
        }
    }

}
