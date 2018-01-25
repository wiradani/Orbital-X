using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
    public GameManager gamemanager;
    public GameObject tutorWindow;
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public GameObject dialog4;
    public GameObject dialog5;
    public GameObject dialog6;
    public GameObject dialog7;
    public GameObject dialog8;
    public bool tutorPaused;
    public GameObject tSpawn;
    // Use this for initializations
    void Awake()
    {
        gamemanager = GameObject.FindObjectOfType<GameManager>();
        gamemanager.paused=true;
        tutorPaused = true;
    }
	void Start () {
        StartCoroutine(TutorFlow());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator TutorFlow()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            tutorWindow.SetActive(true);
            dialog1.SetActive(true);
            yield return null;
        }
        dialog1.SetActive(false);
        gamemanager.paused = false;
        FirstWave();
        yield return new WaitForSeconds(3f);
        dialog2.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            gamemanager.paused = true;
            yield return null;
        }
        dialog2.SetActive(false);
        gamemanager.paused = false;
        yield return new WaitForSeconds(2f);
        All();
        yield return new WaitForSeconds(3f);
        dialog3.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            gamemanager.paused = true;
            yield return null;
        }
        dialog3.SetActive(false);
        gamemanager.paused = false;
        yield return new WaitForSeconds(2f);
        All();
        yield return new WaitForSeconds(3f);
        dialog4.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            gamemanager.paused = true;
            yield return null;
        }
        dialog4.SetActive(false);
        gamemanager.paused = false;
        yield return new WaitForSeconds(3f);
        dialog5.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            gamemanager.paused = true;
            yield return null;
        }
        dialog5.SetActive(false);
        gamemanager.paused = false;
        yield return new WaitForSeconds(3f);
        dialog6.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            gamemanager.paused = true;
            yield return null;
        }
        dialog6.SetActive(false);
        gamemanager.paused = false;
        yield return new WaitForSeconds(3f);
        dialog7.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            gamemanager.paused = true;
            yield return null;
        }
        dialog7.SetActive(false);
        gamemanager.paused = false;
        yield return new WaitForSeconds(3f);
        dialog8.SetActive(true);
        while (!Input.GetMouseButtonDown(0))
        {
            gamemanager.paused = true;
            yield return null;
        }
        dialog8.SetActive(false);
        gamemanager.paused = false;
        yield return new WaitForSeconds(3f);
        tutorWindow.SetActive(false);
        Application.LoadLevel(1);

    }
    void FirstWave()
    {
        tutorSpawn tSpawn = GameObject.FindObjectOfType<tutorSpawn>();
        tSpawn.Spawn1();
        
    }
    void All()
    {
        tutorSpawn tSpawn = GameObject.FindObjectOfType<tutorSpawn>();
        tSpawn.AllSpawn();
    }
    
}
