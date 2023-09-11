using UnityEngine;

public class AudioChoices : MonoBehaviour
{
    public static bool MuzikAcikKayitVarMi()
    {
        if (PlayerPrefs.HasKey(OyunSabitleri.musicOpen))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool EfektAcikKayitVarMi()
    {
        if (PlayerPrefs.HasKey(OyunSabitleri.effectOpen))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int LoadMusic()
    {
        return PlayerPrefs.GetInt(OyunSabitleri.musicOpen);
    }

    public static void SaveMusic(int musicOpen)
    {
        PlayerPrefs.SetInt(OyunSabitleri.musicOpen, musicOpen);
    }

    public static void SaveEffect(int effectOpen)
    {
        PlayerPrefs.SetInt(OyunSabitleri.effectOpen, effectOpen);
    }

    public static int LoadEffect()
    {
        return PlayerPrefs.GetInt(OyunSabitleri.effectOpen);
    }

}
