using TMPro;
using UnityEngine;

public class ElevenLabsUIManager : MonoBehaviour
{
    public ElevenLabsTTS elevenLabsTTS; // ElevenLabsTTS ��ũ��Ʈ ����
    public TMP_InputField inputField;   // InputField ����

    // ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnGenerateVoiceButtonClick()
    {
        string text = inputField.text; // InputField���� �ؽ�Ʈ ��������
        if (!string.IsNullOrEmpty(text))
        {
            elevenLabsTTS.GenerateVoice(text); // ���� ���� ȣ��
        }
        else
        {
            Debug.LogWarning("Input field is empty.");
        }
    }
}