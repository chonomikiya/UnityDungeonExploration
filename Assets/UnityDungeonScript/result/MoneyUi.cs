using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MoneyUi : MonoBehaviour
{
    int speed = 10;
    float interval = 2;
    bool isUpdated = false;
    int totalmoney =0,addmoney=0,add=0,corrent = 0;

    private IEnumerator MoneyUpdateAnimation(float start,float end,float duration){
        float startTime = Time.time;
        float endTime = startTime+duration;
        do{
            float rate = (Time.time - startTime)/duration;
            float updateVal = ((end - start)* rate+start);
            SetTotalMoneyUi((int)updateVal);
            yield return null;
        }while(Time.time<endTime);
        SetTotalMoneyUi((int)end);
    }
    public void SetAddTotalUi(int _addtotal){
        TextMeshProUGUI addtotal = GetComponentInChildren<TextMeshProUGUI>();
        addtotal.text = "+ " + _addtotal.ToString();
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
        StartCoroutine(MoneyUpdateAnimation((float)corrent,(float)totalmoney,interval));
    }
}
