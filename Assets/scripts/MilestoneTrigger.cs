using UnityEngine;

public class MilestoneTrigger : MonoBehaviour
{
    [SerializeField]private  MilestoneDataSO myData;
    private bool _hasTriggered = false; //prevent back n forth draggin

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_hasTriggered && collision.CompareTag("MainCamera"))
        {
            if (myData = null)
            {
                Debug.Log("no data is assigned");
                return;
            }
            _hasTriggered = true;
            Debug.Log("Tiggegegrgered!!!");
            GameEvents.Instance.TriggerMilestone(myData);

        }
    }

}
