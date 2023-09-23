using System;
using System.Collections;
using UnityEngine;

public class DissolveShader : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinned;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private float dissolveRate = 0.0125f;
    [SerializeField] private float refreshRate = 0.025f;

    private Material[] materials;
    private bool _isDie = false;

    void Start()
    {
        if (skinned != null)
            materials = skinned.materials;
    }

    void Update()
    {
        if (_isDie)
            StartCoroutine(StartDissolve());
    }

    private IEnumerator StartDissolve()
    {
        if (materials.Length > 0)
        {
            float counter = 0;

            while (materials[0].GetFloat("_DissolveAmount") < 1)
            {
                counter += dissolveRate;

                for (int i = 0; i < materials.Length; i++)
                    materials[i].SetFloat("_DissolveAmount", counter);

                yield return new WaitForSeconds(refreshRate);
            }
        }

        _isDie = false;
    }

    public void Die()
    {
        _isDie = true;
        particle.Play();
    }
}
