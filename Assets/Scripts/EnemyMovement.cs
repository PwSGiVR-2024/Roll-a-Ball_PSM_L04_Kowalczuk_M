using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float range = 1f;
    [SerializeField] private Transform player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject killBox;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<MovementController>().transform;
        AttackStop();
    }

    private void Update()
    {
        if (player)
        {
            agent.destination = player.position;
            if(Vector3.Distance(player.position, transform.position) <= range)
            {
                animator.SetTrigger("Attack");
            }
        }
        else
        {
            animator.ResetTrigger("Attack");
            AttackStop();
        }
    }

    public void Attack()
    {
        killBox.SetActive(true);
    }

    public void AttackStop()
    {
        killBox.SetActive(false);
    }
}
