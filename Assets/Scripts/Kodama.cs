using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Kodama : MonoBehaviour {

    [SerializeField] Transform destination;
    [SerializeField] MC MCScript;
    NavMeshAgent navMeshAgent;

    public int health;

    private Animator anim;

    public Slider healthbar;
    public Image filHealth;

    private float time;

    // Use this for initialization
    void Start () {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        health = 100;
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if(Vector3.Distance(this.transform.position, destination.transform.position) <= 50) //if player walks near
        {
            setDestination();
            anim.SetInteger("state", 1);
        }
        else
            anim.SetInteger("state", 0);

        if (Vector3.Distance(this.transform.position, destination.transform.position) <= 2) //player is within attack zone
        {
            if(time < 1)
                time += Time.deltaTime;
            else
                MCScript.takeDamage(2);
        }

        healthbar.value = health;
        filHealth.color = Color.Lerp(Color.red, Color.green, health/100f);

        checkIfDead();

    }


    void setDestination() //go to player
    {
        Vector3 targetVector = destination.transform.position;
        navMeshAgent.SetDestination(targetVector);
    }

    public void takeDamage(int d)  //take Damage
    {
        health -= d;
    }

    private void checkIfDead()//check if alive or not
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
