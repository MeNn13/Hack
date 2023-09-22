using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable, IAttack
{
    [Header("Attributes")]
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private float cooldown;

    [Header("Unity Setup Reference")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Animator animator;

    Player player;
    bool _isAttack;
    float currentCooldown;

    private void Start()
    {
        currentCooldown = cooldown;
    }

    void Update()
    {
        Attack(player);
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Player>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (_isAttack)
        {
            agent.isStopped = true;
            return;
        }
        else
            agent.isStopped = false;

        if (other.CompareTag("Player"))
            agent.SetDestination(other.transform.position);
    }

    public void GetDamage(int value)
    {
        if (health > value)
            health -= value;
        else
            Destroy(gameObject);
    }

    public void Attack(IDamageable damageable)
    {
        _isAttack = Physics.CheckSphere(transform.position, 5f, layerMask);

        if (_isAttack)
        {
            if (currentCooldown > 0)
                currentCooldown -= Time.deltaTime;
            else
            {
                damageable.GetDamage(damage);
                currentCooldown = cooldown;
            }
        }
    }
}
