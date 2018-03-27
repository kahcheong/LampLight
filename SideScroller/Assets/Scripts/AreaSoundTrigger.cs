using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class AreaSoundTrigger : MonoBehaviour
{
    [Tooltip("Main camera audio source")]
    public AudioSource mainAudioSource;
    
    [Tooltip("Zone to trigger the audio change/effect")]
    public Collider triggerZone;

    [Tooltip("List of all audios to use in the game for switching")]
    public AudioClip[] clips;

    [Tooltip("The audio clip to be played")]
    public AudioClip toPlay;
    
    [Tooltip("Default music")]
    public AudioClip defMusic;

    [Tooltip("Whether or not this is a single use trigger")]
    public bool isSingleTrigger = false;

    [Tooltip("Whether or not this has been triggered")]
    public bool beenTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !beenTriggered)
        {
            mainAudioSource.clip = toPlay;    //Switch to the target audio
            mainAudioSource.Play();            //Play the target audio
            if (isSingleTrigger)
            {
                beenTriggered = true;
            }
        }
    }
}
