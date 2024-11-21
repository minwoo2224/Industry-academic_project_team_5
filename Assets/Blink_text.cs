using UnityEngine;
using System.Collections;
using TMPro;

public class Blink : MonoBehaviour
{
    TMP_Text flashingText; // TextMesh Pro �ؽ�Ʈ
    // Use this for initialization
    void Start()
    {
        // TMP_Text ������Ʈ ��������
        flashingText = GetComponent<TMP_Text>();
        if (flashingText == null)
        {
            Debug.LogError("TMP_Text ������Ʈ�� ã�� �� �����ϴ�!");
            return;
        }

        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            // �ؽ�Ʈ ����
            flashingText.text = "";
            yield return new WaitForSeconds(.5f);

            // �ؽ�Ʈ ����
            flashingText.text = "Spacebar to Start";
            yield return new WaitForSeconds(.5f);
        }
    }
}
