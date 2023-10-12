using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;
    private Vector3 moveDirection;

    public void SetMoveDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    private void Update()
    {
        transform.position += moveDirection * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ZombieHealth zombieHealth = collision.gameObject.GetComponent<ZombieHealth>();
        if (zombieHealth != null)
        {
            zombieHealth.TakeDamage(25f); // ��������� ���� � ������� Zombie
        }
        Destroy(gameObject);
    }
}

