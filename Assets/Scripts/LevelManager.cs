using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {

	[SerializeField]private string nextLevel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void exit()
    {
        Application.Quit();
    }

    public void load(string level)
    {
        SceneManager.LoadScene(level); 
    }

	void OnTriggerEnter(Collider other)
	{
		this.load (nextLevel);
	}

}
