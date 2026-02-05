using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DragResponder : MonoBehaviour
{
    [SerializeField] private float dragSpeedMultiplier = 1.0f;
    [SerializeField] private float smoothness = 1.0f;

    private float targetX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetX = transform.position.x;
        GameEvents.Instance.OnMouseDrag += HandleDrag;

    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnMouseDrag -= HandleDrag;
    }
    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), Time.deltaTime * smoothness);
        //Debug.Log("目标点已更新为: " + targetX);
    }

    private void HandleDrag(float deltaX) {
        Debug.Log("we re processing ur draggin!!");
        targetX += dragSpeedMultiplier * deltaX;
    }
}
