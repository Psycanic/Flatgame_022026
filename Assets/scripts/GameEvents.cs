using System;
using UnityEngine;

public class GameEvents : Singleton<GameEvents>
{
    public event Action<MilestoneDataSO> onMilestoneReached;

    public event Action<float> OnMouseScroll;
    public event Action OnMovingKeys;


    public void TriggerMilestone(MilestoneDataSO data) {
        onMilestoneReached?.Invoke(data);
    }

    public void callMouseScroll(float scrollDelta) { 
        OnMouseScroll?.Invoke(scrollDelta);
    }
    
    

}
