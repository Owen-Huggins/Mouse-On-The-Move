using UnityEngine;

public class SpiderPatrolController : MonoBehaviour
{
    enum State
    {
        Patrol,
        Attack
    }

    private State currentState;

    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float attackRange = 5f;

    private Animator animator;
    private Transform playerTransform;
    private Transform currentTarget;

    void Start()
    {
        currentState = State.Patrol;
        animator = GetComponent<Animator>();
        animator.SetInteger("currState", 0);

        GameObject player = GameObject.FindGameObjectWithTag("Mouse");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("SpiderPatrolController: No player object with 'Mouse' tag found.");
        }

        currentTarget = pointA;
    }

    void Update()
    {
        if (playerTransform == null) return;

        if (Vector3.Distance(transform.position, playerTransform.position) < attackRange)
        {
            SetAttack();
        }
        else if (currentState == State.Attack && Vector3.Distance(transform.position, playerTransform.position) >= attackRange)
        {
            SetPatrol();
        }

        if (currentState == State.Patrol)
        {
            Patrol();
        }
        else if (currentState == State.Attack)
        {
            RotateTowards(playerTransform.position);
            MoveTowards(playerTransform.position);
        }
    }

    void Patrol()
    {
        if (currentTarget == null) return;

        RotateTowards(currentTarget.position);
        MoveTowards(currentTarget.position);

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.5f)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - transform.position;
        directionToTarget.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void MoveTowards(Vector3 targetPosition)
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

    public void SetAttack()
    {
        currentState = State.Attack;
        animator?.SetInteger("currState", 1);
    }

    public void SetPatrol()
    {
        currentState = State.Patrol;
        animator?.SetInteger("currState", 0);
    }
}
