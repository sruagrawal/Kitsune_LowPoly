using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireExplosion : MonoBehaviour {

    public ParticleSystem self;
    
    void Start ()
    {
        //Destroy(gameObject, 5f);
        self.Play(false);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (true)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);
            foreach (Collider c in colliders)
            {
                if (c.gameObject.CompareTag("Enemy"))
                {

                    Kodama kodHealth = c.gameObject.GetComponent<Kodama>();
                    if(kodHealth)
                        kodHealth.takeDamage(20);
                    PossessedKitsune p = c.gameObject.GetComponent<PossessedKitsune>();
                    if (p)
                        p.takeDamage(10);
                }
            }

            Destroy(gameObject);
        }
    }
}
