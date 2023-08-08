using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoatBehaviour : MonoBehaviour
{
    public float rotationRange = 5f;
    public float rotationSpeed = 2f;

    public Transform enemyShip;
    public Transform seaMonster;

    public float movementSpeed;

    public float driftSpeed = 1f;

    private float startingRotation;

    public float stoppingDistance = 2f;

    bool anyAttackerClose;

    public List<Transform> attackers = new List<Transform>();
    private List<Transform> attackersToRemove = new List<Transform>();

    private void Start()
    {
        movementSpeed = 2f;
        startingRotation = transform.rotation.eulerAngles.z;
        anyAttackerClose = false;
    }

    private void Update()
    {
        float rotationOffset = Mathf.Sin(Time.time * driftSpeed) * rotationRange;
        float newRotation = startingRotation + rotationOffset;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newRotation);

        CheckEnemyBoatDistance();

        if (movementSpeed != 0)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }

        Debug.Log(movementSpeed);
    }

    private void CheckEnemyBoatDistance()
    {
        anyAttackerClose = false; 
        attackersToRemove.Clear(); 

        for (int i = 0; i < attackers.Count; i++)
        {
            Transform attacker = attackers[i];

            if (attacker == null)
            {
                attackersToRemove.Add(attacker); 
                continue;
            }

            if (Vector2.Distance(transform.position, attacker.position) < stoppingDistance)
            {
                Debug.Log(attacker.gameObject.name);
                anyAttackerClose = true;
                break;
            }
        }

        foreach (Transform attackerToRemove in attackersToRemove)
        {
            attackers.Remove(attackerToRemove);
        }

        if (anyAttackerClose)
        {
            movementSpeed = 0;
        }
        else
        {
            movementSpeed = 2f;
        }
    }
}
