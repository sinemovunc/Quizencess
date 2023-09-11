using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject CanlarPanel;
    public GameObject AyarlarPanel;
    public GameObject Shop_Panel;
    public GameObject GameOver_Canvas;
    public GameObject soruPanel;

    public void AyarlarAc()
    {
        AyarlarPanel.SetActive(true);
    }

    public void AyarlarKapat()
    {
        AyarlarPanel.SetActive(false);
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Game");
        OyunSabitleri.OyunDurumu = false;
        
    }

    public void YenidenOyna()
    {
        SceneManager.LoadScene("Game");
        Score.score = 0;
    }
    public void GameOver()
    {
        //GameOver_Canvas.SetActive(true);
        OyunSabitleri.OyunDurumu = true;
        StartCoroutine(ScorePanelAc());
        
    }

    public void OyunGeri()
    {
        FindObjectOfType<Pause>().OyunuDevamEttir();
        AyarlarPanel.SetActive(false);
    }

    public void OyunAyarlar()
    {
        OyunSabitleri.OyunDurumu = true;
        AyarlarPanel.SetActive(true);
    }

    public void Pause()
    {
        AyarlarPanel.SetActive(true);
        FindObjectOfType<Pause>().OyunuDurdur();
    }

    public void OyunaDevamEt()
    {
        AyarlarPanel.SetActive(false);
        FindObjectOfType<Pause>().OyunuDevamEttir();
       
    }

    public void Shop() 
    {
        Shop_Panel.SetActive(true);
    }

    public void ShopDon()
    {
        AyarlarPanel.SetActive(false);
    }

    IEnumerator ScorePanelAc()
    {
        yield return new WaitForSeconds(.2f);
        GameOver_Canvas.SetActive(true);
        FindObjectOfType<GameOver>().ScorePanelAc();
    }


}
