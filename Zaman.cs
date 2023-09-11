using UnityEngine;
using UnityEngine.UI;

public class Zaman : MonoBehaviour
{
    int max = 36;
    private int timeLeft = 36;
    private Slider zaman;
    PlayerSaglikDurumu playerSaglikDurumu;
    UI_Scripts uiScripts;

    private void Awake()
    {
        zaman = GameObject.Find("Slider").GetComponent<Slider>();
        zaman.interactable = false; // Zaman slider'ý baþlangýçta dokunulmaz olsun
        playerSaglikDurumu = FindObjectOfType<PlayerSaglikDurumu>();
        uiScripts = FindObjectOfType<UI_Scripts>();
    }

    void Start()
    {
        InvokeRepeating("Countdown", 1.0f, 1.0f);
    }

    void Countdown()
    {
        if (!OyunSabitleri.OyunDurumu)
        {
            timeLeft--;
            zaman.value = timeLeft;

            if (timeLeft % 6 == 0)
            {
                playerSaglikDurumu.gecerliSaglik--;
                uiScripts.SaglikDurumuGuncelle();
                if (playerSaglikDurumu.gecerliSaglik == 0)
                {
                    FindObjectOfType<MenuController>().GameOver();
                }
            }
        }
    }

    public void ZamanSlider()
    {
        zaman.maxValue = timeLeft;
        zaman.minValue = 0;
        zaman.wholeNumbers = true;
        zaman.value = zaman.maxValue;
        zaman.interactable = true; // Zaman slider'ý güncellendiðinde dokunulabilir hale gelsin
    }

    public void ZamanEkle()
    {
        if (zaman.value <= zaman.maxValue)
        {
            timeLeft += 12;
            if (timeLeft > max)
            {
                timeLeft = max;
            }
            zaman.value = timeLeft;
            uiScripts.SaglikDurumuGuncelle();
        }
    }

    public void ZamanCikart()
    {
        timeLeft -= 6;
        zaman.value = timeLeft;
        uiScripts.SaglikDurumuGuncelle();
    }
}