using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManage : MonoBehaviour
{
    [SerializeField] GameObject BGMObject = null;
    [SerializeField] AudioSource boxOpen_Se;
    [SerializeField] AudioClip [] footclips;
    AudioSource [] gamebgm;
    
    int playing;

    // Start is called before the first frame update
    void Start()
    {
        gamebgm = BGMObject.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBgm(int _index){
        playing = _index;
        gamebgm[_index].Play();
    }
    public void BoxOpen_Play(){
        this.boxOpen_Se.PlayOneShot(boxOpen_Se.clip);
    }
    public int GetBgmLength(){
        return gamebgm.Length;
    }
}
