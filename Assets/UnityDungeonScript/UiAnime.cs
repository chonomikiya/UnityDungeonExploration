using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UiAnime : MonoBehaviour
{
    float offset = 0.5f;
    float animation_speed = 3f;
    public void ObjAnimation_UP(GameObject target){
        Vector3 pos = target.transform.position;
        target.transform.DOMoveY(pos.y + offset,animation_speed);
    }
    public void TMPAnimation_Fade(TextMeshPro target){
        target.DOFade(0f,4f);
    }
    public void UiAnimation_DOWN(GameObject target){
        Vector3 pos = target.transform.position;
        target.transform.DOMoveY(pos.y + 10,1f);
        target.GetComponentInChildren<TextMeshProUGUI>().DOFade(0f,3f);
    }
}
