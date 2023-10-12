using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Image buttonImage; // ������ �� �������� �� ������

    public void ShowButtonImage()
    {
        // �������� �������� �� ������.
        buttonImage.gameObject.SetActive(true);
    }

    public void HideButtonImage()
    {
        // �������� �������� �� ������.
        buttonImage.gameObject.SetActive(false);
    }
}


