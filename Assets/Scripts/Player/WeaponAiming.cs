using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAiming : MonoBehaviour
{
    public Transform headBone;
    public Transform handsBone;
    public Transform aimer; // a target reticle that follows the mouse

    public float headAimingSpeed = 10f;
    public float handAimingSpeed = 10f;

    public float verticalHeadAimRange = 30f;
    public float verticalHandAimRange = 1.5f;

    public float minHeadAngle = -90f;
    public float maxHeadAngle = 90f;

    public float minHandAngle = -90f+45f;
    public float maxHandAngle = 90f+45f;

    private float currentHeadRotationAngle;
    private float currentHandRotationAngle;

    private void Start()
    {
        currentHeadRotationAngle = headBone.rotation.eulerAngles.z;
        currentHandRotationAngle = handsBone.localRotation.eulerAngles.z;
    }

    private void Update()
    {
        if(Time.timeScale != 0)
        {
            WeaponMovement();
        }
    }

    private void WeaponMovement()
    {
        // old way which doesn't include z so the world pos is far away
        // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // mousePosition.z = 0f;

        //Vector3 firePosition = transform.position; // ERROR: this is near the feet
        //Vector3 firePosition = handsBone.position; // ERROR: this is near the knees
        Vector3 firePosition = transform.position;
        // centered on the chest! FIXME: actually grab gun barrel or shoulder pos?
        firePosition.y += 2.5f;
        firePosition.x -= 0.25f;

        // the 10f is "units from the camera" to match the camera position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));//firePosition.z)); 
        mousePosition.z = firePosition.z;

        Vector3 lookDirection = mousePosition - firePosition;
        currentHeadRotationAngle = 90f + (Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg);

        currentHeadRotationAngle = Mathf.Clamp(currentHeadRotationAngle, minHeadAngle, maxHeadAngle);

        headBone.rotation = Quaternion.Lerp(headBone.rotation, Quaternion.Euler(0f, 0f, currentHeadRotationAngle), Time.deltaTime * headAimingSpeed);

        // Calculate the normalized aiming angle for the hands
        float normalizedHandAimAngle = Mathf.InverseLerp(minHeadAngle, maxHeadAngle, currentHeadRotationAngle);
        currentHandRotationAngle = Mathf.Lerp(minHandAngle, maxHandAngle, normalizedHandAimAngle);
        handsBone.localRotation = Quaternion.Euler(0f, 0f, currentHandRotationAngle + (45f * Mathf.Deg2Rad));

        //handsBone.rotation = Quaternion.Euler(0f, 0f, currentHeadRotationAngle+(90f*Mathf.Deg2Rad));

        // lol silly but effective! just oriented strangely doe to handbone being at feet pos
        // handsBone.transform.LookAt(mousePosition);

        // aiming reticle - useful for debugging
        if (aimer) aimer.transform.position = mousePosition;

        // for debug only
        Color color = new Color(1f, 0f, 0f, 1f);
        Debug.DrawLine(firePosition, mousePosition, color);
    }
}
