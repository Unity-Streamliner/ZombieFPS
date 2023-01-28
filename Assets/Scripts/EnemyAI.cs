using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 15f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoke = false;


    Animator _animator;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoke)
        {
            EngageTarget();
        } else if (distanceToTarget <= chaseRange)
        {
            isProvoke = true;
            //
        }
        bool isMoving = navMeshAgent.velocity.magnitude > 0.1f;
        _animator.SetBool("isMoving", isMoving);
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        } 
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            ShouldAttackTarget(true);
        } else 
        {
            ShouldAttackTarget(false);
        }
    }

    private void ChaseTarget()
    {
        print("dbg: ChaseTarget");
        navMeshAgent.SetDestination(target.position);
    }

    private void ShouldAttackTarget(bool attack)
    {
        print("dbg: AttackTarget");
        _animator.SetBool("isAttacking", attack);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
