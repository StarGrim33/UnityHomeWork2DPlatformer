using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Character _character;
    [SerializeField] private Coin _coin;

    private void Start()
    {
        Coin.Taken += OnCoinChanged;
    }

    private void OnDestroy()
    {
        Coin.Taken -= OnCoinChanged;
    }

    private void OnCoinChanged()
    {
        DisplayCoins();
    }

    public void DisplayCoins()
    {
        string text = "Монет " + _character.Coins.ToString();
        _text.text = text;
    }
}


