using UnityEngine;
using System.Collections;

public class EnemyKamikaze : musuh {

	// Use this for initialization
	void Start () {
		
		base.Start();
		explosionType = Resources.Load("Explosion Medium") as GameObject;
		health = 3;
		coinVal = 5;
		scoreval = 50;
        SetHealthKroco();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}
	void OnTriggerStay2D(Collider2D col){
		base.OnTriggerStay2D(col);
	}
    public void SetHealthKroco()
    {
        health += PlayerPrefs.GetInt("BossCount");
        coinVal += PlayerPrefs.GetInt("BossCount");
        scoreval *= (PlayerPrefs.GetInt("BossCount") + 1);
    }
}
