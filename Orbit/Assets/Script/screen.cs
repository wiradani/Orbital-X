using UnityEngine;
using System.Collections;

public class screen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Camera.main.transform.position = new Vector3(15f, 11f, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
