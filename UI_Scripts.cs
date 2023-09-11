using UnityEngine;
using UnityEngine.UI;

public class UI_Scripts : MonoBehaviour
{
    [SerializeField]
    Image kalp1Image, kalp2Image, kalp3Image;

    [SerializeField]
    Sprite doluKalp, yarimKalp, bosKalp;

    PlayerSaglikDurumu playerSaglikDurumu;

    private void Awake()
    {
        playerSaglikDurumu = Object.FindObjectOfType<PlayerSaglikDurumu>();
    }
    public void SaglikDurumuGuncelle()
    {
        switch (playerSaglikDurumu.gecerliSaglik)
        {
            case 6:
                kalp1Image.sprite = doluKalp;
                kalp2Image.sprite = doluKalp;
                kalp3Image.sprite = doluKalp;
                break;

            case 5:
                kalp1Image.sprite = doluKalp;
                kalp2Image.sprite = doluKalp;
                kalp3Image.sprite = yarimKalp;
                break;

            case 4:
                kalp1Image.sprite = doluKalp;
                kalp2Image.sprite = doluKalp;
                kalp3Image.sprite = bosKalp;
                break;

            case 3:
                kalp1Image.sprite = doluKalp;
                kalp2Image.sprite = yarimKalp;
                kalp3Image.sprite = bosKalp;
                break;

            case 2:
                kalp1Image.sprite = doluKalp;
                kalp2Image.sprite = bosKalp;
                kalp3Image.sprite = bosKalp;
                break;

            case 1:
                kalp1Image.sprite = yarimKalp;
                kalp2Image.sprite = bosKalp;
                kalp3Image.sprite = bosKalp;
                break;

            case 0:
                kalp1Image.sprite = bosKalp;
                kalp2Image.sprite = bosKalp;
                kalp3Image.sprite = bosKalp;
                break;
        }
    }

 }
