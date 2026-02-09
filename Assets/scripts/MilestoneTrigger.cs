using UnityEngine;

public class MilestoneTrigger : MonoBehaviour
{
    public MilestoneDataSO myData;
    private bool _hasTriggered = false; //prevent back n forth draggin

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_hasTriggered)
        {
            _hasTriggered = true;
            Debug.Log("Tiggegegrgered!!!");
            GameEvents.Instance.TriggerMilestone(myData);

        }
    }

}
