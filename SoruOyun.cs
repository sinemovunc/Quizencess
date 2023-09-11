using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SoruOyun : MonoBehaviour
{
    public Soru[] sorular;
    private static List<Soru> sorulmamisSorular;
    private Soru simdikiSoru;

    public Sprite normalButon, yanlisButon, dogruButon;
    public Sprite normalPanel, yanlisPanel, dogruPanel;
    public Sprite normalSlider, yanlisSlider;

    private Image arkaplanImage;  

    public Text soruText;

    public Button Button_A;
    public Button Button_B;
    public Button Button_C;
    public Button Button_D;

    public GameObject soruPanel;
    public Image textPanel;
    public Slider slider;
    
    private PlayerSaglikDurumu saglikDurumu;

    public static int dogruSayisi;
    public static int yanlisSayisi;
    public static int soruSayisi;

    private void Awake()
    {
        dogruSayisi= 0;
        yanlisSayisi= 0;
        soruSayisi= 0;
    }

    void Start()
    {
        saglikDurumu = FindObjectOfType<PlayerSaglikDurumu>();
        arkaplanImage = slider.fillRect.GetComponent<Image>();
        if (sorulmamisSorular == null)
        {
            sorulmamisSorular = sorular.ToList<Soru>();
        }
        if (sorulmamisSorular.Count <= 0)
        {
            LevelBitti();
        }
        else
        {
            SoruSor();
        }

    }

    void SoruSor()
    {
        int soruIndex = Random.Range(0, sorulmamisSorular.Count);
        simdikiSoru = sorulmamisSorular[soruIndex];
        soruText.text = simdikiSoru.soru;

        Button_A.GetComponentInChildren<Text>().text = simdikiSoru.A;
        Button_B.GetComponentInChildren<Text>().text = simdikiSoru.B;
        Button_C.GetComponentInChildren<Text>().text = simdikiSoru.C;
        Button_D.GetComponentInChildren<Text>().text = simdikiSoru.D;

        sorulmamisSorular.RemoveAt(soruIndex);
    }
    public void SecenekA()
    {
        CevapKontrol(Button_A, 1);
    }
    public void SecenekB()
    {
        CevapKontrol(Button_B, 2);

    }
    public void SecenekC()
    {
        CevapKontrol(Button_C, 3);
    }
    public void SecenekD()
    {
        CevapKontrol(Button_D, 4);

    }
    IEnumerator Bekle()
    {
        yield return new WaitForSecondsRealtime(.75f);
        soruPanel.SetActive(false);
        StartCoroutine(SonrakiSoru());
    }
    IEnumerator SonrakiSoru()
    {
        yield return new WaitForSecondsRealtime(1);
        SoruSor();

        textPanel.sprite = normalPanel;
        Button_A.image.sprite = normalButon;
        Button_B.image.sprite = normalButon;
        Button_C.image.sprite = normalButon;
        Button_D.image.sprite = normalButon;
        arkaplanImage.sprite = normalSlider;
    }

    public void LevelBitti()
    {
        soruPanel.SetActive(false);
        Button_A.gameObject.SetActive(false);
        Button_B.gameObject.SetActive(false);
        Button_C.gameObject.SetActive(false);
        Button_D.gameObject.SetActive(false);
    }

    public void DogruCevap(Button btn)
    {
        for (int i = 0; i < 10; i++)
        {
            FindObjectOfType<Score>().PuanKazan();
            FindObjectOfType<Score>().AltinKazan();
            FindObjectOfType<Score>().ToplamAltin();
            soruSayisi++;

        }
        dogruSayisi++;
        btn.image.sprite = dogruButon;
        textPanel.sprite = dogruPanel;
        saglikDurumu.KalpKazan();

        if (AudioChoices.LoadEffect() == 1)
        {
            AudioController.instance.SesEfektiCikar(0);
        }

        if (simdikiSoru.cevap == 1)
            Button_A.image.sprite = dogruButon;
        else if (simdikiSoru.cevap == 2)
            Button_B.image.sprite = dogruButon;
        else if (simdikiSoru.cevap == 3)
            Button_C.image.sprite = dogruButon;
        else if (simdikiSoru.cevap == 4)
            Button_D.image.sprite = dogruButon;

        FindObjectOfType<Pause>().OyunuDevamEttir();
        StartCoroutine(Bekle());
    }
    public void YanlisCevap(Button btn)
    {
        yanlisSayisi++;
        saglikDurumu.KalpKaybet();
        btn.image.sprite = yanlisButon;
        textPanel.sprite = yanlisPanel;
        arkaplanImage.sprite = yanlisSlider;

        if (AudioChoices.LoadEffect() == 1)
        {
            AudioController.instance.SesEfektiCikar(1);
        }
        if (simdikiSoru.cevap == 1)
            Button_A.image.sprite = dogruButon;
        else if (simdikiSoru.cevap == 2)
            Button_B.image.sprite = dogruButon;
        else if (simdikiSoru.cevap == 3)
            Button_C.image.sprite = dogruButon;
        else if (simdikiSoru.cevap == 4)
            Button_D.image.sprite = dogruButon;

        // Yanlýþ cevabý kýrmýzý olarak göster
        if (btn == Button_A)
            Button_A.image.sprite = yanlisButon;
        else if (btn == Button_B)
            Button_B.image.sprite = yanlisButon;
        else if (btn == Button_C)
            Button_C.image.sprite = yanlisButon;
        else if (btn == Button_D)
            Button_D.image.sprite = yanlisButon;

        FindObjectOfType<Pause>().OyunuDevamEttir();
        StartCoroutine(Bekle());
    }

    public void CevapKontrol(Button btn, int cevap)
    {
        if (simdikiSoru.cevap == cevap)
        {
            DogruCevap(btn);
        }
        else
        {
            YanlisCevap(btn);

        }
    }
}
