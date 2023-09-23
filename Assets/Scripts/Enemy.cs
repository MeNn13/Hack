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
    bool _isDie;

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
            Animation("Attack");
            return;
        }
        else
            agent.isStopped = false;

        if (other.CompareTag("Player"))
        {
            agent.SetDestination(other.transform.position);
            Animation("Walk");
        }
    }

    public void GetDamage(int value)
    {
        if (_isDie)
            return;

        if (health > value)
            health -= value;
        else
        {
            GetComponent<DissolveShader>().Die();
            EventBus.OnEnemyDie?.Invoke(TypeUnit.Дракон);
            Destroy(gameObject, 2);
            _isDie = true;
        }
    }

    public void Attack(IDamageable damageable)
    {
        _isAttack = Physics.CheckSphere(transform.position, 5.5f, layerMask);

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

    private void Animation(string anim)
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Attack", false);
        animator.SetBool("Dead", false);

        animator.SetBool($"{anim}", true);
    }
}
