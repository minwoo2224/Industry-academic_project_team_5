using UnityEngine;
using TMPro; // TextMeshPro 네임스페이스 추가

public class MapSwitcher : MonoBehaviour
{
    public GameObject[] maps; // 맵 오브젝트 배열
    public Transform[] spawnPoints; // 스폰포인트 배열
    public Transform player; // 플레이어 Transform
    public TextMeshProUGUI stageText; // StageText UI 연결
    public ClearPopupController clearPopupController; // 팝업창 컨트롤러

    private int currentMapIndex = 0; // 현재 맵 인덱스

    void Start()
    {
        // 모든 맵 비활성화
        foreach (GameObject map in maps)
        {
            map.SetActive(false);
        }

        // 첫 맵 활성화
        currentMapIndex = 0;
        maps[currentMapIndex].SetActive(true);

        SetPlayerPosition();
        UpdateStageText();
    }

    public void EnterDoor(bool isCorrect)
    {
        if (isCorrect)
        {
            MoveToNextMap();
        }
        else
        {
            ResetToFirstMap();
        }
    }

    private void MoveToNextMap()
    {
        maps[currentMapIndex].SetActive(false); // 현재 맵 비활성화
        currentMapIndex++;

        if (currentMapIndex >= maps.Length)
        {
            // 마지막 맵을 넘어가면 게임 종료 처리
            clearPopupController.ShowClearPopup();
            return;
        }

        maps[currentMapIndex].SetActive(true); // 다음 맵 활성화
        SetPlayerPosition();
        UpdateStageText();
    }

    private void ResetToFirstMap()
    {
        // 모든 맵 비활성화
        foreach (GameObject map in maps)
        {
            map.SetActive(false);
        }

        currentMapIndex = 0; // 첫 맵으로 돌아가기
        maps[currentMapIndex].SetActive(true);

        SetPlayerPosition();
        UpdateStageText();
    }

    private void SetPlayerPosition()
    {
        Vector3 spawnPosition = spawnPoints[currentMapIndex].position;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.simulated = false;
        }

        player.position = spawnPosition;

        if (rb != null)
        {
            rb.simulated = true;
        }
    }

    private void UpdateStageText()
    {
        if (stageText != null)
        {
            stageText.text = $"Stage {currentMapIndex + 1}";
        }
    }
}
