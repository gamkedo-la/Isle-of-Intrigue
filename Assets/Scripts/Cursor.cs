using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Texture2D texture;
    public Vector2 offset;
    public CursorMode cursorMode = CursorMode.Auto;

    public void Set()
    {
        if (texture == null)
        {
            texture = InvisibleCursorTexture.CreateInvisibleTexture();
        }

        UnityEngine.Cursor.SetCursor(texture, offset, cursorMode);
    }

    public static void Unset()
    {
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
