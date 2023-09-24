using TMPro;
using UnityEngine;

public class JobController : MonoBehaviour
{
    [Header("Unity Setup Reference")]
    [SerializeField] private GameObject jobPanel;
    [SerializeField] private TextMeshProUGUI jobText;

    public bool Done = true;

    private int _count;
    private int currentCount = 0;
    public bool _completed = false;
    private TypeUnit enemy;

    private void OnEnable()
    {
        Dialog.OnApplyJob += AddJob;
        EventBus.OnEnemyDie += JobUpdate;
    }

    private void OnDisable()
    {
        Dialog.OnApplyJob -= AddJob;
        EventBus.OnEnemyDie -= JobUpdate;
    }

    private void AddJob(TypeJob job, TypeUnit unit, int count)
    {
        enemy = unit;
        _count = count;

        if (job == TypeJob.EnemyKill)
        {
            jobPanel.SetActive(true);
            Done = false;
            jobText.text = $"”бито {currentCount} из {count} {unit}ов";
        }
        else if (job == TypeJob.BossKill)
        {
            jobPanel.SetActive(true);
            Done = false;
            jobText.text = "”бейте боса";
        }
    }

    private void JobUpdate(TypeUnit unit)
    {
        if (unit == enemy)
        {
            currentCount++;
            jobText.text = $"”бито {currentCount} из {_count} {unit}ов";

            if (currentCount == _count)
            {
                Done = true;
                _completed = true;
                jobText.text = "—дайте квест";
            }
        }       
    }
}
