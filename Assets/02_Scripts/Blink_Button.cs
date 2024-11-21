using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ��Ҹ� �ٷ�� ���� �ʿ�

public class Blink_Button : MonoBehaviour
{
    private Image buttonImage; // Image ������Ʈ ����

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        // Image ������Ʈ ��������
        buttonImage = gameObject.GetComponent<Image>();
        if (buttonImage == null)
        {
            Debug.LogError($"{gameObject.name}���� Image ������Ʈ�� ã�� �� �����ϴ�!");
            return;
        }

        // ������ �ڷ�ƾ ����
        StartCoroutine(BlinkButton());
    }

    public IEnumerator BlinkButton()
    {
        while (true)
        {
            // �̹��� �����
            buttonImage.enabled = false;
            yield return new WaitForSeconds(0.5f);

            // �̹��� ǥ���ϱ�
            buttonImage.enabled = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
