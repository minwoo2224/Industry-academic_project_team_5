using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 요소를 다루기 위해 필요

public class Blink_Button : MonoBehaviour
{
    private Image buttonImage; // Image 컴포넌트 참조

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        // Image 컴포넌트 가져오기
        buttonImage = gameObject.GetComponent<Image>();
        if (buttonImage == null)
        {
            Debug.LogError($"{gameObject.name}에서 Image 컴포넌트를 찾을 수 없습니다!");
            return;
        }

        // 깜박이 코루틴 실행
        StartCoroutine(BlinkButton());
    }

    public IEnumerator BlinkButton()
    {
        while (true)
        {
            // 이미지 숨기기
            buttonImage.enabled = false;
            yield return new WaitForSeconds(0.5f);

            // 이미지 표시하기
            buttonImage.enabled = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
