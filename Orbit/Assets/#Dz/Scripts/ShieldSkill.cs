using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShieldSkill : MonoBehaviour {
	planet planet;
    public Image shieldCD;
    public Text coolDownText;
    float sec = 30;
	void Start(){
		planet = GameObject.FindObjectOfType<planet>();
        
	}

    void Update()
    {
        if (sec<=0)
        {
            CancelInvoke();
            shieldCD.enabled = false;
            sec = 30;
        }
    }
  
	public void SummonShield(){
        if (sec==30)
        {
            Instantiate(Resources.Load("Shield"), planet.transform.position, Quaternion.identity);
            InvokeRepeating("CoolDown", 0.1f, 0.1f);
            Debug.Log(sec.ToString());
            
            shieldCD.enabled=true;
        }
        else
        {
            coolDownText.text = "Cooldown : " + sec.ToString("F0");
            StartCoroutine( Cycle());
            
        }
    }

    void CoolDown()
    {
        sec-=0.1f;
        Debug.Log(sec.ToString());
    }
    public IEnumerator Cycle()
    {
        coolDownText.enabled = true;
        yield return new WaitForSeconds(1f);
        coolDownText.enabled = false;
    }
}
