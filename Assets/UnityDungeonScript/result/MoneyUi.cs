using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MoneyUi : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI result_money = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAddTotalUi(string _text){
        result_money.text ="+ " +_text;
    }
}
