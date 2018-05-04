using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    [SerializeField] Image healthArc, healthStraight;
    [SerializeField] GameObject c;
    private MC main;

    public Color green, yellow, red;


    private void Start()
    {
        main = c.GetComponent<MC>();
    }

    public void loseHealth()
    {
        if(main.health>50)
        {
            healthStraight.enabled = true;
            float h = (main.health - 50)/ 50;
            healthStraight.fillAmount = h;
            healthStraight.color = Color.Lerp(Color.yellow, Color.green, h);
            healthArc.fillAmount = 1;
            healthArc.color = healthStraight.color;
        }
        else if(main.health==50)
        {
            healthArc.fillAmount = 1;
            healthStraight.enabled = false;
            healthArc.color = Color.yellow;
        }
        else
        {
            healthStraight.enabled = false;
            float h = main.health / 55;
            healthArc.fillAmount = h;
            healthArc.color = Color.Lerp(Color.red, Color.yellow, h); 
        }
    }
}
