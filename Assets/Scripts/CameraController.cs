using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public float smoothing = 0.1f;

    private Vector3 offset;


    private void Start()
    {
        offset = Camera.main.transform.position - player.position;
    }

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = new Vector3(player.position.x, player.position.y, 0f);
        transform.position = Vector3.Lerp(transform.position, targetPos + offset, smoothing);
    }
}
