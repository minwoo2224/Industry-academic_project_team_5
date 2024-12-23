using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool isCorrectDoor; // 정답 문 여부
    private MapSwitcher mapSwitcher;

    void Start()
    {
        mapSwitcher = FindObjectOfType<MapSwitcher>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mapSwitcher.EnterDoor(isCorrectDoor); // 정답 여부를 MapSwitcher로 전달
        }
    }
}
