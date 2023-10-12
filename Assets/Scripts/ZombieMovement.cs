
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    private Transform target; // ���� (Player)
    public Animator animator; // ������ �� ��������� ��������� Zombie
    NavMeshAgent agent; // ������ �� ��������� NavMeshAgent ��� ����������� Zombie

    public float radius = 4f; // ������, � ������� Zombie ������ ��������� � ������
    public AnimationClip[] randomIdleAnimations; // ������ ��������� �������� � �����

    private bool isPlayingIdleAnimation = false; // ����, �����������, ������������� �� �������� � �����

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // �������� ��������� NavMeshAgent
        agent.updateRotation = false; // ��������� �������������� �������� ������
        agent.updateUpAxis = false; // ��������� �������������� ������������ ������ �� ���������
        animator = GetComponent<Animator>(); // �������� ��������� ��������� Zombie
        target = GameObject.FindGameObjectWithTag("Player").transform; // ������� ������ (Player) �� ���� � �������� ��� Transform
    }

    private void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position); // ���������� �� ������

        if (distanceToTarget <= radius) // ���� ����� ��������� � ������� �������� Zombie
        {
            agent.SetDestination(target.position); // ������������� ������� ������ ��� ���� ��� ������

            float moveX = target.position.x - transform.position.x; // ������������ ������� �� X ����� Zombie � �������

            // ������������� ��������� ��������� � ����������� �� ����������� ��������
            animator.SetBool("IsMovingLeft", moveX < 0f);
            animator.SetBool("IsMovingRight", moveX > 0f);

            // ���� Zombie ��������, ������������� ������������ �������� � �����
            if (isPlayingIdleAnimation)
            {
                StopCoroutine(PlayRandomIdleAnimation());
                isPlayingIdleAnimation = false;
            }
        }
        else
        {
            agent.SetDestination(transform.position); // ������������� �������� ������ � ������������� ������� ������� Zombie

            // ���� Zombie ����� ���������� � �� ������������� �������� � �����, ��������� �������� ��� ������������ �������� � �����
            if (!isPlayingIdleAnimation && !animator.GetBool("IsMovingLeft") && !animator.GetBool("IsMovingRight"))
            {
                StartCoroutine(PlayRandomIdleAnimation());
            }

            // ���������� ��������� �������� ��������
            animator.SetBool("IsMovingLeft", false);
            animator.SetBool("IsMovingRight", false);
        }
    }

    private IEnumerator PlayRandomIdleAnimation()
    {
        isPlayingIdleAnimation = true;

        // ����������� ��������� �������� �� �������
        if (randomIdleAnimations.Length > 0)
        {
            int randomIndex = Random.Range(0, randomIdleAnimations.Length);
            animator.Play(randomIdleAnimations[randomIndex].name);
        }

        // ���� ��������� ����� ����� ������������� ��������� ��������
        float waitTime = Random.Range(1f, 5f);
        yield return new WaitForSeconds(waitTime);

        isPlayingIdleAnimation = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius); // ������ ������� ���� � ��������� Unity, �������������� ������ �������� Zombie
    }
}



















