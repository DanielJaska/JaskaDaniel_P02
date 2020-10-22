using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPack : MonoBehaviour
{
    [SerializeField] float waitTime;
    [SerializeField] int healAmount;
    

    [Header("SelfStuff")]
    [SerializeField] GameObject visuals;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && other.GetComponent<GameManager>().CheckMaxHealth() == false)
        {
            DisableObject();
            other.GetComponent<GameManager>().TakeDamage(-healAmount);
        }
    }

    private void EnableObject()
    {
        visuals.SetActive(true);
        boxCollider.enabled = true;
    }

    private void DisableObject()
    {
        visuals.SetActive(false);
        boxCollider.enabled = false;
        collectSound.Play();
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(waitTime);
        EnableObject();
    }
}
