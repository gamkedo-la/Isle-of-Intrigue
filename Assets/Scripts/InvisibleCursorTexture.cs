using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleCursorTexture : MonoBehaviour
{
    public static Texture2D CreateCrosshairTexture(int size)
    {
        // Create a blank texture with a transparent background
        Texture2D texture = new Texture2D(size, size, TextureFormat.ARGB32, false);
        Color transparent = new Color(0, 0, 0, 0); // Transparent color

        // Clear the entire texture with transparent color
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                texture.SetPixel(x, y, transparent);
            }
        }

        // Calculate the center position
        int centerX = size / 2;
        int centerY = size / 2;

        // Draw the black plus sign
        int thickness = 2; // Adjust the thickness as needed
        for (int x = centerX - thickness; x <= centerX + thickness; x++)
        {
            for (int y = centerY - size / 4; y <= centerY + size / 4; y++)
            {
                texture.SetPixel(x, y, Color.black); // Vertical line
            }
        }

        for (int y = centerY - thickness; y <= centerY + thickness; y++)
        {
            for (int x = centerX - size / 4; x <= centerX + size / 4; x++)
            {
                texture.SetPixel(x, y, Color.black); // Horizontal line
            }
        }

        // Apply changes to the texture
        texture.Apply();

        return texture;
    }
}
