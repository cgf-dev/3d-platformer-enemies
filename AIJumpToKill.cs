using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIJumpToKill : MonoBehaviour
{
    // Variables
    public int enemyDamage = 1;
    public int enemyHitRange = 1;

    public GameObject plimpBounce;

    void Start()
        {
            InvokeRepeating("EnemyAttack", 2.0f, 3.0f);
        }



    public void OnTriggerEnter(Collider withAI)
        {
            if (withAI.gameObject.tag == "Player")
            {
            // The following 4 lines of code enable the death animation to play for 
            // 2 seconds without damaging the player
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);

            Destroy(transform.gameObject, 2.0f);

            Vector3 Bounce = new Vector3(0, 200, 0);
            plimpBounce.GetComponent<Rigidbody>().AddForce(Bounce);


        }

    }


    void EnemyDie()
    {
        Debug.Log("Enemy Died");
    }

    void EnemyAttack()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 origin = transform.position;
        
        

        if (Physics.Raycast(origin, forward, out hit, enemyHitRange))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                hit.transform.gameObject.SendMessage("PlayerTakesDamage", 1);

            }
        }
    }
}
