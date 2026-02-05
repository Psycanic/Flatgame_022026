using UnityEngine;

public class DragResponder : MonoBehaviour
{
    [SerializeField] private float dragSpeedMultiplier = 1.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameEvents.Instance.OnMouseDrag += HandleDrag;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleDrag(float deltaX) { 
        float moveAmount = dragSpeedMultiplier * deltaX;
        transform.position += new Vector3(moveAmount, 0, 0);
    }
}
