using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//TryParseを使ったがchar配列を使った方が後々困る事はないかも知れない、改善余地

public class InputCanvasCtl : MonoBehaviour
{
    [SerializeField] InputField inputField = null;   
    [SerializeField] string inputtext; 
    const int TEXT_MAX_LENGTH = 6;
    bool isparse  = false;
    // Start is called before the first frame update
    void Start()
    {
        inputtext = inputField.text;
        int result;
        if(CheckSeedValueBeUse(inputtext) && Int32.TryParse(inputtext , out result)){
            Debug.Log(true);
        }

        // ParseStringToInt(inputtext);
    }
    //入力をSeedへ格納できるかcheck
    public bool CheckSeedValueBeUse(string _text){
        bool _isparse = false;
        if(_text.Length < TEXT_MAX_LENGTH){
            _isparse = true;
        }
        return _isparse;
    }
    //すでにStringToIntはすでにC#でできるのでコメントアウト
    // public int ParseStringToInt(string _text){
        
    //     int result;
    //     bool isParsed = Int32.TryParse(_text, out result);
    //     Debug.Log(result);
    //     if(isParsed){
    //         Debug.Log(result);
    //     }else{
    //         Debug.Log("parseErr");
    //     }
    //     // int _seed = 0;
    //     // string islink = "";
    //     // char [] char_parse = _text.ToCharArray();
    //     // foreach (char valu in char_parse){
    //     //     Debug.Log(valu);
    //     //     islink = islink + valu;
    //     // }
    //     // Debug.Log(islink);

    //     return result;
    // }
    // public bool ParseCheck(char  _target){
    //     bool isjudge = false;
    //     switch(_target){
    //         case '0':
    //             break;
    //         case '1':
    //             break;
    //         case '2':
    //             break;
    //         case '3':
    //             break;
    //         case '4':
    //             break;
    //         case '5':
    //             break;
    //         case '6':
    //             break;
    //         case '7':
    //             break;
    //         case '8':
    //             break;
    //         case '9':
    //             break;            
    //     }
    //     return isjudge;
    // }
    public int CharToInt(char _befor){
        int i = 0;
       switch (_befor){
            case '1':
                Debug.Log(_befor);
                break;
       } 
        return i;
    }
    public void OnExitSeedInputUi(){
        Destroy(this.transform.root.gameObject);
    }
}
