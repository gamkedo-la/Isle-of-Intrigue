using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Camera cam;

    [Serializable]
    public class ParallaxObject
    {
        public Transform transform;
        public float intensity;

        [HideInInspector] public Vector3 basePosition;
    }
    public List<ParallaxObject> parallaxObjects = new();

    void Start()
    {
        cam = Camera.main;

        foreach (var parallaxObject in parallaxObjects)
        {
            parallaxObject.basePosition = parallaxObject.transform.position;// - cam.transform.position;
        }
    }

    void LateUpdate()
    {
        foreach (var parallaxObject in parallaxObjects)
        {
            Vector3 position = Vector3.Lerp(parallaxObject.basePosition, cam.transform.position, parallaxObject.intensity);
            position.y = parallaxObject.basePosition.y;
            position.z = 0.0f;
            parallaxObject.transform.position = position;
        }
    }
}
