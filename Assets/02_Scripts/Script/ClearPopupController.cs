using UnityEngine;
using TMPro;

public class ClearPopupController : MonoBehaviour
{
    public CanvasGroup PopupCanvasGroup; // 팝업 CanvasGroup 연결
    public TextMeshProUGUI ClearText; // 클리어 메시지 텍스트

    public void ShowClearPopup()
    {
        if (PopupCanvasGroup != null)
        {
            PopupCanvasGroup.alpha = 1; // 팝업 보이기
            PopupCanvasGroup.interactable = true;
            PopupCanvasGroup.blocksRaycasts = true;
        }

        if (ClearText != null)
        {
            ClearText.text = "Game Clear!";
        }
    }
}
