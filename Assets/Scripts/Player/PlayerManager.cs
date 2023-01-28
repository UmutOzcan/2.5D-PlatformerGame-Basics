using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //static olduğu için diğer scriptlerde de erişebiliriz
    public static int numberOfCoins;
    public TextMeshProUGUI numberOfCoinsText;

    public static int currentHealth = 100;
    public Slider healthBar;

    public static bool gameOver;
    //game over panelini kontrol etmek için
    public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCoins = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCoinsText.text = "COINS " + numberOfCoins;

        //update the slider value
        healthBar.value = currentHealth;

        //gam over 
        if(currentHealth < 0)
        {
            gameOver = true;
            GameOverPanel.SetActive(true);
            currentHealth = 100;
        }
        //eğer tüm düşmanlar ölmüşse
        if( FindObjectsOfType<Enemy>().Length == 0)
        {
            SceneManager.LoadScene(0);
            currentHealth = 100;
        }
    }
}

