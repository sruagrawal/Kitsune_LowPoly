using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MC : MonoBehaviour {

    public Animator anim;
    public int health;
    [SerializeField] HealthManager hManager;
    Quaternion targetRot;
    public int kitsFreed = 0;

    private float timescale = 1;

    private Transform enemy;

	// Use this for initialization
	void Start () {
        health = 100;
        anim.SetInteger("state", 0);
	}
	
	// Update is called once per frame
	void Update () {
        GetEnemiesInRange();
        if (hManager)
            hManager.loseHealth();
        //Handles Movement
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("state", 1);
            transform.Translate(0,0, 20 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("state", 2);
            transform.Translate(0, 0, -20 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            Quaternion rot = transform.rotation*Quaternion.AngleAxis(90, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 1.5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion rot = transform.rotation*Quaternion.AngleAxis(-90, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 1.5f);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1-timescale;
            timescale = Time.timeScale;
        }


		//Handles Jumping
		if (Input.GetKey(KeyCode.Space) && GetComponent<Rigidbody>().transform.position.y <= 0.5f) {
			Vector3 jump = new Vector3 (0.0f, 200f, 0.0f);
            anim.SetInteger("state", 3);
            GetComponent<Rigidbody> ().AddForce (jump);
		}

        //Handles Attacking
        //Left Mouse - Melee
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetInteger("state", 4);
            
                if (enemy)
                {
                    Kodama k = enemy.GetComponent<Kodama>();
                    if (k)
                        k.takeDamage(5);

                    PossessedKitsune p = enemy.GetComponent<PossessedKitsune>();
                    if (p)
                        p.takeDamage(5);
                }
            
        }

        

        //jump gravity
		if(GetComponent<Rigidbody>().transform.position.y >= 6f)
		{
			Vector3 gravity = new Vector3 (0f,-100f,0f);
			GetComponent<Rigidbody> ().AddForce (gravity);
		}

        if (Input.anyKey == false)
        {
            anim.SetInteger("state", 0);
        }

        //check if health is less than 0
        checkIfDead();

    }


    public void takeDamage(int d)  //take Damage
    {
        health -= d;
    }

    void GetEnemiesInRange() //get enemies in front of us for melee attack
    {
        foreach(Collider c in Physics.OverlapSphere(transform.position + transform.forward*3f, 3f))
        {
            if (c.gameObject.CompareTag("Enemy"))
            {
                enemy = c.transform;
            }
        }
    }


    private void checkIfDead()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Death_GO");
        }
    }


}
