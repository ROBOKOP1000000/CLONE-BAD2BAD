using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D; // ������ �� ��������� Rigidbody2D ������.
    [SerializeField] private FixedJoystick _joystick; // ������ �� �������� ��� ���������� ���������.
    [SerializeField] private Animator _animator; // ������ �� ��������� ��������� ��� ���������� ����������.
    [SerializeField] private float _moveSpeed; // �������� �������� ������.
    public TextMeshProUGUI ammoTextMesh; // ����� �� ����� � ���������� 


    public AutomaticGun automaticGun; // ������ �� ������ AutomaticGun.

    private Vector2 lastMoveDirection = Vector2.right; // ��������� ����������� �������� ������.
    private Vector2 lastPosition; // ��������� ������� ������.
    private float lastScaleX; // ��������� ������� �� ��� X ������.

    private float minX = -10f; // ����������� �������� ���������� X, �������������� ��������� ������
    private float maxX = 10f; // ������������ �������� ���������� X, �������������� ��������� ������
    private float minY = -10f; // ����������� �������� ���������� Y, �������������� ��������� ������
    private float maxY = 10f; // ������������ �������� ���������� Y, �������������� ��������� ������

    private void Start()
    {
        // ������������� ��������� �������� ��� ������ �����. ��������� ������� � �������.
        lastPosition = transform.position;
        lastScaleX = transform.localScale.x;
    }

    private void Update()
    {
        // �������� ������� ������ � ���������.
        Vector2 moveDirection = new Vector2(_joystick.Horizontal, _joystick.Vertical);

        // ���������, ��������� �� �����.
        bool isMoving = moveDirection.magnitude > 0.1f;

        // ��������� �������� � ������� ������.
        UpdateAnimation(isMoving, moveDirection);
        UpdateScale(isMoving, moveDirection);

        // ���� ����� ���������, ��������� ��� ������� � ��������� ��.
        if (isMoving)
        {
            Vector2 newPosition = (Vector2)transform.position + moveDirection.normalized * _moveSpeed * Time.fixedDeltaTime;

            // ������������ ����� ������� ������ � �������� minX, maxX, minY, maxY.
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            // ������������� ����� �������.
            _rigidbody2D.MovePosition(newPosition);

            // ��������� lastPosition �� ����� �������.
            lastPosition = newPosition;
        }
        else
        {
            // ���� ����� �� ���������, ������������� ���.
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void UpdateAnimation(bool isMoving, Vector2 moveDirection)
    {
        // ��������� ��������� �������� ������ � ����������� �� ��� ���������.
        if (isMoving)
        {
            // �������� �������� "Player move".
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            // ��������� �������� "Player move", ����� ����� �� ���������.
            _animator.SetBool("IsMoving", false);
        }
    }

    private void UpdateScale(bool isMoving, Vector2 moveDirection)
    {
        // ��������� ��������� ������ � ����������� �� ��� ����������� ��������.
        if (isMoving)
        {
            // ���� �������� ������, ������������� ������� �� X �� 1, ����� -1.
            if (moveDirection.x > 0)
            {
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
                lastScaleX = 1f;
            }
            else if (moveDirection.x < 0)
            {
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
                lastScaleX = -1f;
            }
        }
        else
        {
            // ���� ����� ����� �� �����, ��������� ��������� �������.
            transform.localScale = new Vector3(lastScaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    private void LateUpdate()
    {
        // ��� ��������� ������, ��������� ��������� ������� � �������.
        lastPosition = transform.position;
        lastScaleX = transform.localScale.x;
    }
    public Vector3 GetPlayerDirection()
    {
        return new Vector3(lastScaleX, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("�������"))
        {
            Destroy(other.gameObject);
            int ammoToAdd = 10; // ���������� �������� ��� ����������
            automaticGun.AddAmmo(ammoToAdd); // �������� ����� AddAmmo �� ������� automaticGun
            UpdateAmmoText();
        }
    }

    private void UpdateAmmoText()
    {
        ammoTextMesh.text = automaticGun.GetAmmo().ToString(); // ��������� ����������� ���������� �������� �� AutomaticGun
    }
}




