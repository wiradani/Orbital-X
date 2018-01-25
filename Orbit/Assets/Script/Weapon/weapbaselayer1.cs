using UnityEngine;
using System.Collections;

public class weapbaselayer1 : MonoBehaviour
{
    float z;
    public float speed;
    GameManager gamemanager;

    // Use this for initialization
    void Start()
    {
        gamemanager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamemanager.paused)
        {
            transform.localRotation = Quaternion.Euler(0, 0, z = z + speed);
        }
    }

    public void dead()
    {
        Destroy(gameObject);
    }

}
