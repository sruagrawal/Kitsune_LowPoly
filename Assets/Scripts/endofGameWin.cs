using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endofGameWin : MonoBehaviour {


    [SerializeField] MC MCScript;

    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(MCScript.kitsFreed == 3)
        {
            SceneManager.LoadScene("GameOverWin");
        }
    }
}
