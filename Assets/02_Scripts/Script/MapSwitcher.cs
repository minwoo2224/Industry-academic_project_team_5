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
        UpdateStageText(); // StageText UI 업데이트
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
        UpdateStageText(); // StageText UI 업데이트
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
        UpdateStageText(); // StageText UI 업데이트
    }

    private void SetPlayerPosition()
    {
        // 고정된 초기 Y 좌표값 설정 (스테이지 1의 첫 시작 Y값으로 설정)
        float fixedYPosition = spawnPoints[0].position.y;

        // 현재 맵의 스폰포인트 위치 가져오기
        Vector3 spawnPosition = spawnPoints[currentMapIndex].position;

        // Y 좌표값을 고정된 값으로 덮어쓰기
        spawnPosition.y = fixedYPosition;

        // Rigidbody2D 설정
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;      // 이동 속도 초기화
            rb.angularVelocity = 0f;        // 회전 속도 초기화
            rb.simulated = false;           // 물리 시뮬레이션 비활성화
        }

        // 플레이어 위치 강제 설정
        player.position = spawnPosition;

        if (rb != null)
        {
            rb.simulated = true;            // 물리 시뮬레이션 다시 활성화
        }

        UpdateStageText(); // StageText UI 업데이트
    }

    private void UpdateStageText()
    {
        if (stageText != null)
        {
            stageText.text = $"Stage {currentMapIndex + 1}";
            Debug.Log($"StageText updated: {stageText.text}"); // 디버깅 로그 추가
        }
        else
        {
            Debug.LogError("StageText가 연결되지 않았습니다! Inspector에서 확인하세요.");
        }
    }

}
