using UnityEngine;

public class OlumculPlatform : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
 
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ayaklar")
        {
            FindObjectOfType<BosPlatformKarakter>();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ayaklar")
        {
            FindObjectOfType<BosPlatformKarakter>();
        }
    }
    
}
