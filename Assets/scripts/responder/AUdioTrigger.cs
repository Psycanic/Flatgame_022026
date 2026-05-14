using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;
    [SerializeField] private AudioClip enterFromLeftClip;
    [SerializeField, Range(0f, 1f)] private float volume = 1f;

    private bool _initialized;
    private bool _wasOutsideLeft;

    private void Reset()
    {
        targetCamera = Camera.main;
    }

    private void LateUpdate()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }

        if (targetCamera == null)
        {
            return;
        }

        Vector3 viewportPos = targetCamera.WorldToViewportPoint(transform.position);
        if (viewportPos.z < 0f)
        {
            return;
        }

        bool isOutsideLeft = viewportPos.x < 0f;
        bool isInsideScreen = viewportPos.x >= 0f && viewportPos.x <= 1f && viewportPos.y >= 0f && viewportPos.y <= 1f;

        if (!_initialized)
        {
            _wasOutsideLeft = isOutsideLeft;
            _initialized = true;
            return;
        }

        if (_wasOutsideLeft && isInsideScreen)
        {
            AudioController.PlayOneShot(enterFromLeftClip, volume);
        }

        _wasOutsideLeft = isOutsideLeft;
    }
}
