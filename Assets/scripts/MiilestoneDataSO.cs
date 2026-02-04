using UnityEngine;
using UnityEngine.Video;

public class MilestoneDataSO : ScriptableObject
{
    public string milestoneName; //name
    public VideoClip videoToPlay; 
    public AnimationClip animToPlay;
    [TextArea] public string[] subtitles;
    public float cameraLockX; //locked camera when triggered


}
