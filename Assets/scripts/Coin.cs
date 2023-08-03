using UnityEngine;

[System.Serializable]
public class CoinModel
{
    public int coinValue = 1;
}

public class Coin : MonoBehaviour
{
    public CoinModel model;
}
