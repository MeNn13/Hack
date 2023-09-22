using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float damage = 21;
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        particle_System.Play();

        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position,
                _cam.transform.forward,
                out hit, range))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Instantiate(bloodVFX, hit.point, bulletSpawn.rotation);
            }
        }
    }
}
