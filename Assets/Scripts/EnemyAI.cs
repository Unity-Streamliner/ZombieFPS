using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 15f;
    
    float distanceToTarget = Mathf.Infinity;
    bool isProvoke = false;


    Animator _animator;
    NavMeshAgent _navMeshAgent;
    EnemyHealth _health;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_health.IsDead())
        { 
            enabled = false;
            _navMeshAgent.enabled = false;
            return;
        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoke)
        {
            EngageTarget();
        } else if (distanceToTarget <= chaseRange)
        {
            isProvoke = true;
            //
        }
        bool isMoving = _navMeshAgent.velocity.magnitude > 0.1f;
        _animator.SetBool("isMoving", isMoving);
    }

    public void OnDamageTaken()
    {
        isProvoke = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= _navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        } 
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
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
        _navMeshAgent.SetDestination(target.position);
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
