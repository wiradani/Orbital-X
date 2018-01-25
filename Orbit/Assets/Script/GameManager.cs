using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    public bool newgame;
    public bool paused;
    public string turret;
    public Text scoreText;
    public int score=0;
    public Text coinText;
    public int coin=0;
    public GameObject pauseWindow;
    public GameObject gameOverWindow;
    public GameObject pauseButton;
    public Text endScore;
    

    // Use this for initialization
    void Awake () {
        newgame = true;
    }
    void Start () {
        Screen.orientation = ScreenOrientation.Landscape;
        PlayerPrefs.SetInt("BossCount", 0);
        endScore.text = (score + coin).ToString();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GameRestart()
    {
        Application.LoadLevel(1);
        Time.timeScale = 1f;
    }
    public void GameMenu()
    {
        Application.LoadLevel(0);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        paused = true;
        gameOverWindow.SetActive(true);
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        
        
    }

    public void SetTurret(string x)
    {
        int cost = 0;
        turret = x;
        if (turret == "turret1") cost = 5;
        if (turret == "turret2") cost = 10;
        if (turret == "turret3") cost = 15;
        if (coin>=cost)
        {
            TurretInput[] turrets = GameObject.FindObjectsOfType<TurretInput>();
            foreach (TurretInput turretinput in turrets)
            {
                if (!turretinput.turret1.activeSelf && !turretinput.turret2.activeSelf && !turretinput.turret3.activeSelf)
                {

                    SpriteRenderer sr = turretinput.gameObject.GetComponent<SpriteRenderer>();
                    CircleCollider2D cc = turretinput.gameObject.GetComponent<CircleCollider2D>();
                    sr.enabled = true;
                    StartCoroutine(ColorCycle());
                    cc.enabled = true;
                    
                    
                    paused = true;
                    Time.timeScale = 0f;

                }
            }
        }
        else
        {
            NoGold noGold = GameObject.FindObjectOfType<NoGold>();
            StartCoroutine(noGold.cycle());

        }
    }

    public void HideTurret()
    {
        TurretInput[] turrets = GameObject.FindObjectsOfType<TurretInput>();
        foreach (TurretInput turretinput in turrets)
        {
            SpriteRenderer sr = turretinput.gameObject.GetComponent<SpriteRenderer>();
            CircleCollider2D cc = turretinput.gameObject.GetComponent<CircleCollider2D>();
            sr.enabled = false;
            cc.enabled = false;
            paused = false;
            Time.timeScale = 1f;
        }
    }

    public void ModifyScore(int value)
    {

        score += value;
        scoreText.text = "Score : " + score.ToString();
        endScore.text = (score + coin).ToString();
    }

    public void Modifycoin(int value)
    {
        coin += value;
        coinText.text = "  : " + coin.ToString();
    }

    public void GamePause()
    {
        paused = true;
        pauseWindow.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void GameResume()
    {
        paused = false;
        pauseWindow.SetActive(false);
        Time.timeScale = 1f;
    }
    public IEnumerator ColorCycle()
    {
        
        TurretInput[] turrets = GameObject.FindObjectsOfType<TurretInput>();
        foreach (TurretInput turretinput in turrets)
        {
            SpriteRenderer sr = turretinput.gameObject.GetComponent<SpriteRenderer>();
            byte b = 255;
            sr.color = new Color32(255, 255, b, 255);
            while (b > 0)
            {
                sr.color = new Color32(255, 255, b -= 5, 255);
                yield return null;
            }
            while (b == 0)
            {
                sr.color = new Color32(255, 255, b += 5, 255);
                yield return null;
            }
        }
        StartCoroutine(ColorCycle());
    }

}
