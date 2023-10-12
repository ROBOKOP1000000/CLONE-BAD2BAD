using UnityEngine;
using UnityEngine.UI;

public class BackpackButtonAndPanelController : MonoBehaviour
{
    public GameObject backpackPanel; // ������ �� ������ ������ �������
    public Button backpackButton; // ������ �� ������ "������"

    private void Start()
    {
        // ��������� ������ ������� ��� ������� ����.
        backpackPanel.SetActive(false);

        // ��������� ����� OnBackpackButtonClick() ������������ ������� ��� ������� ������ "������".
        backpackButton.onClick.AddListener(OnBackpackButtonClick);
    }

    private void OnBackpackButtonClick()
    {
        // ����������� ��������� ���������� ������ (���� ���� ���������, �� �������, � ��������).
        backpackPanel.SetActive(!backpackPanel.activeSelf);

        // ��� �������, ����� ����� �������� ��� ��� ��������� ���� ��� ������� ������ ��������� ����������.
        // ��������, Time.timeScale = 0; ��� ��������� ������� � ����.
    }
}

