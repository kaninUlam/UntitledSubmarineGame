using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSFX : MonoBehaviour
{
    Movement _ismoving;

    AudioSource _footsteps;

    private void Start()
    {
        _ismoving = GetComponent<Movement>();
        _footsteps = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_ismoving.HorizontalVelocity != 0 && !_footsteps.isPlaying)
        {
            _footsteps.pitch = Random.Range(0.8f, 1.1f);
            _footsteps.Play();
        }
    }
}
