using UnityEngine;

public class CursorChange : MonoBehaviour
{
    [SerializeField] Vector2 normalHotSpot;
    [SerializeField] private Texture2D cursorEnter;
    [SerializeField] private Texture2D cursorExit;
    [SerializeField] private AudioSource audio;

    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursorEnter, normalHotSpot, CursorMode.Auto);
        audio.PlayOneShot(audio.clip);
    }

    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursorExit, normalHotSpot, CursorMode.Auto);
    }

}
