using UnityEngine;

public class BaseAsset : MonoBehaviour
{
    [SerializeField] protected float moveMultiplier = 1.0f; // 移动倍率

    protected virtual void Start()
    {
        // 所有的 Asset 出生后都自动听从“拖拽”指令
        GameEvents.Instance.OnMouseDrag += HandleMove;
    }

    protected virtual void HandleMove(float deltaX)
    {
        // 这是默认的行动方式：跟着拖拽平移
        transform.position += new Vector3(deltaX * 0.01f * moveMultiplier, 0, 0);
    }

    protected virtual void OnDestroy()
    {
        // 记得谢幕时把监听关了，不然会报 Null 错误
        GameEvents.Instance.OnMouseDrag -= HandleMove;
    }
}