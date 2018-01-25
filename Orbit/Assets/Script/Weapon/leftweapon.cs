using UnityEngine;
using System.Collections;

public class leftweapon : MonoBehaviour
{
    public GameObject lineoffire;
    public int weaphp = 3;
    public GameObject musuh;
    float z;
    // Use this for initialization
    void Start()
    {
        musuh = GameObject.FindGameObjectWithTag("musuh");
        StartCoroutine(cycle());
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D col)
    {

        if (col.tag == "musuh")
        {
            weaphp -= 1;
            if (weaphp == 0) Destroy(gameObject);
        }
    }
    IEnumerator cycle()
    {

        yield return new WaitForSeconds(1.5f);
        z = transform.parent.transform.localRotation.eulerAngles.z;
        Instantiate(lineoffire, transform.position, Quaternion.Euler(0, 0, z+180));
        Instantiate(lineoffire, transform.position, Quaternion.Euler(0, 0, z + 165));
        Instantiate(lineoffire, transform.position, Quaternion.Euler(0, 0, z + 195));

        StartCoroutine(cycle());
    }
}
