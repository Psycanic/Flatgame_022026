using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AudioZoneTrigger : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float zoneVolume = 1f;
    [SerializeField] private bool preventRetriggerWhileInside = true;

    private readonly HashSet<int> _insideColliderIds = new();

    private void Reset()
    {
        var col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int colliderId = other.GetInstanceID();
        if (preventRetriggerWhileInside && _insideColliderIds.Contains(colliderId))
        {
            return;
        }

        ItemAudio itemAudio = other.GetComponentInParent<ItemAudio>();
        if (itemAudio == null)
        {
            return;
        }

        bool played = itemAudio.TryPlay(zoneVolume);
        if (played && preventRetriggerWhileInside)
        {
            _insideColliderIds.Add(colliderId);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!preventRetriggerWhileInside)
        {
            return;
        }

        _insideColliderIds.Remove(other.GetInstanceID());
    }
}
