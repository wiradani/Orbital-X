using UnityEngine;
using System.Collections;

public class exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Input.GetKey("escape"))
			Application.Quit();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
