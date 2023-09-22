using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    public void Die(TypeUnit unit)
    {
        if (unit == TypeUnit.Player)
            gameObject.SetActive(true);
    }
}
