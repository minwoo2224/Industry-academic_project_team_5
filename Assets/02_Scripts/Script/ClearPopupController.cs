using UnityEngine;
using TMPro;

public class ClearPopupController : MonoBehaviour
{
    public CanvasGroup PopupCanvasGroup; // �˾� CanvasGroup ����
    public TextMeshProUGUI ClearText; // Ŭ���� �޽��� �ؽ�Ʈ

    public void ShowClearPopup()
    {
        if (PopupCanvasGroup != null)
        {
            PopupCanvasGroup.alpha = 1; // �˾� ���̱�
            PopupCanvasGroup.interactable = true;
            PopupCanvasGroup.blocksRaycasts = true;
        }

        if (ClearText != null)
        {
            ClearText.text = "Game Clear!";
        }
    }
}
