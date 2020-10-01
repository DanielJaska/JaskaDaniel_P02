using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVolume : MonoBehaviour
{
    [SerializeField] int damageToDeal = 5;
    [SerializeField] float damageTimer = 1;

    private bool isActive = false;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        other.GetComponent<GameManager>().TakeDamage(damageToDeal);
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isActive = true;
            StartCoroutine(DamageTimer(other.GetComponent<GameManager>()));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = false;
        }
    }

    IEnumerator DamageTimer(GameManager manager)
    {
        while(isActive == true)
        {
            if(GameManager.playerState == GameManager.PlayerState.Playing)
            {
                manager.TakeDamage(damageToDeal);
                yield return new WaitForSeconds(damageTimer);
            }
        }
        

    }
}
