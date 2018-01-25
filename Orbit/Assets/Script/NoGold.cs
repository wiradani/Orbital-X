using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoGold : MonoBehaviour {
    Text noGold;
	// Use this for initialization
	void Start () {
        noGold = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public IEnumerator cycle()
    {
        noGold.enabled = true;
        yield return new WaitForSeconds(3f);
        noGold.enabled = false;
    }
}
