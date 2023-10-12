using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public GameObject[] dropPrefabs; // ������ �������� ��� �����
    private float currentHealth;
    private Slider healthSlider;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthSlider = GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth <= 0f) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        SetHealthUI();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // ��������� ������� �������� � �������
        if (dropPrefabs.Length > 0)
        {
            // �������� ��������� ������ �� �������
            int randomIndex = Random.Range(0, dropPrefabs.Length);

            // ������� ��������� ������ �� ����� �����
            Instantiate(dropPrefabs[randomIndex], transform.position, Quaternion.identity);
        }

        // ���������� �����
        Destroy(gameObject);
    }
}


