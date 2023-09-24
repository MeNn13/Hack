using UnityEngine;

public class CursorChange : MonoBehaviour
{
    [SerializeField] Vector2 normalHotSpot;
    [SerializeField] private Texture2D cursorEnter;
    [SerializeField] private Texture2D cursorExit;

    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursorEnter, normalHotSpot, CursorMode.Auto);
    }

    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursorExit, normalHotSpot, CursorMode.Auto);
    }
}
