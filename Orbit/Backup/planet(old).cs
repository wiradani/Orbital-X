using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class planet : MonoBehaviour {
    public int hp;
    public int maxhp;
    public GameObject musuh;
    public GameObject[] turrets;
    public Text HPText;
   
	// Use this for initialization
	void Start () {
        hp = 20;
        maxhp = 20;

        musuh = GameObject.FindGameObjectWithTag("musuh");
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X)) upgrade();
	}
    void OnTriggerStay2D(Collider2D col) {

        if (col.GetComponent<musuh>() != null)
        {
            ModifyHP(-1);
            if (hp == 0)
            {
                weaponbase layer0 = GameObject.FindObjectOfType<weaponbase>();
                layer0.dead() ;
                weapbaselayer1 layer1 = GameObject.FindObjectOfType<weapbaselayer1>();
                layer1.dead();

                GameManager gamemanager = GameObject.FindObjectOfType<GameManager>();
                gamemanager.GameOver();

            }
        }
    }
    void upgrade()
    {
        foreach(GameObject turret in turrets)
        {
            Debug.Log(turret.activeSelf.ToString());
            if (turret.activeSelf == false)
            {
                turret.SetActive(true);
               
                weapon weapon = turret.GetComponent<weapon>();
                StartCoroutine(weapon.cycle());
                break;
            }
        }
        
    }
    public void ModifyHP(int value)
    {
        hp += value;
        HPText.text = hp.ToString() + "/" + maxhp.ToString();
    }
}
