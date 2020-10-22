using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRecycle : MonoBehaviour
{
    [SerializeField] Level01Controller levelController;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Ball ball;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            float randomX = Random.Range(-45f, 45f);
            float randomZ = Random.Range(-45f, 45f);
            
            levelController.IncreaseScore(-1);
            GameObject temp = Instantiate(ball.gameObject, spawnPoint);
            temp.transform.position = new Vector3(randomX, 2, randomZ);
            temp.GetComponent<Ball>().Spawn();
            Destroy(other.gameObject);
        }
    }
}
