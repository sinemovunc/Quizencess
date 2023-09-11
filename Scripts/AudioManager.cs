using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sprite onButtonImage;
    public Sprite offButtonImage;

    public Button soundButton;
    public Button effectButton;

    public GameObject Audio;

    public AudioController audioController;

    private void Start()
    {
        if (AudioChoices.MuzikAcikKayitVarMi() == false)
        {
            AudioChoices.SaveMusic(1);
        }
        MuzikKontrol();
        if (AudioChoices.EfektAcikKayitVarMi() == false)
        {
            AudioChoices.SaveEffect(1);
        }
        EfektKontrol();
    }

    public void MuzikKontrol()
    {
        if (AudioChoices.LoadMusic() == 1)
        {
            AudioChoices.SaveMusic(0);
            Audio.SetActive(false);
            soundButton.image.sprite = offButtonImage;
        }
        else
        {
            AudioChoices.SaveMusic(1);
            Audio.SetActive(true);
            soundButton.image.sprite = onButtonImage;
        }

    }
    public void EfektKontrol()
    {
        if (AudioChoices.LoadEffect() == 1)
        {
            AudioChoices.SaveEffect(0);
            audioController.Effect.SetActive(false);
            effectButton.image.sprite = offButtonImage;
        }
        else
        {
            AudioChoices.SaveEffect(1);
            audioController.Effect.SetActive(true);
            effectButton.image.sprite = onButtonImage;
        }
    }
}
