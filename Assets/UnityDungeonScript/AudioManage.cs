using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    [SerializeField] AudioSource title_base_BGM;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
