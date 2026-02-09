using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;

public class MilestoneDataSO : ScriptableObject
{
    /*public string milestoneName; //name
    public VideoClip videoToPlay; 
    public AnimationClip animToPlay;
    [TextArea] public string[] subtitles;
    public Sprite imgToShow;*/

    //instead of setting all of these in SO we can just use prefab!,
    public string milestoneName;
    public List<AssetConfig> assets = new List<AssetConfig>();

    


}
