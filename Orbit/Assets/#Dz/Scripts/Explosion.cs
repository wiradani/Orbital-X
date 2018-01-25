using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public void Dead(){
		Destroy(gameObject.transform.parent.gameObject);
	}
}
