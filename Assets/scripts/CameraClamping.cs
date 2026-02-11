using UnityEngine;

public class CameraClamping : MonoBehaviour
{
    [SerializeField]private GameObject ltSprite;
    [SerializeField]private GameObject rtSprite;
    private float ltSpriteHalfWidth;
    private float rtSpriteHalfWidth;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        // 算出 Sprite 宽度的一半（世界坐标单位）
        ltSpriteHalfWidth = ltSprite.GetComponent<SpriteRenderer>().bounds.extents.x;
        rtSpriteHalfWidth = rtSprite.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void LateUpdate()
    {
        // 1. 统一获取相机边界（世界坐标）
        float camLeft = mainCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float camRight = mainCam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        // 2. 限制左边 Sprite：它的【左边】不能超过【相机左边】
        if (ltSprite)
        {
            Vector3 pos = ltSprite.transform.position;
            // 逻辑：中心点坐标最低不能低于 (相机左边界 + 自己宽度的一半)
            pos.x = Mathf.Max(pos.x, camLeft + ltSpriteHalfWidth);
            ltSprite.transform.position = pos;
        }

        // 3. 限制右边 Sprite：它的【右边】不能超过【相机右边】
        if (rtSprite)
        {
            Vector3 pos = rtSprite.transform.position;
            // 逻辑：中心点坐标最高不能高于 (相机右边界 - 自己宽度的一半)
            pos.x = Mathf.Min(pos.x, camRight - rtSpriteHalfWidth);
            rtSprite.transform.position = pos;
        }
    }
}
