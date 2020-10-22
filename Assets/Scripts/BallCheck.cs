using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCheck : MonoBehaviour
{
    [SerializeField] Ball ball;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            ball.HitEnemy(other);
        }
    }
}
