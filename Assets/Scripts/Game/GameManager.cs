using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        int level = SceneManager.GetActiveScene().buildIndex;

        if (level == 1)
        {
            Data.Instance.GameInfo.Level = ++level;
            Data.Instance.Save();
            LoadSaveScene();            
        }
    }

    public void LoadLevel(int level)
    {
        Data.Instance.GameInfo.Level = level;
        Data.Instance.Save();
        SceneManager.LoadScene(level);
    }

    public void LoadSaveScene()
    {
        SceneManager.LoadScene(Data.Instance.GameInfo.Level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
