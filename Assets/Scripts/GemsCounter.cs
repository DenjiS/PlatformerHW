using TMPro;
using UnityEngine;

public class GemsCounter : MonoBehaviour
{
    [SerializeField] private string _textBeforeCount;

    private TextMeshProUGUI _textElement;
    private GemsWallet _gemsWallet;

    private void Awake()
    {
        _textElement = GetComponent<TextMeshProUGUI>();
        _gemsWallet = FindAnyObjectByType<GemsWallet>();
    } 

    private void OnEnable()
    {
        _gemsWallet.Changed += OnWalletChanged;
    }

    private void OnDisable()
    {
        _gemsWallet.Changed -= OnWalletChanged;
    }

    private void OnWalletChanged(int count)
    {
        _textElement.text = _textBeforeCount + count.ToString();
    }
}
