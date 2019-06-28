using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float damage;
    public PlayerShoot parent;
    Transform parentTransform;
    float enableTime = 0.05f;

    //Item Effects.
    float bypassShields;



    private void Start()
    {
        damage = parent.Damage;
        bypassShields = parent.ShieldBypass;
        parentTransform = parent.transform;
        Debug.Log("Projectile Damage = " + damage);
        GetComponent<CapsuleCollider>().enabled = false;

    }
    private void Update()
    {
        enableTime -= Time.deltaTime;
        if(enableTime <= 0.0f)
        {
            GetComponent<CapsuleCollider>().enabled = true;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Spaceship") && collision.transform != parentTransform.GetChild(0))
        {

            collision.transform.parent.GetComponent<PlayerHealth>().Damage(damage);
            damage = damage * bypassShields;
            collision.transform.parent.GetComponent<PlayerHealth>().DamageHealth(damage);

            Destroy(this.gameObject);
        }
        else
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
        }
    }
}
