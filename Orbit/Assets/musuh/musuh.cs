using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class musuh : MonoBehaviour {
	public int health = 1;
	public int scoreval = 10;
	public int coinVal = 1;
    public bool damaged;
	public GameObject explosionType;

	[HideInInspector]
	public planet planetlu;
	[HideInInspector]
	public GameObject weapon;



    public GameManager gamemanager;
    // Use this for initialization

	protected virtual void Start () {
		explosionType = Resources.Load("Explosion Small") as GameObject;
		planetlu = GameObject.FindObjectOfType<planet>();
        gamemanager = GameObject.FindObjectOfType<GameManager>();
		float angle = Mathf.Asin(transform.position.y/Vector2.Distance(transform.position,planetlu.gameObject.transform.position)) * Mathf.Rad2Deg;
        if (transform.position.x<0)
        {
			angle = Mathf.Asin(-(transform.position.y / Vector2.Distance(transform.position, planetlu.gameObject.transform.position))) * Mathf.Rad2Deg;
            angle = 180 + angle;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
        TrailRenderer tr = GetComponent<TrailRenderer>();
        tr.sortingOrder = -1;
    }

	protected virtual void FacingPlanet(){
		float angle = Mathf.Asin(transform.position.y/Vector2.Distance(transform.position,planetlu.gameObject.transform.position)) * Mathf.Rad2Deg;
		if (transform.position.x<0)
		{
			angle = Mathf.Asin(-(transform.position.y / Vector2.Distance(transform.position, planetlu.gameObject.transform.position))) * Mathf.Rad2Deg;
			angle = 180 + angle;
		}
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}
	
	// Update is called once per frame
	public void Update () {
        
        if (!gamemanager.paused)
        {
			transform.position = Vector2.MoveTowards(transform.position, planetlu.gameObject.transform.position, 0.1f);
        }
    }

    public void OnTriggerStay2D(Collider2D col)
    {
		if (col.GetComponent<projectile>() != null || col.GetComponent<ExplodeProjectile>()!=null  )
        {
			
			ReduceHealth();
        }
        else
        {
            if(col.GetComponent<weapon>()!=null || col.GetComponent<Shield>() != null || col.GetComponent<Turret3>() != null || col.GetComponent<Turret1>() != null)
            {
                health = 0;
                CheckHealth();
            }
            else
            {
                if(col.GetComponent<ExplosionArea>() != null)
                {
                    health -= 2;
                    CheckHealth();
                }
                else
                {
                    if(col.GetComponent<planet>() != null)
                    {
                        damaged = true;
                        health = 0;
                        CheckHealth();
                    }
                }
            }
        }
    }

	public void ReduceHealth(){
		health--;
		CheckHealth();
	}

	void CheckHealth(){
		if(health <= 0){
            if (!damaged)
            {
                gamemanager.Modifycoin(coinVal);
                gamemanager.ModifyScore(scoreval);
            }
            Instantiate(explosionType,transform.position,Quaternion.identity);
			
			CameraShake cS = GameObject.FindObjectOfType<CameraShake>();
			cS.shakeDuration = 0.2f;
            AudioManager.Main.PlayNewSound("Boom");
			Dead();
		}
	}

	public virtual void Dead(){
		Destroy(gameObject);
	}

    public void SetHealth()
    {
        health += PlayerPrefs.GetInt("BossCount");
        coinVal += PlayerPrefs.GetInt("BossCount");
        scoreval *= (PlayerPrefs.GetInt("BossCount")+1);
    }
    public void ReduceHealthMeteor()
    {
        health -= (1+PlayerPrefs.GetInt("BossCount"));
        CheckHealth();
    }
    
}
