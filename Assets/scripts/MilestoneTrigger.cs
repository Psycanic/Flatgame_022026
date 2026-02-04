using UnityEngine;

public class MilestoneTrigger : MonoBehaviour
{
    public MilestoneDataSO myData;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameEvents.Instance.TriggerMilestone(myData);
    }

}
