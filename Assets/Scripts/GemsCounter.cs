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
        _gemsWallet.OnChanged += WriteCount;
    }

    private void OnDisable()
    {
        _gemsWallet.OnChanged -= WriteCount;
    }

    private void WriteCount(int count)
    {
        _textElement.text = _textBeforeCount + count.ToString();
    }
}
