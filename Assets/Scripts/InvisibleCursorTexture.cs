using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleCursorTexture : MonoBehaviour
{
    public static Texture2D CreateCrosshairTexture(int size, Color color)
    {
        Texture2D texture = new Texture2D(size, size, TextureFormat.ARGB32, false);
        Color transparent = new Color(0, 0, 0, 0); // Transparent color

        // Calculate the center position
        int centerX = size / 2;
        int centerY = size / 2;

        // Calculate the radius of the round borders
        int radius = size / 2;

        // Draw the round borders
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Vector2 center = new Vector2(centerX, centerY);
                Vector2 current = new Vector2(x, y);

                // Check if the current pixel is outside the round borders
                if (Vector2.Distance(center, current) > radius)
                {
                    texture.SetPixel(x, y, transparent);
                }
            }
        }

        // Draw the red plus sign
        int halfThickness = 2; // Adjust the thickness as needed
        for (int x = centerX - halfThickness; x <= centerX + halfThickness; x++)
        {
            for (int y = 0; y < size; y++)
            {
                texture.SetPixel(x, y, color); // Vertical line
            }
        }

        for (int y = centerY - halfThickness; y <= centerY + halfThickness; y++)
        {
            for (int x = 0; x < size; x++)
            {
                texture.SetPixel(x, y, color); // Horizontal line
            }
        }

        // Apply changes to the texture
        texture.Apply();

        return texture;
    }

}
