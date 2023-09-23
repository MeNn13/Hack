using UnityEngine;

public class Weapon : MonoBehaviour, IAttack
{
    [Header("Attributes")]
    [SerializeField] private int damage = 20;
    [SerializeField] private float fireRate = 1;
    [SerializeField] private float range;

    [Header("Unity Setup Reference")]
    [SerializeField] private GameObject bloodVFX;
    [SerializeField] private ParticleSystem particle_System;
    [SerializeField] private Transform bulletSpawn;

    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;

    Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        particle_System.Play();
        _source.PlayOneShot(_clip);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(_cam.transform.position, _cam.transform.forward, range);
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Instantiate(bloodVFX, hit.point, bulletSpawn.rotation);
                Enemy enemy = hit.collider.gameObject.GetComponentInParent<Enemy>();
                Attack(enemy);
            }
        }
    }

    public void Attack(IDamageable damageable)
    {
        damageable.GetDamage(damage);
    }
}
