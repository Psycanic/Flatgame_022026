using Unity.VisualScripting;
using UnityEngine;

public class ScrollInteract : MonoBehaviour
{
    private void Update()
    {
        if (GameDirector.Instance.currentState != GameState.Intro) return; //scrolling only effective in intro state

        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (scrollDelta != 0) { 
            //gameevents broadcasts- mouse is scrolling
            GameEvents.Instance.callMouseScroll(scrollDelta);
            Debug.Log("mouse scrolling detected!");
        }
    }   
}
