using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresureBox : MonoBehaviour
{
    Animator tresure_animetor;
    // Start is called before the first frame update
    void Start()
    {
        tresure_animetor = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Animation_OPEN(){
        tresure_animetor.Play("open");
    }
}
