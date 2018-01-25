using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class planet : MonoBehaviour {
    public int hp;
    public int maxhp;
    public GameObject musuh;
    
    public Text HPText;
   
	// Use this for initialization
	void Start () {
        hp = 5;
        maxhp = 5;
        HPText.text = hp.ToString() + "/" + maxhp.ToString();
        musuh = GameObject.FindGameObjectWithTag("musuh");
        
        
	}
	
	// Update is called once per frame
	void Update () {
        
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
    
    public void ModifyHP(int value)
    {
        hp += value;
        HPText.text = hp.ToString() + "/" + maxhp.ToString();
    }
}
