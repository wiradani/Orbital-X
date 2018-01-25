using UnityEngine;
using System.Collections;

public class maincore : MonoBehaviour {
    GameManager gamemanager;
	// Use this for initialization
	void Start () {
        gamemanager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!gamemanager.paused)
        {
            Vector3 mouse = Input.mousePosition;
            var screen = Camera.main.WorldToScreenPoint(transform.position);
            mouse = new Vector3(mouse.x - screen.x, mouse.y - screen.y);
            float angle = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
