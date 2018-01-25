using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
    float z;
    public GameObject musuh;
    public GameObject child;
    public GameObject child1;
    
    GameManager gamemanager;

    public float rangemin = 0f, rangemax = 1f;
	public float interval = 7f; // defaultnya 3 detik. Ganti aja
    public float interval1 = 7f;
	// Use this for initialization
	void Start () {
        gamemanager = GameObject.FindObjectOfType<GameManager>();
		StartCoroutine(SpawnCycle());
        StartCoroutine(SpawnCycle1());
    }
	
	// Update is called once per frame
	void Update () {
        if (!gamemanager.paused)
           transform.localRotation = Quaternion.Euler(0, 0, z += 1);
        
    }
    

	IEnumerator SpawnCycle(){
        if (!gamemanager.paused)
        {
            if (gamemanager.newgame == true)
            {
                yield return new WaitForSeconds(Random.Range(0f, 1f));
                gamemanager.newgame = false;
            }
            GameObject spawn = Instantiate(musuh, child.transform.position, Quaternion.identity)as GameObject;
            musuh x = spawn.GetComponent<musuh>();
            x.SetHealth();
            if (gamemanager.score % 50 == 0)
            {
                 //kalau skor udh sampai 50, interval berkurang
                if (interval <= 0.8f) interval = 0.8f;
                else interval -= 0.15f;
            }
            
        }
        yield return new WaitForSeconds(interval + Random.Range(0f, 2f));
        StartCoroutine(SpawnCycle());
    }
    IEnumerator SpawnCycle1()
    {
        
        if (!gamemanager.paused)
        {
            if (gamemanager.newgame == true)
            {
                yield return new WaitForSeconds(Random.Range(1f, 2f));
                gamemanager.newgame = false;
            }
            GameObject spawn = Instantiate(musuh, child1.transform.position, Quaternion.identity) as GameObject;
            musuh x = spawn.GetComponent<musuh>();
            x.SetHealth();
            if (gamemanager.score % 150 == 0)
            {
                 //kalau skor udh sampai 50, interval berkurang
                if (interval1 <= 0.7f) interval1 = 0.7f;
                else interval1 -= 0.15f;
            }
            
        }
        yield return new WaitForSeconds(interval1 + Random.Range(0f, 0.5f));
        StartCoroutine(SpawnCycle1());
    }
}
