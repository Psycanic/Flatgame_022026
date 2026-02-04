using System;
using UnityEngine;

public class GameEvents : Singleton<GameEvents>
{
    public event Action<MilestoneDataSO> onMilestoneReached;

    public event Action OnCinematicFinished;

    public void TriggerMilestone(MilestoneDataSO data) => onMilestoneReached?.Invoke(data);
    public void finishCinematic() => OnCinematicFinished?.Invoke();

    

}
