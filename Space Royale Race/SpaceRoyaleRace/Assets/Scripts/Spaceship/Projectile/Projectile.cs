using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    ProjectileData data;

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Spaceship") && collision.transform != transform.parent)
        {
            collision.transform.parent.GetComponent<PlayerHealth>().Damage(data.Damage);
        }
        else
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), transform.parent.GetComponentInChildren<Collider>());
        }
    }
}
