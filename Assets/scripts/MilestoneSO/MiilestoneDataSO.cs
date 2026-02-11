using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; // 如果要用 VideoClip 记得加这个

[CreateAssetMenu(fileName = "NewMilestone", menuName = "ScriptableObjects/Milestone")]
public class MilestoneDataSO : ScriptableObject
{
    [Header("name")]
    public string milestoneName;

    [Header("assets")]
    //prefabs
    public List<AssetConfig> assets = new List<AssetConfig>();

    [Header("video/sond")]
    public VideoClip videoToPlay;
    public AudioClip soundEffect; 

    [Header("textarea")]
    [TextArea(3, 10)] 
    public string[] subtitles;
}

