using TMPro;
using UnityEngine;

public class LanguageLoad : MonoBehaviour
{
    private TextMeshProUGUI text;
    private string defaultText;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        defaultText = text.text;
    }

    void OnEnable()
    {
        LanguageManager.Instance.LanguageChanged += UpdateText;
        UpdateText(); // cập nhật ngay khi bật
    }

    void OnDisable()
    {
        LanguageManager.Instance.LanguageChanged -= UpdateText;
    }

    private void UpdateText()
    {
        string message = LanguageManager.Instance.GetText(defaultText);
        text.text = message;
    }
}
