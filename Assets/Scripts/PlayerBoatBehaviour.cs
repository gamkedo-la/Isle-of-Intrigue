using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class PlayerBoatBehaviour : MonoBehaviour
{
    public float rotationRange = 5f;
    public float rotationSpeed = 2f;

    public Transform enemyShip;
    public Transform seaMonster;
   

    public float movementSpeed;

    public float driftSpeed = 1f;

    public AudioSource src;
  

    private float startingRotation;
    Cursor cursor;

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
            if(movementSpeed !=0f )
            {
            }

            movementSpeed = 0;
            src.mute = true;
        }
        else
        {
            if (movementSpeed != 2f)
            {
            }

            movementSpeed = 2f;
            src.mute = false;
        }
    }
}
