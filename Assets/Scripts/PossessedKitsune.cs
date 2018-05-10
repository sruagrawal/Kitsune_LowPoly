using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PossessedKitsune : MonoBehaviour {

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
        anim.SetInteger("state", 0);
    }
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(this.transform.position, destination.transform.position) <= 100) //if player walks near
        {
            detAction();
            anim.SetInteger("state", 1);
        }
        else
            anim.SetInteger("state", 0);

        healthbar.value = health;
        filHealth.color = Color.Lerp(Color.red, Color.green, health / 100f);

        checkIfDead();
    }

    void detAction()
    {
        if (health >= 0)
        {
            setDestination();
            if(Vector3.Distance(this.transform.position, destination.transform.position) <= 7)
            {
                meleeAttack();
            }
        }
        else
        {
            if (Vector3.Distance(this.transform.position, destination.transform.position) <= 30)
            {
                setDestination();
            }
            else
            {
                fireAttack();
            }
        }
    }

    void setDestination() //go to player
    {
        Vector3 targetVector = destination.transform.position;
        navMeshAgent.SetDestination(targetVector);
        anim.SetInteger("state", 1);
    }

    public void takeDamage(int d)  //take Damage
    {
        health -= d;
    }

    private void checkIfDead()//check if alive or not
    {
        if (health <= 0)
        {
            MCScript.kitsFreed++;
            Destroy(gameObject);
        }
    }

    private void fireAttack()
    {
        
    }
    private void meleeAttack()
    {
        if (time < 3)
            time += Time.deltaTime;
        else
        {
            anim.SetInteger("state", 4);
            MCScript.takeDamage(10);
            time = 0;
        }

    }

   

}
