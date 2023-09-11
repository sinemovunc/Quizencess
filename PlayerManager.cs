using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer playerSprite;

    public PlayerDataBase playerDataBase;
    private int selectedPlayer = 0;

    public GameObject Selected_Icon;
    public Button BuyButton;
    public Button BackButtonn, NextButtonn;

    public Text coinsText;
    public Text characterPriceText;

    public bool isUnlocked;

    public Sprite BuyButtonSprite, SelectButtonSprite, SelectButtonSprite1;
    public Sprite normalSagOk, normalSolOk, seciliSagOk, seciliSolOk;

    int characterPrice;

    private void Start()
    {
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

    private void Update()
    {
        coinsText.text = " " + PlayerPrefs.GetInt("ToplamAltin", 0);
    }

    public void NextButton()
    {
        selectedPlayer++;
        if (selectedPlayer >= playerDataBase.playerCounter)
        {
            selectedPlayer = 0;
        }
        if (selectedPlayer == 0)
        {
            BuyButton.image.sprite = SelectButtonSprite;
            BackButtonn.image.sprite = seciliSolOk;
            NextButtonn.image.sprite = seciliSagOk;
        }
        else
        {
            PlayerShop nextPlayerShop = playerDataBase.GetPlayer(selectedPlayer);
            int nextCharacterPrice = nextPlayerShop.price;
            if (selectedPlayer == PlayerPrefs.GetInt("SelectedPlayer") || nextCharacterPrice == 0)
            {
                BuyButton.image.sprite = SelectButtonSprite;
                BackButtonn.image.sprite = seciliSolOk;
                NextButtonn.image.sprite = seciliSagOk;
                Selected_Icon.SetActive(true);
            }
            else
            {
                BuyButton.image.sprite = BuyButtonSprite;
                BackButtonn.image.sprite = normalSolOk;
                NextButtonn.image.sprite = normalSagOk;
                Selected_Icon.SetActive(false);
            }
        }
        UpdatePlayer(selectedPlayer);
    }

    public void BackButton()
    {
        selectedPlayer--;
        if (selectedPlayer < 0)
        {
            selectedPlayer = playerDataBase.playerCounter - 1;
        }
        if (selectedPlayer == 0)
        {
            BuyButton.image.sprite = SelectButtonSprite;
            BackButtonn.image.sprite = seciliSolOk;
            NextButtonn.image.sprite = seciliSagOk;
        }
        else
        {
            PlayerShop prevPlayerShop = playerDataBase.GetPlayer(selectedPlayer);
            int prevCharacterPrice = prevPlayerShop.price;
            if (selectedPlayer == PlayerPrefs.GetInt("SelectedPlayer") || prevCharacterPrice == 0)
            {
                BuyButton.image.sprite = SelectButtonSprite;
                BackButtonn.image.sprite = seciliSolOk;
                NextButtonn.image.sprite = seciliSagOk;
                Selected_Icon.SetActive(true);
            }
            else
            {
                BuyButton.image.sprite = BuyButtonSprite;
                BackButtonn.image.sprite = normalSolOk;
                NextButtonn.image.sprite = normalSagOk;
                Selected_Icon.SetActive(false);
            }
        }
        UpdatePlayer(selectedPlayer);
    }

    private void UpdatePlayer(int selected)
    {
        PlayerShop playerShop = playerDataBase.GetPlayer(selected);
        playerSprite.sprite = playerShop.playerSprite;

        characterPrice = playerShop.price;
        characterPriceText.text = characterPrice.ToString();

        List<int> unlockedCharacters = GetUnlockedCharacters();
        isUnlocked = unlockedCharacters.Contains(selected);
        BuyButton.interactable = !isUnlocked && PlayerPrefs.GetInt("ToplamAltin", 0) >= characterPrice;
        characterPriceText.text = isUnlocked ? "Purchased" : " " + characterPrice;

        Selected_Icon.SetActive(selected == PlayerPrefs.GetInt("SelectedPlayer"));

        if (selected == PlayerPrefs.GetInt("SelectedPlayer"))
        {
            BuyButton.image.sprite = SelectButtonSprite1;
            BackButtonn.image.sprite = seciliSolOk;
            NextButtonn.image.sprite = seciliSagOk;
            Selected_Icon.SetActive(true);
        }
        else if (selected == 0)
        {
            BuyButton.image.sprite = SelectButtonSprite;
            BackButtonn.image.sprite = normalSolOk;
            NextButtonn.image.sprite = normalSagOk;
            Selected_Icon.SetActive(false);
        }
        else if (isUnlocked)
        {
            BuyButton.interactable = true;
            BuyButton.image.sprite = SelectButtonSprite;
        }
        else
        {
            BuyButton.interactable = !isUnlocked && PlayerPrefs.GetInt("ToplamAltin", 0) >= characterPrice;
            BuyButton.image.sprite = isUnlocked ? SelectButtonSprite1 : BuyButtonSprite;
        }
    }

    private void Load()
    {
        selectedPlayer = PlayerPrefs.GetInt("SelectedPlayer");
        characterPriceText.text = "Purchased";
    }

    private void Save()
    {
        PlayerPrefs.SetInt("SelectedPlayer", selectedPlayer);
    }

    private List<int> GetUnlockedCharacters()
    {
        string unlockedCharactersString = PlayerPrefs.GetString("UnlockedCharacters", "");
        if (string.IsNullOrEmpty(unlockedCharactersString))
        {
            return new List<int>();
        }

        string[] unlockedCharacterIDs = unlockedCharactersString.Split(',');
        List<int> unlockedCharacters = new List<int>();
        foreach (string id in unlockedCharacterIDs)
        {
            if (int.TryParse(id, out int unlockedCharacterID))
            {
                unlockedCharacters.Add(unlockedCharacterID);
            }
        }

        return unlockedCharacters;
    }

    private void SaveUnlockedCharacters(List<int> unlockedCharacters)
    {
        string unlockedCharactersString = string.Join(",", unlockedCharacters);
        PlayerPrefs.SetString("UnlockedCharacters", unlockedCharactersString);
    }

    public void BuyButtonClicked()
    {
        PlayerShop playerShop = playerDataBase.GetPlayer(selectedPlayer);
        int characterPrice = playerShop.price;
        int currentGold = PlayerPrefs.GetInt("ToplamAltin", 0);

        if (characterPrice == 0)
        {
            if (characterPrice == 0 && selectedPlayer == PlayerPrefs.GetInt("SelectedPlayer"))
            {
                BuyButton.image.sprite = SelectButtonSprite1;
                return;
            }
            else
            {
                PlayerPrefs.SetInt("SelectedPlayer", selectedPlayer);
                BuyButton.image.sprite = SelectButtonSprite1;
                characterPriceText.text = "purchased";
                Selected_Icon.SetActive(true);
            }
        }
        else if (currentGold >= characterPrice && !isUnlocked)
        {
            currentGold -= characterPrice;
            PlayerPrefs.SetInt("ToplamAltin", currentGold);

            List<int> unlockedCharacters = GetUnlockedCharacters();
            unlockedCharacters.Add(selectedPlayer);
            SaveUnlockedCharacters(unlockedCharacters);

            BuyButton.interactable = false;
            characterPriceText.text = "purchased";

            coinsText.text = " " + currentGold;
            BuyButton.image.sprite = SelectButtonSprite1;
        }
        else if (isUnlocked)
        {
            characterPriceText.text = "purchased";
            BuyButton.image.sprite = SelectButtonSprite1;
        }
        else
        {
            Debug.Log("Yetersiz altýn!");
        }
        UpdatePlayer(selectedPlayer);
        Save();
    }
}