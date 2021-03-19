using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiAnime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UiAnimation_UP(GameObject target){
        // target.transform.DOMoveY(1f,1f);
    }
    public void UiAnimation_DOWN(GameObject target){
        Vector3 pos = target.transform.position;
        target.transform.DOMoveY(pos.y + 10,2f);
    }
}
