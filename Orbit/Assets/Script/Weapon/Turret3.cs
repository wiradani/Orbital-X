using UnityEngine;
using System.Collections;

public class Turret3 : MonoBehaviour
{
    public GameObject lineoffire;
    public int weaphp = 3;
    public GameObject musuh;
    float z;
    public float frequency;
    public float midparticle;
    GameManager gamemanager;
    public GameObject explosionType;

    // Use this for initialization
    public void Start()
    {
        explosionType = Resources.Load("Explosion Small") as GameObject;
        gamemanager = GameObject.FindObjectOfType<GameManager>();
        musuh = GameObject.FindGameObjectWithTag("musuh");
        StartCoroutine(cycle());
        StartCoroutine(Duration());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator Duration()
    {
        if (!gamemanager.paused)
        {
            yield return new WaitForSeconds(20f);
            Instantiate(explosionType, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            RefreshHP(3);

        }
    }
    void OnTriggerStay2D(Collider2D col)
    {

        if (col.GetComponent<musuh>() != null)
        {
            weaphp -= 1;
            if (weaphp == 0)
            {
                
                RefreshHP(3);
                gameObject.SetActive(false);
            }
        }
    }
    public IEnumerator cycle()
    {

        yield return new WaitForSeconds(frequency);
        if (!gamemanager.paused)
        {
            z = transform.parent.transform.parent.transform.localRotation.eulerAngles.z;
            
            Instantiate(lineoffire, transform.position, Quaternion.Euler(0, 0, z + midparticle));
            


        }
        StartCoroutine(cycle());
    }
    public void RefreshHP(int hp)
    {
        weaphp = hp;
    }
}