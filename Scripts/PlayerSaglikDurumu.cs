using UnityEngine;
public class PlayerSaglikDurumu : MonoBehaviour
{
    public int maxSaglik, gecerliSaglik;

    UI_Scripts UIController;
    Zaman zaman;

    private void Awake()
    {
        UIController = Object.FindObjectOfType<UI_Scripts>();
        zaman = Object.FindObjectOfType<Zaman>();
    }

    void Start()
    {
        gecerliSaglik = maxSaglik;
    }

    public void HasarAl()
    {
        gecerliSaglik--;
        if (gecerliSaglik <= 0)
        {
            gameObject.SetActive(false);
            FindObjectOfType<MenuController>().GameOver();
        }

        UIController.SaglikDurumuGuncelle();
    }
    public void KalpKazan()
    {
        if(gecerliSaglik < maxSaglik)
        {
            gecerliSaglik+=2;
            if (gecerliSaglik > maxSaglik)
            {
                gecerliSaglik = maxSaglik;
            } 
            zaman.ZamanEkle();
            UIController.SaglikDurumuGuncelle();
        }
        if(gecerliSaglik == maxSaglik)
        {
            gecerliSaglik = maxSaglik;
            UIController.SaglikDurumuGuncelle();
        }
       
        
    }

    public void KalpKaybet()
    {
        if(gecerliSaglik <= maxSaglik)
        {
            gecerliSaglik -= 1;
            zaman.ZamanCikart();
            UIController.SaglikDurumuGuncelle();
        }
        if (gecerliSaglik <= 0)
        {
            gameObject.SetActive(false);
            FindObjectOfType<MenuController>().GameOver();
        }
        
    }
}
