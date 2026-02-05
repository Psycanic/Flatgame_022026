using System;
using UnityEngine;

public class GameEvents : Singleton<GameEvents>
{
    public event Action<MilestoneDataSO> onMilestoneReached;

    public event Action<float> OnMouseDrag;
    public event Action<float> OnMouseScroll;


    public void TriggerMilestone(MilestoneDataSO data) {
        onMilestoneReached?.Invoke(data);
    }

    public void callMouseScroll(float scrollDelta) { 
        OnMouseScroll?.Invoke(scrollDelta);
    }
    public void callMouseDrag(float dragDelta)
    {
        Debug.Log("mousedrag called!");
        OnMouseDrag?.Invoke(dragDelta);
    }




}
