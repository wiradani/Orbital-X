using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	public float shieldDuration = 5f;
	void Start(){
		StartCoroutine(Dead());
	}
	IEnumerator Dead(){
		yield return new WaitForSeconds(shieldDuration);
		Destroy(gameObject);
	}
}
