using UnityEngine;

public class ItemAudio : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField, Range(0f, 1f)] private float volume = 1f;
    [SerializeField] private float cooldownSeconds = 0.05f;

    private float _lastPlayTime = -999f;

    public bool TryPlay(float zoneVolumeMultiplier = 1f)
    {
        if (clip == null)
        {
            return false;
        }

        if (Time.time - _lastPlayTime < cooldownSeconds)
        {
            return false;
        }

        _lastPlayTime = Time.time;
        float finalVolume = Mathf.Clamp01(volume * zoneVolumeMultiplier);
        AudioController.PlayOneShot(clip, finalVolume);
        return true;
    }
}
