using UnityEngine;
using System.Collections;
using TMPro;

public class Blink : MonoBehaviour
{
    TMP_Text flashingText; // TextMesh Pro 텍스트
    // Use this for initialization
    void Start()
    {
        // TMP_Text 컴포넌트 가져오기
        flashingText = GetComponent<TMP_Text>();
        if (flashingText == null)
        {
            Debug.LogError("TMP_Text 컴포넌트를 찾을 수 없습니다!");
            return;
        }

        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            // 텍스트 비우기
            flashingText.text = "";
            yield return new WaitForSeconds(.5f);

            // 텍스트 설정
            flashingText.text = "Spacebar to Start";
            yield return new WaitForSeconds(.5f);
        }
    }
}
