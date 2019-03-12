using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public NavMeshAgent agent;
    public GameObject target;

    public int health = 100;

    public int value = 20;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {

        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    private void Awake()
    {
        target = GameObject.Find("Endspace");    
    }

    private void Update()
    {
        agent.SetDestination(target.transform.position);
    }

    /*void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Exit")  
        {
            Destroy(gameObject);
            return;
        }
    }*/


    void OnTriggerEnter(Collider other)

    {
        if (other.name == "Endspace")

        {
            EndPath();
            return;

        }
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

}
