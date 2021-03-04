using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCanvasCtl : MonoBehaviour
{
    [SerializeField] InputField inputField = null;   
    [SerializeField] string inputtext; 
    const int TEXT_MAX_LENGTH = 6;
    bool isparse  = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //InputFieldの入力をstringへ格納
    public void OnInputSeedValue(){
        inputtext = inputField.text;
        Debug.Log(CheckSeedValueBeUse(inputtext));
        ParseStringToInt(inputtext);
    }
    //入力をSeedへ格納できるかcheck
    public bool CheckSeedValueBeUse(string _text){
        bool _isparse = false;
        if(_text.Length < TEXT_MAX_LENGTH){
            _isparse = true;
        }

        return _isparse;
    }
    public int ParseStringToInt(string _text){
        int _seed = 0;
        string islink = "";
        char [] char_parse = _text.ToCharArray();
        foreach (char val in char_parse){
            Debug.Log(val);
            islink = islink + val;
        }
        Debug.Log(islink);
        return _seed;
    }
    public void OnExitSeedInputUi(){
        Destroy(this.transform.root.gameObject);
    }
}
