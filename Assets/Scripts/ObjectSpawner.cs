using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public CanvasManager canvasManager; // ������ �� ��������� CanvasManager

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���������, �������� �� ����� ������� � ����� "makarov".
        if (other.CompareTag("makarov"))
        {
            // �������� �������� �� ������ � ������� CanvasManager.
            canvasManager.ShowButtonImage();

            // ��������� ������ "makarov" ��� ������������.
            Destroy(other.gameObject);
        }
    }
}



