using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{
    [SerializeField] GameObject roomPrefab=null;
    const int LEFT=1,DOWN=2,RIGHT=4,UP=8;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            VectorControl(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            VectorControl(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            VectorControl(4);
        }
        if(Input.GetKeyDown(KeyCode.Alpha8)){
            VectorControl(8);
        }
    }
    void VectorControl(int value){
        GameObject room;
        if(value==DOWN||value==UP||value==RIGHT||value==LEFT){
            switch(value){
                case (DOWN):
                    room = Instantiate(roomPrefab,new Vector3(10,0,10),Quaternion.Euler(0,180,0)) as GameObject;
                    break;
                case (UP):
                    room = Instantiate(roomPrefab,new Vector3(10,0,10),Quaternion.Euler(0,0,0)) as GameObject;
                    break;
                case (RIGHT):
                    room = Instantiate(roomPrefab,new Vector3(10,0,10),Quaternion.Euler(0,90,0)) as GameObject;
                    break;
                case (LEFT):
                    room = Instantiate(roomPrefab,new Vector3(10,0,10),Quaternion.Euler(0,270,0)) as GameObject;
                    break;
                default:
                    break;
            }
        }
    }
}
