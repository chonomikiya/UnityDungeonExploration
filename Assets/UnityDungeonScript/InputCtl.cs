using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCtl : MonoBehaviour {

    //オブジェクトと結びつける
    [SerializeField] private InputField inputField;
    [SerializeField] GameObject outputTarget = null;
    void Start () {
    //Componentを扱えるようにする
        inputField = inputField.GetComponent<InputField> ();
    }

    public void InputText(){
        Debug.Log(inputField.text);
        outputTarget.GetComponent<MazeGenerator>().SetInputValue(inputField.text);
    }
}
