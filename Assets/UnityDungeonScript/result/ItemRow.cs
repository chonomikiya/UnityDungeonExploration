using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemRow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemTMPro = null;
    [SerializeField] TextMeshProUGUI priceTMPro = null;
    public void SetItemText(string _text){
        itemTMPro.text = _text;
    }
    public void SetPriceText(string _text){
        priceTMPro.text = _text;
    }
    public void ChangePosition(Vector3 _vector3){
        // Vector3 tmp = this.transform.position;
        this.transform.position += _vector3;
    }

}
