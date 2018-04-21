using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kodama : MonoBehaviour {

    [SerializeField] Transform destination;
    [SerializeField] MC MCScript;
    NavMeshAgent navMeshAgent;

    public int health;

    private Animator anim;

    // Use this for initialization
    void Start () {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
        setDestination();
        
    }


    void setDestination() //go to player
    {
        Vector3 targetVector = destination.transform.position;
        navMeshAgent.SetDestination(targetVector);
        if (navMeshAgent.transform.position != targetVector)
            anim.SetBool("walking", true);
        else
            anim.SetBool("walking", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MC")
        {
            MCScript.takeDamage(5f);
        }
    }
}
