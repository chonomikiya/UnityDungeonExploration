using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInputCtl : MonoBehaviour
{
    [SerializeField] RawImage miniMap = null;
    [SerializeField] RawImage WholeMap = null;
    RawImage RawImage;
    bool onmap = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            if(onmap){
                miniMap.enabled = true;
                WholeMap.enabled = false;
            }else{
                miniMap.enabled = false;
                WholeMap.enabled = true;
            }
            //true
            onmap = !onmap;
        }
    }
    public void InstanceMap(GameObject _gameobject){
        
    }
}
