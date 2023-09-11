using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioManager audioManager;

    public Sprite onButtonImage;
    public Sprite offButtonImage;

    public Button effectButton;

    public GameObject Effect;
    public AudioSource[] audioSources;

    private void Awake()
    {
        instance= this;
    }
    void Start()
    {
        if (AudioChoices.MuzikAcikKayitVarMi() == false)
        {
            AudioChoices.SaveMusic(1);
        }
        audioManager.MuzikKontrol();

        if (AudioChoices.EfektAcikKayitVarMi() == false)
        {
            AudioChoices.SaveEffect(1);
        }
        audioManager.EfektKontrol();
    }

    public void EfektAc()
    {
        if (AudioChoices.LoadEffect() == 1)
        {
            AudioChoices.SaveEffect(0);
            Effect.SetActive(false);
            effectButton.image.sprite = offButtonImage;
        }
        else
        {
            AudioChoices.SaveEffect(1);
            Effect.SetActive(true);
            effectButton.image.sprite = onButtonImage;
        }
    }

    public void SesEfektiCikar(int hangiSes)
    {
        audioSources[hangiSes].Play();
    }

}

