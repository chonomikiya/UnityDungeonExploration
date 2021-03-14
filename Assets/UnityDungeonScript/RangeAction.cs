using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RangeAction : MonoBehaviour
{
    [SerializeField] TextMeshPro textMeshPro;
    bool Ranged = false;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            this.textMeshPro.enabled = true;
            Ranged =true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player"){
            this.textMeshPro.enabled = false;
            Ranged = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)&&Ranged){
            SceneChange();
        }    
    }
    private void SceneChange(){
        SceneManager.LoadScene("result");
    }
}
