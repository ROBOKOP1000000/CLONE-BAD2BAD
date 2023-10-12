using UnityEngine;

public class ZombieCollision : MonoBehaviour
{
    private float collisionTime = 0f; // ����� ������ ������������
    public float collisionDurationThreshold; // ��������� ����� ������������
    public float damageInterval; // ����� ����� ���������� �������� ��� ������������
    private float damageTimer = 0f; // ����� ���������� ��������� ��������

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �������� ����������� ������������ ��� ������ ��������� � ���������
            collisionTime = Time.time;

            // ������� ���� ��� ������ ������������
            DealDamage();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���� ������������ ������������ ���������� ����� ��� ������ 0.5 ������� � ���������� �����,
            // �������� ��������
            if (Time.time - collisionTime >= collisionDurationThreshold && Time.time - damageTimer >= damageInterval)
            {
                // ������� ����
                DealDamage();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���������� ������ ��� ������ �� ������������
            collisionTime = 0f;
        }
    }

    private void DealDamage()
    {
        // ������ ������ Player � �����
        HealthBar playerHealth = FindObjectOfType<HealthBar>();

        if (playerHealth != null)
        {
            // �������� �������� ������ �� 20%
            playerHealth.SetHealth(playerHealth.currentHealth - (playerHealth.maxHealth * 0.2f));

            // ��������� ����� ���������� ��������� ��������
            damageTimer = Time.time;
        }
    }
}





