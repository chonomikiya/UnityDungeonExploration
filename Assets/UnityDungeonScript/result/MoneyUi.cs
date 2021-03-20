using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MoneyUi : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI result_money = null;
    [SerializeField] int speed = 120;
    bool isUpdated = false;
    int totalmoney =0,addmoney=0,add=0,corrent = 0;
    private void Update() {
        if(isUpdated){
            corrent = corrent + (int)(add * Time.deltaTime);
            if(corrent>totalmoney){
                corrent = totalmoney;
                isUpdated=false;
                SetTotalMoneyUi(corrent);
            }
        }
    }

    private void FixedUpdate() {
        if(isUpdated){
            SetTotalMoneyUi(corrent);
        }        
    }
    public void SetAddTotalUi(int _addtotal){
        TextMeshProUGUI addtotal = GetComponentInChildren<TextMeshProUGUI>();
        addtotal.text = "+ " + _addtotal.ToString();
        // result_money.text ="+ " +_text;
    }
    public void SetTotalMoneyUi(int _total){
        TextMeshProUGUI totalTMP = GetComponentInChildren<TextMeshProUGUI>();
        string _text = string.Format("{0:#,0}",_total);
        totalTMP.text = _text;
        corrent =_total;
    }
    public void UpdateTotalMoney(int _addtotal){        
        addmoney = _addtotal;
        totalmoney = corrent + addmoney;
        add = totalmoney/speed;
        isUpdated =true;
    }
}
