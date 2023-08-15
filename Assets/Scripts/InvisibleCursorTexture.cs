using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleCursorTexture : MonoBehaviour
{
    public static Texture2D CreateInvisibleTexture()
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.clear); // Transparent color
        texture.Apply();
        return texture;
    }
}
