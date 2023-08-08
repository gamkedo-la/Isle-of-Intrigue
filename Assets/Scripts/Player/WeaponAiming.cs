using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAiming : MonoBehaviour
{
    public Transform headBone;
    public Transform handsBone;

    public float headAimingSpeed = 10f;
    public float handAimingSpeed = 10f;

    public float verticalHeadAimRange = 30f;
    public float verticalHandAimRange = 1.5f;

    public float minHeadAngle = -90f;
    public float maxHeadAngle = 90f;

    public float minHandAngle = -90f;
    public float maxHandAngle = 90f;

    private float currentHeadRotationAngle;
    private float currentHandRotationAngle;

    private void Start()
    {
        currentHeadRotationAngle = headBone.rotation.eulerAngles.z;
        currentHandRotationAngle = handsBone.localRotation.eulerAngles.z;
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 lookDirection = mousePosition - transform.position;
        currentHeadRotationAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        currentHeadRotationAngle = Mathf.Clamp(currentHeadRotationAngle, minHeadAngle, maxHeadAngle);

        headBone.rotation = Quaternion.Lerp(headBone.rotation, Quaternion.Euler(0f, 0f, currentHeadRotationAngle), Time.deltaTime * headAimingSpeed);

        // Calculate the normalized aiming angle for the hands
        float normalizedHandAimAngle = Mathf.InverseLerp(minHeadAngle, maxHeadAngle, currentHeadRotationAngle);
        currentHandRotationAngle = Mathf.Lerp(minHandAngle, maxHandAngle, normalizedHandAimAngle);

        handsBone.localRotation = Quaternion.Euler(0f, 0f, currentHandRotationAngle);
    }
}
