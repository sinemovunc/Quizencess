using UnityEngine;

public class BrokenPlatform : MonoBehaviour
{
    public GameObject brokenPlatformPrefab;

    private bool isBroken = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ayaklar") && !isBroken)
        {
            isBroken = true;

            GameObject brokenPlatform = Instantiate(brokenPlatformPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
            Destroy(brokenPlatform, .5f);

            for (int i = 0; i < 5; i++)
            {
                FindObjectOfType<Score>().PuanKazan();
            }
        }
    }
}
