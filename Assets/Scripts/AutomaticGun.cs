using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutomaticGun : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����, ������� �� ����� ��������
    public Transform bulletSpawnPoint; // �����, ������ ���� ����� ��������
    public TextMeshProUGUI ammoTextMesh; // ���������� TextMeshProUGUI ��� ����������� ���������� ��������
    private int currentAmmo; // ������� ���������� ��������
    public PlayerController playerController;


    private void Start()
    {
        currentAmmo = 30; // ������������� ��������� ���������� �������� ������ 30 (����������� ��������)
        UpdateAmmoText(); // ��������� ����������� ���������� ��������
    }

    public void Shoot()
    {
        if (currentAmmo > 0) // ���������, ���� �� � ��� �������
        {
            // ������� ��������� ����
            GameObject bulletObject = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Bullet bullet = bulletObject.GetComponent<Bullet>();

            // �������� ����������� ������� ������ �� PlayerController
            Vector3 playerDirection = playerController.GetPlayerDirection();

            // ���� �������� � ����������� ������� ������
            bullet.SetMoveDirection(playerDirection);

            currentAmmo--; // ��������� ���������� �������� ����� ��������
            UpdateAmmoText(); // ��������� ����������� ���������� ��������
        }
    }

    private void UpdateAmmoText()
    {
        ammoTextMesh.text = currentAmmo.ToString(); // ��������� ����� � ����������� ��������
    }

    public bool CanShoot()
    {
        return currentAmmo > 0; // ���������, ����� �� �� �������� (���� �� �������)
    }

    public int GetAmmo()
    {
        return currentAmmo; // �������� ������� ���������� ��������
    }

    public void AddAmmo(int amount)
    {
        currentAmmo += amount; // ����������� ���������� �������� �� ��������� ��������
        UpdateAmmoText(); // ��������� ����������� ���������� ��������
    }
}



