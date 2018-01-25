using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BombSkill : MonoBehaviour {
    float sec = 30;
    public Image bombEffect;
    public Image bombCD;
    public Text coolDownText;
    void Start()
    {
        

    }

    void Update()
    {
        if (sec <= 0)
        {
            CancelInvoke();
            bombCD.enabled = false;
            sec = 30;
        }
    }
    public void SummonBomb(){
        if (sec == 30)
        {
            musuh[] enemies = GameObject.FindObjectsOfType<musuh>();
            foreach (musuh _enemy in enemies)
            {
                _enemy.ReduceHealthMeteor();
            }
            InvokeRepeating("CoolDown", 0.1f, 0.1f);
            StartCoroutine(Cycle());
            bombCD.enabled = true;
        }
        else
        {
            coolDownText.text = "Cooldown : " + sec.ToString("F0");
            StartCoroutine(CycleCD());

        }
    }
    void CoolDown()
    {
        sec -= 0.1f;
        Debug.Log(sec.ToString());
    }
    public IEnumerator Cycle()
    {
        byte x = 150;
        bombEffect.color = new Color32(255, 0, 0, x);
        while (bombEffect.color.a>0)
        {
            bombEffect.color = new Color32(255, 0, 0, x-=1);
            yield return null;
        }    
    }
    public IEnumerator CycleCD()
    {
        coolDownText.enabled = true;
        yield return new WaitForSeconds(1f);
        coolDownText.enabled = false;
    }
    
}
