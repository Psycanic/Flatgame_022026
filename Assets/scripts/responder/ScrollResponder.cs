using UnityEngine;

public class ScrollResponder : MonoBehaviour
{
    //private float scrollSpeedMultiplier;
    [SerializeField]private float smoothness = 5f;
    [SerializeField] private float speedMultiplier =5f;
    private float targetY;

    void Start()
    {

        Debug.Log("mousescroll event received in responder");
        targetY = transform.position.y; // Í¬²½Î»ÖÃ
        //refresh targte only when things 'happens' ->in start
        GameEvents.Instance.OnMouseScroll += HandleScroll;
    }
    private void OnDestroy()
    {
        GameEvents.Instance.OnMouseScroll -= HandleScroll;
        
    }

    
    private void HandleScroll(float move_amount) {
        Debug.Log("handling scroll!!");
        targetY += move_amount * speedMultiplier;

        
    }
    void Update()
    {
        //only smoothing
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,targetY,transform.position.z), Time.deltaTime*smoothness);
    }

}
