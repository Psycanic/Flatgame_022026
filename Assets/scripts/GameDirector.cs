using UnityEngine;

public enum GameState
{
    Intro,      // 特殊的交互方式（只能滚轮）
    Exploring,  // 横向平移，看风景，触发视频背景
    Walking     // ，切换到 WASD 物理移动
}
public class GameDirector : Singleton<GameDirector>
{
    public GameState currentState;

    private void Start()
    {
        currentState = GameState.Intro;
        GameEvents.Instance.onMilestoneReached += (data) => currentState = GameState.Intro; 
        
    }
    private void Update()
    {
        Debug.Log("current game state:" + currentState);
    }
}
