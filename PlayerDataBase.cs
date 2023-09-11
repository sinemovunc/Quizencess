using UnityEngine;

[CreateAssetMenu]
public class PlayerDataBase : ScriptableObject
{
    public PlayerShop[] playerShop;

    public int playerCounter { get { return playerShop.Length;  } }

    public PlayerShop GetPlayer(int index)
    {
        return playerShop[index];
    }
}
