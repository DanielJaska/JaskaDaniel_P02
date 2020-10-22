using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float force = 500f;
    [SerializeField] float duration = 1f;

    public void FireProjectile(Vector3 dir)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(dir * force);
        //Destroy(gameObject, duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<GameManager>().TakeDamage(10);
        }
        if(other.tag != "Enemy")
        {
            Destroy(gameObject);
        }
        
    }
}
