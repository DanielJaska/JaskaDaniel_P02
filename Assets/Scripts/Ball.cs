using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Level01Controller levelController;

    [SerializeField] float changeDuration;

    // Start is called before the first frame update
    public void Spawn()
    {
        levelController = FindObjectOfType<Level01Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AimedAt()
    {
        StartCoroutine(ChangeColorForSeconds());
    }

    IEnumerator ChangeColorForSeconds()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
        yield return new WaitForSeconds(changeDuration);
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        foreach(Collider col in Physics.OverlapSphere(transform.position, 3.01f))
        {
            if(col.tag == "Enemy")
            {
                HitEnemy(col);
            }
        }
    }

    public void HitEnemy(Collider enemy)
    {
        levelController.IncreaseScore(2);
        enemy.GetComponent<EnemyController>().EnemyDeath();
        //Destroy(enemy.gameObject);
    }
}
