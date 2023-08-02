using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAiming : MonoBehaviour
{
    public Transform headBone;
    public Transform handsBone;

    // Adjust these values to control the aiming speed
    public float aimingSpeed = 10f;
    public float verticalAimRange = 1.5f;

    public float minAngle = -90f;
    public float maxAngle = 90f;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 lookDirection = mousePosition - transform.position;
        float rotationAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        rotationAngle = Mathf.Clamp(rotationAngle, minAngle, maxAngle);

        headBone.rotation = Quaternion.Lerp(headBone.rotation, Quaternion.Euler(0f, 0f, rotationAngle), Time.deltaTime * aimingSpeed);

        float verticalAimOffset = Mathf.Lerp(-verticalAimRange, verticalAimRange, (rotationAngle - minAngle) / (maxAngle - minAngle));

        handsBone.localPosition = new Vector3(handsBone.localPosition.x, verticalAimOffset, handsBone.localPosition.z);

    }
}
