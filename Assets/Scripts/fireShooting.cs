using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireShooting : MonoBehaviour {

    public Rigidbody fire;
    public Transform fireTransform;
    public Slider slider;
    public float maxLaunchForce;
    public float minLaunchForce;
    public Animator anim;


    private float launchForce;
    private bool fired;

	
	void Update () {

        slider.value = minLaunchForce;

        if(launchForce >= maxLaunchForce && !fired)  //max charge but not fired
        {
            launchForce = maxLaunchForce;
            Fire();
        }
        else if(Input.GetMouseButtonDown(1))  //pressed fire for first time
        {
            fired = false;
            launchForce = minLaunchForce;
        }
        else if(Input.GetMouseButton(1) && !fired) //holding fire button
        {
            launchForce += 30 * Time.deltaTime;
            slider.value = launchForce;
        }
        else if(Input.GetMouseButtonUp(1) && !fired) //release button
        {
            anim.SetInteger("state", 5);
            Fire();
        }
	}

    void Fire()
    {
        fired = true;

        Rigidbody instance = Instantiate(fire, fireTransform.position, fireTransform.rotation) as Rigidbody;

        instance.velocity = launchForce * fireTransform.forward;

        launchForce = minLaunchForce;
    }

}
