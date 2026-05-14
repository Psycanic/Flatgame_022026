using UnityEngine;
using System.Collections.Generic;

public class AudioController : MonoBehaviour
{
    [System.Serializable]
    private class NamedClip
    {
        public string clipId;
        public AudioClip clip;
    }

    public static AudioController Instance { get; private set; }

    [SerializeField] private AudioSource oneShotSource;
    [SerializeField] private List<NamedClip> clips = new();

    private readonly Dictionary<string, AudioClip> _clipMap = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (oneShotSource == null)
        {
            oneShotSource = GetComponent<AudioSource>();
        }

        if (oneShotSource == null)
        {
            oneShotSource = gameObject.AddComponent<AudioSource>();
        }

        BuildClipMap();
    }

    private void BuildClipMap()
    {
        _clipMap.Clear();
        foreach (var item in clips)
        {
            if (item == null || string.IsNullOrWhiteSpace(item.clipId) || item.clip == null)
            {
                continue;
            }

            _clipMap[item.clipId] = item.clip;
        }
    }

    public static void PlayOneShot(AudioClip clip, float volume = 1f)
    {
        if (clip == null)
        {
            return;
        }

        EnsureInstance().PlayClip(clip, volume);
    }

    public static void PlayOneShot(string clipId, float volume = 1f)
    {
        if (string.IsNullOrWhiteSpace(clipId))
        {
            return;
        }

        EnsureInstance().PlayClip(clipId, volume);
    }

    private static AudioController EnsureInstance()
    {
        if (Instance != null)
        {
            return Instance;
        }

        var found = FindObjectOfType<AudioController>();
        if (found != null)
        {
            return found;
        }

        var go = new GameObject("AudioController");
        return go.AddComponent<AudioController>();
    }

    private void PlayClip(AudioClip clip, float volume = 1f)
    {
        if (clip == null || oneShotSource == null)
        {
            return;
        }

        oneShotSource.PlayOneShot(clip, Mathf.Clamp01(volume));
    }

    private void PlayClip(string clipId, float volume = 1f)
    {
        if (_clipMap.TryGetValue(clipId, out var clip))
        {
            PlayClip(clip, volume);
            return;
        }

        Debug.LogWarning($"Audio clip id not found: {clipId}");
    }
}
