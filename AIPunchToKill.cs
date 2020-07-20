using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPunchToKill : MonoBehaviour
{
    // Variables
    public int enemyMaxHealth = 4;
    public int enemyCurrentHealth;
    public int enemyDamage = 1;
    public int enemyHitRange = 1;


    // Allow the player to start with full health
    void Awake()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    void Start()
    {
        InvokeRepeating("EnemyAttack", 2.0f, 3.0f);
    }

    public void EnemyTakesDamage(int damage)
    {
        enemyCurrentHealth -= damage;
        Debug.Log("Enemy took damage");

        if (enemyCurrentHealth <= 0)
            EnemyDie();
    }


    void EnemyDie()
    {
        Debug.Log("Enemy Died");

        // Render AI harmless until death anim has been played
        foreach (Transform GameObject in transform) 
        gameObject.SetActive(false);

        Destroy(transform.gameObject, 2.0f);
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