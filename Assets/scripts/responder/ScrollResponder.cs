using UnityEngine;

public class ScrollResponder : MonoBehaviour
{
    //private float scrollSpeedMultiplier;
    public float smoothness = 5f;
    private float _targetX;

    void Start()
    {
        _targetX = transform.position.x; // 同步位置
        //refresh targte only when things 'happens' ->in start
        GameEvents.Instance.OnMouseScroll += HandleScroll;
    }
    private void OnDestroy()
    {
        //GameEvents.Instance.OnMouseScroll -= (amount) => _targetX -= amount;
    }


    private void HandleScroll(float move_amount) { 
        
    }
    void Update()
    {
        //only smoothing
        transform.position = Vector3.Lerp(transform.position, new Vector3(_targetX,0,0), Time.deltaTime*smoothness);//需要解释一下！
    }

}
