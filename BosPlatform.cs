using UnityEngine;

public class BosPlatform : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    
    private void Awake()
    {
        boxCollider= GetComponent<BoxCollider2D>();
          
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ayaklar")
        {
            FindObjectOfType<BosPlatformKarakter>();
        }
    }

   



}
