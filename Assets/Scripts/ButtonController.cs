using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button deleteButton; // ������ �� ������ "�������"
    public Image buttonImage; // ������ �� �������� �� �������� ������
    public CanvasManager canvasManager; // ������ �� CanvasManager

    private void Start()
    {
        // ��������� ������ "�������" ��� ������ ����.
        deleteButton.gameObject.SetActive(false);
    }

    public void OnMainButtonClick()
    {
        // ���������� ������ "�������" ��� ������� �� �������� ������.
        deleteButton.gameObject.SetActive(true);
    }

    public void OnDeleteButtonClick()
    {
        // �������� �������� �� �������� ������
        buttonImage.gameObject.SetActive(false);

        // �������� ������ "�������" ����� �������
        deleteButton.gameObject.SetActive(false);
    }

    // ��������� �����, ������� ����� ���������� ��� ��������������� � ��������� "makarov"
    public void OnMakarovCollision()
    {
        // ���������� �������� �� �������� ������
        canvasManager.ShowButtonImage();
    }
}







