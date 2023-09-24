using System;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public static Action<TypeJob> OnApplyJob;

    [Header("Attributes")]
    [SerializeField] private float range = 10f;

    [Header("Unity Setup Reference")]
    [SerializeField] private GameObject dialogButton;
    [SerializeField] private MonoBehaviour[] disableObjects;
    [SerializeField] private Job job;

    [Header("Job")]
    [SerializeField] private GameObject[] dialogPanel;
    [SerializeField] private TypeJob[] jobs;

    Camera _cam;
    private byte index = 0;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(_cam.transform.position, _cam.transform.forward, range);
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("Resident"))
            {
                dialogButton.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {    
                    if (!job.Done)
                        Enable(false, index);
                    else
                        Enable(false, ++index);
                }
                return;
            }
            else
                dialogButton.SetActive(false);
        }
    }

    public void ApplyTask()
    {
        OnApplyJob?.Invoke(jobs[index]);
        Enable(true, index);
    }

    public void DenyTask()
    {
        Enable(true, index);
    }

    private void Enable(bool value, int indexPanel)
    {
        foreach (var obj in disableObjects)
        {
            obj.enabled = value;
        }

        if (!value)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            dialogPanel[indexPanel].SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            dialogPanel[indexPanel].SetActive(false);
        }
    }
}
