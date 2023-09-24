using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        if (SceneManager.sceneCount == 1)
        {
            int level = SceneManager.GetActiveScene().buildIndex;
            LoadLevel(++level);
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

}
