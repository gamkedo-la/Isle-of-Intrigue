using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBadgeController : MonoBehaviour
{
    public List<GameObject> rewardBadge = new List<GameObject>();
    int rand;


    public void TakeReward(Transform pos)
    {
        rand = Random.Range(0, 2);
        GameObject reward = Instantiate(rewardBadge[rand], pos.position, pos.transform.rotation);
    }

}
