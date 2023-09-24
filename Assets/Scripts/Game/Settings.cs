using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioSource[] audios;

    private void Start()
    {
        foreach (var audio in audios)
        {
            audio.volume = Data.Instance.GameInfo.MusicVolume;
        }
    }

    private void Update()
    {
        foreach (var audio in audios)
        {
            audio.volume = Data.Instance.GameInfo.MusicVolume;
        }
    }

    public void SensitivityChange(float value)
    {
        Data.Instance.GameInfo.Sensitivity = value * 1000;
        Data.Instance.Save();
    }

    public void MusicVolumeChange(float value)
    {
        Data.Instance.GameInfo.MusicVolume = value;
        Data.Instance.Save();
    }
}
