using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreVolume : MonoBehaviour
{
    [SerializeField] Level01Controller _levelController;
    [SerializeField] int _pointValue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            _levelController.IncreaseScore(_pointValue);
            Destroy(other.gameObject);
        }
    }
}
