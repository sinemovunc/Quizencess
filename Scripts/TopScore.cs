using UnityEngine.UI;
using UnityEngine;

public class TopScore : MonoBehaviour
{
    public Text scoreText;
    public Text altinText;

    void Start()
    {
        if (PlayerPrefs.HasKey("ToplamAltin"))
        {
            Score.topGold = PlayerPrefs.GetInt("ToplamAltin");
        }
        scoreText.text = " " +  PlayerPrefs.GetInt("High Score", 0);
        altinText.text = " " + PlayerPrefs.GetInt("ToplamAltin", 0);
    }
}
