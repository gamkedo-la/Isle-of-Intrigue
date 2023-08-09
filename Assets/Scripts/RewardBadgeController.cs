using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RewardBadgeController : MonoBehaviour
{
    public List<GameObject> rewardBadge = new List<GameObject>();
    public List<GameObject> weapons = new List<GameObject>();
    public float speed;
    public Transform player;
    int rand;

    public void TakeReward(Transform pos)
    {
        string currentWeaponName = CurrentWeapon();

        do
        {
            rand = UnityEngine.Random.Range(0, rewardBadge.Count);
            GameObject reward = Instantiate(rewardBadge[rand], pos.position, pos.transform.rotation);

            if (reward.name != currentWeaponName)
            {
                StartCoroutine(MoveRewardTowardsPlayer(reward));
                break;
            }
            else
            {
                Destroy(reward);
            }
        } while (true);
    }

    private string CurrentWeapon()
    {
        foreach (GameObject weapon in weapons)
        {
            if (weapon.activeInHierarchy)
            {
                string objName = weapon.name;
                return objName;
            }
        }
        return string.Empty;
    }

    private IEnumerator MoveRewardTowardsPlayer(GameObject reward)
    {
        while (Vector3.Distance(reward.transform.position, player.position) > 0.01f)
        {
  
            reward.transform.position =Vector3.MoveTowards(reward.transform.position, player.position, speed * Time.deltaTime);
            yield return null;
        }

    }
}




