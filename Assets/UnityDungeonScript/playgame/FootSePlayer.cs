using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSePlayer : MonoBehaviour
{
    [SerializeField] AudioClip [] footClips;
    [SerializeField] float pitchRange = 0.1f;
    [SerializeField] AudioSource source;


    public void PlayFootSe(){
        source.pitch = 1.0f + Random.Range(-pitchRange,pitchRange);
        source.PlayOneShot(footClips[Random.Range(0,footClips.Length)]);
    }
}
