using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoatBehaviour : MonoBehaviour
{
    public float rotationRange = 5f; 
    public float rotationSpeed = 2f; 

    public Transform enemyShip;
    public Transform seaMonster;

    public float movementSpeed = 2f;

    public float driftSpeed = 1f;

    private float startingRotation;

    public float stoppingDistance = 2f;


    public List<Transform> attackers = new List<Transform>();



    private void Start()
    {
        startingRotation = transform.rotation.eulerAngles.z;
    }

    private void Update()
    {
        float rotationOffset = Mathf.Sin(Time.time * driftSpeed) * rotationRange;
        float newRotation = startingRotation + rotationOffset;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newRotation);

        foreach (Transform attacker in attackers)
        {
            if (attacker != null && Vector2.Distance(transform.position, attacker.position) < stoppingDistance)
            {
                return; 
            }

            else
            {
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            }
        }
    }

  

}
