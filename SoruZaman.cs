using UnityEngine;
using UnityEngine.UI;

public class SoruZaman : MonoBehaviour
{
    public Slider soruZaman;
    private float sayac;
    private bool zamanDurduMu;

    public MenuController menuController;

    private void OnEnable()
    {
        StartCountdown();
    }

    public void StartCountdown()
    {
        sayac = soruZaman.maxValue;
        zamanDurduMu = false;
    }

    private void Start()
    {
        StartCountdown();
        if (!zamanDurduMu)
        {
            SoruSlider();
            InvokeRepeating("Countdown", 1.0f, 1.0f);
        }
    }
     void Countdown()
    { 
        if (!zamanDurduMu)
        {
            sayac--; 
            soruZaman.value = sayac;
            if (sayac <= 0)
            {
                zamanDurduMu = true;
                menuController.soruPanel.SetActive(false);
                FindObjectOfType<MenuController>().GameOver();
            }
        }
    }
    public void SoruSlider()
    {
        soruZaman.maxValue = 30;
        soruZaman.minValue = 0;
        soruZaman.wholeNumbers = true;
        soruZaman.value = soruZaman.maxValue;
        sayac = soruZaman.value;
    }   


}
