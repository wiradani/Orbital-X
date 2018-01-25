using UnityEngine;
using System.Collections;

public class BossManager : MonoBehaviour {
	GameManager gM;
	planet planet;

	public float bossInterval = 100f; //interval antar bos
	// Use this for initialization
	void Start () {
		gM = GameObject.FindObjectOfType<GameManager>();
		planet = GameObject.FindObjectOfType<planet>();
		StartCoroutine(CheckScore());
	}
	
	IEnumerator CheckScore(){
        yield return new WaitForSeconds(bossInterval);
        if (GameObject.FindObjectOfType<BossOne>() == null && !gM.paused){
            
            GameObject boss = Instantiate(Resources.Load("Boss"),planet.transform.position,Quaternion.identity) as GameObject;
            
            boss.transform.parent = planet.transform;
			boss.transform.localScale = Vector2.one;
		}
        yield return new WaitForSeconds(20f);
		StartCoroutine(CheckScore());
	}
}
