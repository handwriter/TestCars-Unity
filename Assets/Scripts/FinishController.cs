using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinishController : MonoBehaviour
{
    public Action<bool> OnTrackFinished;
    public string PlayerTag;
    public string EnemyTag;
    private bool _isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (_isTriggered) return;
        if (other.gameObject.CompareTag(PlayerTag))
        {
            OnTrackFinished?.Invoke(true);
            _isTriggered = true;
        } 
        else if (other.gameObject.CompareTag(EnemyTag))
        {
            OnTrackFinished?.Invoke(false);
            _isTriggered = true;
        }
    }
}
