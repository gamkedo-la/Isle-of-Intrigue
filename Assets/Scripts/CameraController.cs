using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.3f;

    private Vector3 offset;


    private void Start()
    {

        offset = Camera.main.transform.position - player.position;
        offset.z = -10;

    }

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos + offset, smoothTime);

    }
}
