using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private SimpleFighterAttack attack;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private FighterAnimation _enemyAnimation;
    [SerializeField] private float _attackRange = 2.5f;

    private bool _isAttacking = false;

    private void OnValidate() 
    {
        agent ??= GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if(_player == null)
        {
            return;
        }

        Transform playerTransform = _player.transform;

        if(Mathf.Abs(Vector3.Distance(transform.position, playerTransform.position)) > _attackRange)
        {
            agent.isStopped = false;
            
            agent.SetDestination(playerTransform.position);

            _enemyAnimation.Walk(true);

            _isAttacking = false;
        }
        else
        {
            agent.isStopped = true;

            _enemyAnimation.Walk(false);

            Vector3 direction = playerTransform.position - transform.position;
            direction.y = 0; // Ignore axis Y
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);

            if(!_isAttacking)
            {
                _isAttacking = true;
                attack.Attack(_enemyAnimation);

                StartCoroutine(AbilityAttack());
            }
        }
    }

    private IEnumerator AbilityAttack()
    {
        yield return new WaitForSeconds(3f);

        _isAttacking = false;
    }

    public void SetPlayer(PlayerMovement player)
    {
        _player = player;
    }

}
