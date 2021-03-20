using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RangeAction : MonoBehaviour
{
    [SerializeField] TextMeshPro textMeshPro;
    bool Ranged = false,pressed = false;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && !pressed){
            OnViewText();
            Ranged =true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player" ){
            InvisibleText();
            Ranged = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)&&Ranged&&!pressed){
            switch(this.gameObject.tag){
                case "Door":
                    SceneChange();
                    break;
                case "TresureBox":
                    this.GetComponent<TresureBox>().Animation_OPEN();
                    InvisibleText();
                    pressed = true;
                    break;
                default :
                    Debug.Log("RangeActionErr");
                    break;
            }
        }    
    }
    public void InvisibleText(){
        this.textMeshPro.enabled = false;
    }
    public void OnViewText(){
        this.textMeshPro.enabled = true;

    }
    public void ViewText(){

    }
    private void SceneChange(){
        SceneManager.LoadScene("result");
    }
}
