using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public static Action<TypeJob, TypeUnit, int> OnApplyJob;

    [Header("Attributes")]
    [SerializeField] private float range = 4f;

    [Header("Unity Setup Reference")]
    [SerializeField] private GameObject interactButton;
    [SerializeField] private GameObject apllyButton;
    [SerializeField] private MonoBehaviour[] disableObjects;
    [SerializeField] private JobController jobController;

    [Header("Job")]
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI textDialog;
    [SerializeField] private Image avatar;

    Camera _cam;
    Job job;
    TypeUnit unit;

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
                interactButton.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SetDialog(hit, jobController.Done);
                }
                return;
            }
            else
                interactButton.SetActive(false);
        }
    }

    public void ApplyTask()
    {
        OnApplyJob?.Invoke(job.JobType, job.Unit, job.Count);
        dialogPanel.SetActive(false);
        Reading(false);
    }

    public void DenyTask()
    {
        dialogPanel.SetActive(false);
        Reading(false);
    }

    public void Reading(bool value)
    {
        if (value)
        {
            foreach (var obj in disableObjects)
            {
                obj.enabled = false;
            }

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            foreach (var obj in disableObjects)
            {
                obj.enabled = true;
            }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }

    private void SetDialog(RaycastHit hit, bool value)
    {
        Replica replica = hit.collider.GetComponent<Replica>();
        avatar.sprite = replica.Avatar;

        if (replica.Jobs[replica.Index] == null)
            return;

        if (value)
            job = hit.collider.GetComponent<Replica>().Jobs[++replica.Index];
        else
            job = hit.collider.GetComponent<Replica>().Jobs[replica.Index];

        if (replica.GiveJob)
            apllyButton.SetActive(true);
        else
            apllyButton.SetActive(false);

        textDialog.text = job.Description;

        dialogPanel.SetActive(true);
        Reading(true);
    }
}
