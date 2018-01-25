using UnityEngine;
using System.Collections;

public class BossOne : musuh {
	float spawnKrocoInterval = 5f;
	// Use this for initialization
	void Start () {
		base.Start();
		explosionType = Resources.Load("Explosion Big") as GameObject;
		health = 50;
		coinVal = 50;
		scoreval = 700;
        SetHealthBoss();
		StartCoroutine(SpawnKroco());
	}
	
	// Update is called once per frame
	void Update () {
		base.FacingPlanet();
	}

	public override void Dead(){
        PlayerPrefs.SetInt("BossCount",(PlayerPrefs.GetInt("BossCount"))+1);
		Destroy(gameObject.transform.parent.transform.parent.gameObject);

	}

	IEnumerator SpawnKroco(){
		yield return new WaitForSeconds(spawnKrocoInterval);
        if (!gamemanager.paused)
        {
            
            Instantiate(Resources.Load("Kroco"), transform.position, Quaternion.identity);
            

        }
		StartCoroutine(SpawnKroco());
	}
    public void SetHealthBoss()
    {
        health *= (PlayerPrefs.GetInt("BossCount")+1);
        coinVal *= (PlayerPrefs.GetInt("BossCount") + 1);
        scoreval *= (PlayerPrefs.GetInt("BossCount") + 1);
    }
}
