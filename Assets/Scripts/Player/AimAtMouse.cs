using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{
    public bool aimAtMouseEnabled = true;
    public bool stayWithinAngleRange = true;
    public float minimumAngle = -30f;
    public float maximumAngle = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookAt = mouseScreenPosition;
        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        if (stayWithinAngleRange) {
            if (AngleDeg > maximumAngle) AngleDeg = maximumAngle;
            if (AngleDeg < minimumAngle) AngleDeg = minimumAngle;
        }
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

    }
}
