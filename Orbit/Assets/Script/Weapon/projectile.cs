using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {
    public float speed;
    float x, y;
    public GameObject lineoffire;
    GameManager gamemanager;
	// Use this for initialization
	void Start () {
        gamemanager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!gamemanager.paused)
        {
            transform.localPosition = new Vector2(x += speed, 0);
            if (x > 30 || x < -30 || y > 30 || y < -30) Destroy(lineoffire);
        }
	}

    void OnTriggerStay2D(Collider2D col)
    {

        if (col.GetComponent<musuh>() != null)
        {
            Instantiate(Resources.Load("Explosion Small"), transform.position, Quaternion.identity);
            Destroy(lineoffire);
        }
    }
}
