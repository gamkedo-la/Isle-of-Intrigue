using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBadgeController : MonoBehaviour
{
    public List<GameObject> rewardBadge = new List<GameObject>();

    public float speed;
    public Transform player;
    int rand;


    public void TakeReward(Transform pos)
    {
        rand = Random.Range(0, 2);
        GameObject reward = Instantiate(rewardBadge[rand], pos.position, pos.transform.rotation);
        Vector3.Lerp(reward.transform.position, player.position, Time.deltaTime * speed);
        StartCoroutine(MoveRewardTowardsPlayer(reward));
    }

    private IEnumerator MoveRewardTowardsPlayer(GameObject reward)
    {
        while (Vector3.Distance(reward.transform.position, player.position) > 0.01f)
        {
            reward.transform.position = Vector3.MoveTowards(reward.transform.position, player.position, speed * Time.deltaTime);
            yield return null;
        }
    }

}




