using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC : MonoBehaviour {

    public Animator anim;
    public float health;
    [SerializeField] HealthManager hManager;
    Quaternion targetRot;


	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {

        hManager.loseHealth();
        //Handles Movement
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            transform.Translate(0,0, 25 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            anim.SetBool("backwards", true);
            transform.Translate(0, 0, -25 * Time.deltaTime);
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
		//Handles Jumping
		if (Input.GetKey(KeyCode.Space) && GetComponent<Rigidbody>().transform.position.y <= 0.5f) {
			Vector3 jump = new Vector3 (0.0f, 200.0f, 0.0f);
            anim.SetBool("jumped", true);
            GetComponent<Rigidbody> ().AddForce (jump);
		}

        //Handles Attacking
        //Left Mouse - Melee
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("leftClick", true);
        }
        else
            anim.SetBool("leftClick", false);

		if(GetComponent<Rigidbody>().transform.position.y >= 10.0f)
		{
			Vector3 gravity = new Vector3 (0f,-100f,0f);
			GetComponent<Rigidbody> ().AddForce (gravity);
		}
    }


    public void takeDamage(float d)  //take Damage
    {
        health -= d;
    }
}
