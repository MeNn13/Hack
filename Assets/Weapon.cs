using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    public float damage = 21;
    public float fireRate = 1;
    public float range;

    public GameObject fireVFX;
    public GameObject bloodVFX;

    public ParticleSystem ParticleSystem;
    
    public AudioClip shotSFX;
//    public AudioSource audioSource;

    public Camera _cam;

    public Transform bulletSpawn;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        //Instantiate(fireVFX,bulletSpawn.position,bulletSpawn.rotation);
        ParticleSystem.Play();
        
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position,
                _cam.transform.forward,
                out hit, range))
        {
            if (hit.collider.CompareTag("Enemy")) // проверяем, попали ли во врага
            {
                Instantiate(bloodVFX,hit.point,bulletSpawn.rotation);
            }
        }
    }
    
    
                    
                

}
