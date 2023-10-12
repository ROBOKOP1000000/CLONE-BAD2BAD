using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    public GameObject gameOverPanel; // ������ �� ������ Game Over

    public float currentHealth; // ������� ������� ������ �� public

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void SetHealth(float health)
    {
        currentHealth = health;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            ShowGameOver(); // �������� ����� ����������� ������ Game Over
        }
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth;
        healthSlider.value = healthPercentage;
    }

    private void ShowGameOver()
    {
        gameOverPanel.GetComponent<GameOverManager>().ShowGameOver();
    }
}

