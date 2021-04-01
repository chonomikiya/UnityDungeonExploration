using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//TryParseを使ったがchar配列を使った方が後々困る事はないかも知れない、改善余地

public class InputCanvasCtl : MonoBehaviour
{
    [SerializeField] InputField inputField = null;   
    string inputtext; 
    [SerializeField] Text whatInput;
    const int TEXT_OVER_LENGTH = 7;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void ColledToComplet(){
        inputtext = inputField.text;
        int result;
        SeedDeliver seeddeliver = new SeedDeliver();

        if(CheckSeedValueBeUse(inputtext) && Int32.TryParse(inputtext , out result)){
            seeddeliver.SetSeed(result);
            whatInput.text = inputtext;
            inputField.text = "";
        }else{
            seeddeliver.SetSeed();
            whatInput.text = "入力した値は無効です";
            inputField.text = "";
        }
    }
    //入力をSeedへ格納できるかcheck
    public bool CheckSeedValueBeUse(string _text){
        bool _isparse = false;
        if(_text.Length < TEXT_OVER_LENGTH){
            _isparse = true;
        }
        return _isparse;
    }
    public void OnExitSeedInputUi(){
        Destroy(this.transform.root.gameObject);
    }
}
