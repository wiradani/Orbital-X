using UnityEngine;
using System.Collections;

public class maingun : MonoBehaviour
{
    public GameObject lineoffire;
    GameManager gamemanager;
    public GameObject musuh;
    float z;
    public float frequency;
    public float midparticle;

    // Use this for initialization
    void Start()
    {
        gamemanager = GameObject.FindObjectOfType<GameManager>();
        musuh = GameObject.FindGameObjectWithTag("musuh");
        StartCoroutine(cycle());
    }

    // Update is called once per frame
    void Update()
    {

    }
   
    IEnumerator cycle()
    {

        yield return new WaitForSeconds(frequency);
        if (!gamemanager.paused)
        {
            z = transform.parent.transform.localRotation.eulerAngles.z;
            Instantiate(lineoffire, transform.position, Quaternion.Euler(0, 0, z + midparticle));
        }
        StartCoroutine(cycle());
    }
}
