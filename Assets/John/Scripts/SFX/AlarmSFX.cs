using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSFX : MonoBehaviour
{
    AudioSource _alarm;
    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
    }

}
