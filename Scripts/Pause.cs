using UnityEngine;

public class Pause : MonoBehaviour
{
    private void Awake()
    {
        OyunSabitleri.OyunDurumu = true;
  
    }
    public void OyunuDurdur()
    {
        OyunSabitleri.OyunDurumu = true;
    }

    public void OyunuDevamEttir()
    {
        OyunSabitleri.OyunDurumu = false;
    }
}
