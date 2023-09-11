using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public Text scoreText;
    public Text altinText;


    public static int score;
    public static int highScore ;
    public static int topGold;
    public static int NumberOfCoins;

    private void Awake()
    {
        PlayerPrefs.GetInt("Score", score);
        if (PlayerPrefs.HasKey("High Score"))
        {
            highScore = PlayerPrefs.GetInt("High Score");
        }
        if (PlayerPrefs.HasKey("ToplamAltin"))
        {
            topGold = PlayerPrefs.GetInt("ToplamAltin");
        }
    }
    void Start()
    {
        score = 0;
        NumberOfCoins = 0;
        scoreText.text = score.ToString();
        altinText.text = NumberOfCoins.ToString();
    }
      
    public void PuanKazan()
    {
        score++;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("High Score", highScore);
        }
        PlayerPrefs.SetInt("Score", score);
        scoreText.text = score.ToString();
    }

    public void AltinKazan()
    {
        NumberOfCoins++;
        altinText.text = NumberOfCoins.ToString();
        PlayerPrefs.SetInt("Altin", NumberOfCoins);
    }

    public void ToplamAltin()
    {
        topGold ++;
        topGold++;
        PlayerPrefs.SetInt("ToplamAltin", topGold);
    }

}
