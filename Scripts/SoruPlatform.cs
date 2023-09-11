using UnityEngine;

public class SoruPlatform : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D boxCollider;
  
    private void Start()
    {
        boxCollider= GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ayaklar")
        {
            FindObjectOfType<Pause>().OyunuDurdur();
            FindObjectOfType<SoruOyun>().soruPanel.SetActive(true);
            FindObjectOfType<SoruZaman>();
        }
    }
        
}


