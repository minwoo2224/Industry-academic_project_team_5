using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool isCorrectDoor; // ���� �� ����
    private MapSwitcher mapSwitcher;

    void Start()
    {
        mapSwitcher = FindObjectOfType<MapSwitcher>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mapSwitcher.EnterDoor(isCorrectDoor); // ���� ���θ� MapSwitcher�� ����
        }
    }
}
