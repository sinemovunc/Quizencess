using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    public Text scoreText;
    public Text trueQuestionText;
    public Text falseQuestionText;
    public Text altinText;
    public Text highScoreText;

    [SerializeField]
    public GameObject YouLose_Panel;
    [SerializeField]
    public GameObject Score_Panel;
    [SerializeField]
    public GameObject HighScore_Panel;
    [SerializeField]
    public GameObject GameOver_Canvas;

    private void Awake()
    {
        GameOver_Canvas.SetActive(false);
    }

    public void ScorePanelAc()
    {
        if (Score.score >= 50 && Score.score < Score.highScore)
        {
            ScorePanel();
        }
        else if (Score.score >= Score.highScore)
        {
            HighScorePanel();
        }
        else if (Score.score < 50)
        {
            YouLosePanel();
        }
    }

    public void HighScorePanel()
    {
        if (AudioChoices.LoadEffect() == 1)
        {
            AudioController.instance.SesEfektiCikar(2);
        }
        HighScore_Panel.SetActive(true);
        Score_Panel.SetActive(false);
        YouLose_Panel.SetActive(false);
        Score.highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text = Score.highScore.ToString();
    }

    public void YouLosePanel()
    {

        if (AudioChoices.LoadEffect() == 1)
        {
            AudioController.instance.SesEfektiCikar(4);
        }
        YouLose_Panel.SetActive(true);
        Score_Panel.SetActive(false);
        scoreText.text = Score.score.ToString();
    }

    public void ScorePanel()
    {

        if (AudioChoices.LoadEffect() == 1)
        {
            AudioController.instance.SesEfektiCikar(3);
        }
        Score_Panel.SetActive(true);
        HighScore_Panel.SetActive(false);
        YouLose_Panel.SetActive(false);
        trueQuestionText.text = SoruOyun.dogruSayisi.ToString();
        falseQuestionText.text = SoruOyun.yanlisSayisi.ToString();
        altinText.text = SoruOyun.soruSayisi.ToString();
        scoreText.text = Score.score.ToString();
    }
}
