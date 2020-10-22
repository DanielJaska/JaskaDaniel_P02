using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnterRange : MonoBehaviour
{
    private EnemyController enemyController;

    // Start is called before the first frame update
    void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //enemyController.GetTarget(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //enemyController.LoseTarget();
    }
}
