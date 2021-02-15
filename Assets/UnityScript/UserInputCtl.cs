using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputCtl : MonoBehaviour
{
    [SerializeField] GameObject MapUIPrefab = null;
    bool onmap = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && !onmap ){
            InstanceMap(MapUIPrefab);
            onmap = true;
        }
    }
    public void InstanceMap(GameObject _gameobject){
        GameObject MapUICanvas = Instantiate(_gameobject) as GameObject;
    }
}
