using TMPro;
using UnityEngine;
using System.Collections;

public class TurnOnOff : MonoBehaviour
{
    public GameObject Object;
    public string[] dialog;
    public TextMeshProUGUI thoai;
    public TextMeshProUGUI nguoinoi;

    private int currentDialogIndex = 0;
    private Coroutine typingCoroutine;
    private bool isTyping = false;
    private string currentText = "";

    public float typingSpeed = 0.1f; // thời gian chờ giữa mỗi chữ cái

    Interactable interactable;
    public void TurnOn( GameObject gameObject)
    {
        Object.SetActive(true); // Kích hoạt đối tượng trước
        interactable = gameObject.GetComponent<Interactable>();
        interactable.enabled = false;
        currentDialogIndex = 0;
        DisplayCurrentDialog(); // Sau khi đã active
    }

    public void TurnOff()
    {
        Object.SetActive(false);
    }

    public void SetDialog(int Index)
    {
        dialog = Dialog.Instance.GetDialog(Index);
    }

    public void NextDialog()
    {
        if (isTyping)
        {
            // Nếu đang đánh máy, nhấn sẽ hiển thị toàn bộ ngay lập tức
            StopCoroutine(typingCoroutine);
            thoai.text = currentText;
            isTyping = false;
        }
        else
        {
            currentDialogIndex += 2;
            if (currentDialogIndex < dialog.Length)
            {
                DisplayCurrentDialog();
            }
            else
            {
                interactable.enabled = true;
                TurnOff();
            }
        }
    }

    private void DisplayCurrentDialog()
    {
        if (dialog.Length >= currentDialogIndex + 2)
        {
            string dialogKey = dialog[currentDialogIndex];
            string speakerKey = dialog[currentDialogIndex + 1];

            string dialogText = LanguageManager.Instance.GetText(dialogKey);
            string speakerText = LanguageManager.Instance.GetText(speakerKey);

            nguoinoi.text = speakerText;

            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(TypeText(dialogText));
        }
        else
        {
            Debug.LogWarning("Không đủ cặp thoại và người nói tại chỉ mục " + currentDialogIndex);
            TurnOff();
        }
    }

    IEnumerator TypeText(string textToType)
    {
        isTyping = true;
        currentText = textToType;
        thoai.text = "";

        foreach (char letter in textToType)
        {
            thoai.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void Update()
    {
        if (Object.activeSelf && Input.GetMouseButtonDown(0))
        {
            NextDialog();
        }
    }
}