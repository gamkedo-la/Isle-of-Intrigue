using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.3f;
    public Vector2 minBounds, maxBounds;
    private Vector3 velocity = Vector3.zero;
    private void LateUpdate()
    {
        if (player == null) return;

        // Calculate target position
        Vector3 targetPosition = new Vector3(
        Mathf.Clamp(player.position.x, minBounds.x, maxBounds.x),
        Mathf.Clamp(player.position.y, minBounds.y, maxBounds.y),
        transform.position.z
    );

        // Smoothly move camera towards target position
        transform.position = Vector3.SmoothDamp(
        transform.position, targetPosition, ref velocity, smoothTime
    );

    }
}
