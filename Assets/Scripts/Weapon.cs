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

        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, range))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Instantiate(bloodVFX, hit.point, bulletSpawn.rotation);
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                Attack(enemy);
            }
        }
    }

    public void Attack(IDamageable damageable)
    {
        damageable.GetDamage(damage);
    }
}
