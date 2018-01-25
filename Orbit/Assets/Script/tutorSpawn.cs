using UnityEngine;
using System.Collections;

public class tutorSpawn : MonoBehaviour {
    public GameObject spwn1;
    public GameObject spwn2;
    public GameObject spwn3;
    public GameObject spwn4;
    public GameObject musuh;
    Tutorial tutor;
    // Use this for initialization
    void Start () {
        tutor = GameObject.FindObjectOfType<Tutorial>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void AllSpawn()
    {
        Spawn1();
        StartCoroutine(Spawn2());
        StartCoroutine(Spawn3());
        StartCoroutine(Spawn4());
    }
    public void Spawn1()
    {
        
            GameObject spawn = Instantiate(musuh, spwn1.transform.position, Quaternion.identity) as GameObject;
            musuh x = spawn.GetComponent<musuh>();
            x.SetHealth();
    }
    public IEnumerator Spawn2()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        GameObject spawn = Instantiate(musuh, spwn2.transform.position, Quaternion.identity) as GameObject;
        musuh x = spawn.GetComponent<musuh>();
        x.SetHealth();
    }
    public IEnumerator Spawn3()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 2f));
        GameObject spawn = Instantiate(musuh, spwn3.transform.position, Quaternion.identity) as GameObject;
        musuh x = spawn.GetComponent<musuh>();
        x.SetHealth();
    }
    public IEnumerator Spawn4()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        GameObject spawn = Instantiate(musuh, spwn4.transform.position, Quaternion.identity) as GameObject;
        musuh x = spawn.GetComponent<musuh>();
        x.SetHealth();
    }
}
