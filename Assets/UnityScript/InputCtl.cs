using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCtl : MonoBehaviour {

    //オブジェクトと結びつける
    private InputField inputField;
    void Start () {
    //Componentを扱えるようにする
        inputField = inputField.GetComponent<InputField> ();
    }

    public void InputText(){
        Debug.Log(inputField.text);
    }
}
