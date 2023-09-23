using TMPro;
using UnityEngine;

public class Job : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private byte count;
    [SerializeField] private TypeUnit unit;

    [Header("Unity Setup Reference")]
    [SerializeField] private GameObject jobPanel;
    [SerializeField] private TextMeshProUGUI jobText;

    public bool Done = false;

    private byte currentCount = 0;

    private void OnEnable()
    {
        Dialog.OnApplyJob += AddJob;
        EventBus.OnEnemyDie += JobUpdate;
    }

    private void OnDisable()
    {
        Dialog.OnApplyJob -= AddJob;
    }

    private void AddJob(TypeJob job)
    {
        if (job == TypeJob.EnemyKill)
        {
            jobPanel.SetActive(true);
            Done = true;
            jobText.text = $"����� {currentCount} �� {count} {unit}��";
        }
        else if (job == TypeJob.BossKill)
        {
            jobPanel.SetActive(true);
            Done = true;
            jobText.text = "������ ����";
        }
    }

    private void JobUpdate(TypeUnit enemy)
    {
        if (enemy == unit)
        {
            currentCount++;
            jobText.text = $"����� {currentCount} �� {count} {unit}��";

            if (currentCount == count)
            {
                Done = true;
                jobText.text = "������ �����";
            }
        }    
    }
}
