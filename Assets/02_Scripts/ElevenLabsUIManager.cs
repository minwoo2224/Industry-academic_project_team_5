using TMPro;
using UnityEngine;

public class ElevenLabsUIManager : MonoBehaviour
{
    public ElevenLabsTTS elevenLabsTTS; // ElevenLabsTTS 스크립트 참조
    public TMP_InputField inputField;   // InputField 참조

    // 버튼 클릭 시 호출되는 메서드
    public void OnGenerateVoiceButtonClick()
    {
        string text = inputField.text; // InputField에서 텍스트 가져오기
        if (!string.IsNullOrEmpty(text))
        {
            elevenLabsTTS.GenerateVoice(text); // 음성 생성 호출
        }
        else
        {
            Debug.LogWarning("Input field is empty.");
        }
    }
}