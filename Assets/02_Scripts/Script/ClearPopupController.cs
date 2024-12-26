using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

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
        StartCoroutine(timeChange());
    }

    IEnumerator timeChange()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Start");
    }
}
