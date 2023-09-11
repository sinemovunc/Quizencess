using System.Collections;
using UnityEngine;

public class BosPlatformKarakter : MonoBehaviour
{
    Collider2D collider;
    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BosPlatform"))
        {
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(DropEffect());
            FindObjectOfType<MenuController>().GameOver();

        }
        if (collision.gameObject.CompareTag("Olum"))
        {
            GetComponent<Collider2D>().enabled = false;

            StartCoroutine(DropEffect());
            FindObjectOfType<MenuController>().GameOver();

        }
    }


    public IEnumerator DropEffect()
    {
        while (transform.rotation.eulerAngles.z > -1f)
        {
            transform.Rotate(Vector3.forward, -10f);
            yield return null;
        }

        Destroy(gameObject, .05f);
    }

}
