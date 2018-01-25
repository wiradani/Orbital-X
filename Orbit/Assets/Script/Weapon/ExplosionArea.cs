using UnityEngine;
using System.Collections;

public class ExplosionArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Instantiate(Resources.Load("Explosion Small"), transform.position, Quaternion.identity);
        new WaitForSeconds(1f);
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    

        
            
        
    
}
