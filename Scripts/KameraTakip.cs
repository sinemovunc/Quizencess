using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public float hareketHizi;
    public Vector3 offset;
    public Transform player;

    private void Update()
    {
        if(transform != null && player != null)
        transform.position = Vector3.Lerp(transform.position, 
            player.transform.position + offset, hareketHizi * Time.deltaTime);
    }

}
