using UnityEngine;

public class SpiderController : MonoBehaviour
{
    enum State
    {
        Idle,
        Attack
    }

    private State currentState;
    private float moveSpeed = 1.75f;
    private float rotationSpeed = 1.5f;
    private Animator animator;
    private Transform playerTransform;

    void Start()
    {
        currentState = State.Idle;
        animator = GetComponent<Animator>();
        animator.SetInteger("currState", 0);


        GameObject player = GameObject.FindGameObjectWithTag("Mouse");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("SpiderController: No player object with 'Mouse' tag found.");
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        RotateTowards(playerTransform.position);

        if (Vector3.Distance(transform.position, playerTransform.position) < 5f)
        {
            SetAttack();
        }

        if (currentState == State.Attack)
        {
            MoveTowards(playerTransform.position);
        }
    }

    void RotateTowards(Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - transform.position;
        directionToTarget.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, directionToTarget, rotationSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
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

    public void SetIdle()
    {
        currentState = State.Idle;
        animator?.SetInteger("currState", 0);
    }
}
