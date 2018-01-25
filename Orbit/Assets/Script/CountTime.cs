using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountTime : MonoBehaviour {
    public int sec = 0;
    public int minute = 0;
    public Text TimeText;

	// Use this for initialization
	void Start () {
        TimeText.text = minute.ToString() + " : " + sec.ToString();
        InvokeRepeating("secondloop", 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (sec == 61)
        {
            minute++;
            sec = 0;
        }
        TimeText.text = minute.ToString() + " : " + sec.ToString();   
        
        
        
        
    }
    void secondloop()
    {
        sec+=1;
    }
}
