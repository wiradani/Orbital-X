using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Coin : MonoBehaviour
{
    Text coinText;
    int coin;

    public void Modifycoin(int value)
    {
        coin += value;
        coinText.text = "Coin : " + coin.ToString();
    }
    // Use this for initialization
    void Start()
    {
        coinText = GetComponent<Text>();
        coin = 0;


    }

    // Update is called once per frame
    void Update()
    {

    }

}

