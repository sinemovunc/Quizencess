using UnityEngine;

public class Ziplama : MonoBehaviour
{
    public AudioManager audioManager;

    [SerializeField]
    private SpriteRenderer playerSprite;

    public PlayerDataBase playerDataBase;
    private int selectedPlayer = 0;
    public GameObject TopScore_Panel;
    public GameObject Score_Panel;
    public GameObject Player;

    Collider2D coll;
    Rigidbody2D rb;

    public float sagHareket;
    public float solHareket;
    public float ziplama;

    [SerializeField] LayerMask jumpableGround;

    private bool sagYuz = true;

    void Start()
    {
        Score_Panel.SetActive(false);
        coll = Player.GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        if (PlayerPrefs.HasKey("SelectedPlayer"))
        {
            Load();
        }
        else
        {
            selectedPlayer = 0;
        }
        UpdatePlayer(selectedPlayer);
    }

    public void SagHareket()
    {
        if (IsGrounded())
        {
            if (!sagYuz)
            {
                Flip();
            }
            TopScore_Panel.SetActive(false);
            Score_Panel.SetActive(true);
            OyunSabitleri.OyunDurumu = false;
            GetComponent<Rigidbody2D>().velocity = new Vector3(sagHareket, ziplama, 0);
            if (AudioChoices.LoadEffect() == 1)
            {
                AudioController.instance.SesEfektiCikar(5);
            }
        }
    }

    public void SolHareket()
    {
        if (IsGrounded())
        {
            if (sagYuz)
            {
                Flip();
            }
            OyunSabitleri.OyunDurumu = false;
            TopScore_Panel.SetActive(false);
            Score_Panel.SetActive(true);
            GetComponent<Rigidbody2D>().velocity = new Vector3(-solHareket, ziplama, 0);
            if (AudioChoices.LoadEffect() == 1)
            {
                AudioController.instance.SesEfektiCikar(5);
            }
        }
    }

    private void Flip()
    {
        sagYuz = !sagYuz;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void UpdatePlayer(int selected)
    {
        PlayerShop playerShop = playerDataBase.GetPlayer(selected);
        playerSprite.sprite = playerShop.playerSprite;

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.size = playerShop.colliderSize; // Kostümün collider boyutunu ayarla
        boxCollider.offset = playerShop.colliderOffset; // Kostümün collider ofsetini ayarla

        sagHareket = playerShop.sagHareketHizi; // Sað hareket hýzýný ayarla
        solHareket = playerShop.solHareketHizi; // Sol hareket hýzýný ayarla
    }

    private void Load()
    {
        selectedPlayer = PlayerPrefs.GetInt("SelectedPlayer");
    }

    public void OyunBitti()
    {
        Destroy(gameObject);
    }

    private bool IsGrounded()
    {
        // Karakterin yatay hýzý kontrol edilerek daðýnýk bir zýplama önlenecek
        if (Mathf.Abs(rb.velocity.y) <= 0.1f)
        {
            RaycastHit2D hit = Physics2D.Raycast(coll.bounds.center, Vector2.down, coll.bounds.extents.y + 0.1f);
            return hit.collider != null;
        }

        return false;
    }
}