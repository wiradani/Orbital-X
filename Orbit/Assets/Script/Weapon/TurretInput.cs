using UnityEngine;
using System.Collections;

public class TurretInput : MonoBehaviour {
    public GameObject turret1, turret2, turret3;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        
        
        
        if (gameManager.turret=="turret1")
        {
            if (gameManager.coin >= 5)
            {
                gameManager.Modifycoin(-5);
                turret1.SetActive(true);
                Turret1 tur1 = turret1.GetComponent<Turret1>();

                StartCoroutine(tur1.cycle());
                gameManager.HideTurret();
            }
            else gameManager.HideTurret();
            
        }
        else if (gameManager.turret == "turret2")
        {
            if (gameManager.coin >= 10)
            {
                gameManager.Modifycoin(-10);
                turret2.SetActive(true);
                weapon tur2 = turret2.GetComponent<weapon>();

                StartCoroutine(tur2.cycle());
                gameManager.HideTurret();
            }
            else gameManager.HideTurret();
        }
        else if (gameManager.turret == "turret3")
        {
            if (gameManager.coin >= 15)
            {
                gameManager.Modifycoin(-15);
                turret3.SetActive(true);
                Turret3 tur3 = turret3.GetComponent<Turret3>();

                StartCoroutine(tur3.cycle());
                gameManager.HideTurret();
            }
            else gameManager.HideTurret();
        }

        print("Input");
       
    }
}
