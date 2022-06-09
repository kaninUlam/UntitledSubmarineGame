using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSFX : MonoBehaviour
{
    // spawn this when the a machine gets broken
    // assign the audio clip here
    // you can choose from the audio folder
    AudioSource _alarm;
    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
    }
    public void AlarmOn()
    {
        _alarm.Play();
    }
}
