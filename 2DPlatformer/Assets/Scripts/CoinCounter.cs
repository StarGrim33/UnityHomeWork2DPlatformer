using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Character _character;
    [SerializeField] private Coin _coin;

    private void Start()
    {
        Coin.CoinChanged += OnCoinChanged;
    }

    private void OnDestroy()
    {
        Coin.CoinChanged -= OnCoinChanged;
    }

    private void OnCoinChanged()
    {
        TextCoins();
    }

    public void TextCoins()
    {
        string text = "Монет: " + _character.Coins.ToString();
        _text.text = text;
    }
}


