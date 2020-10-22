using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform target;
    [SerializeField] Projectile projectileInstance;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] AudioSource enemyShoot;
    [SerializeField] float shootTimer = 3;
    private float currentTime = 3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null && Physics.OverlapSphere(transform.position, 5, targetLayer) != null)
        {
            target = FindObjectOfType<PlayerMovement>().transform;
        }


        if(target != null)
        {
            
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                Projectile temp = Instantiate(projectileInstance) as Projectile;
                temp.transform.position = transform.position;
                temp.transform.LookAt(target);
                temp.FireProjectile((target.position - transform.position).normalized);
                currentTime = shootTimer;
                enemyShoot.Play();
            }
        }
    }

    //public void GetTarget(Transform playerPosition)
    //{
    //    target = playerPosition;
    //    //StartCoroutine(Shoot());
    //}

    public void EnemyDeath()
    {
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, .1f);
    }

    IEnumerator Shoot()
    {
        while(target != null)
        {
            yield return new WaitForSeconds(1f);
            Projectile temp = Instantiate(projectileInstance, transform) as Projectile;
            temp.transform.LookAt(target);
            //temp.FireProjectile((target.position - transform.position).normalized);
        }
    }
}
