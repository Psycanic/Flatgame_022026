using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class DragInteract : MonoBehaviour
{

    private Vector2 lastMousePos;

    private void Start()
    {
        lastMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    private void Update()
    {

        if (GameDirector.Instance.currentState != GameState.Exploring) return;

        if (Input.GetMouseButtonDown(0)) { //right when pressing down
            lastMousePos = Input.mousePosition;
        }
        if(Input.GetMouseButton(0)) {
            Vector2 newMousePos = Input.mousePosition;
            float deltaX = newMousePos.x - lastMousePos.x;

            if (Mathf.Abs(deltaX) > 0f) {
                //broadcast the speedx
                GameEvents.Instance.callMouseDrag(deltaX);
            }
        }
    }
}
