using UnityEngine;

public class Platform : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ayaklar")
        {
            for (int i = 0; i < 5; i++)
            {
                FindObjectOfType<Score>().PuanKazan();
            }
            
        }
    }
}
