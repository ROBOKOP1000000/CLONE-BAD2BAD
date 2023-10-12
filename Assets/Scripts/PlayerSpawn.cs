using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform spawnPoint; // ������ �� ����� ��������� ������

    void Start()
    {
        // ������������� ������ � ����� ���������
        if (spawnPoint != null)
        {
            // ���������� ������ � ����� ���������
            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                player.transform.position = spawnPoint.position;
            }
        }
    }
}

