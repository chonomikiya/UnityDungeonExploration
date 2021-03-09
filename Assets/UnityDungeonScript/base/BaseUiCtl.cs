using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUiCtl : MonoBehaviour
{
    [SerializeField] GameObject input_ui_prefab = null;
    [SerializeField] Transform BaseTransformUI = null;
    [SerializeField] Transform tform_ButtonGroup = null;
    GameObject seed_input_ui = null;    
    const int LAYER_INVISIBLE = 12,LAYER_UI = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //上にUIを重ねる場合、上層下層にボタンがあると被って見辛くなるのでけしたがいいやも
    
    public void OnCreateSeedInputUi(){
        seed_input_ui = Instantiate(input_ui_prefab ) as GameObject;
        seed_input_ui.GetComponentInChildren<Button>().onClick.AddListener(OnExitButtonDestory);
        InvisibleButtonUI();
    }
    public void OnExitButtonDestory(){
        Destroy(this.seed_input_ui.gameObject);
        OnviewButtonUI();
    }
    //yet
    //上にUIを重ねる場合、上層下層にボタンがあると被って見辛くなるのでけしたがいいやも
    //UIのLayerをレンダリングしないものに変える
    public void InvisibleButtonUI(){
        Image[] childImage = tform_ButtonGroup.GetComponentsInChildren<Image>();
        Text [] childText  = tform_ButtonGroup.GetComponentsInChildren<Text>();
        for (int i=0;i<childImage.Length;i++){
            Debug.Log(i);
            childImage[i].enabled = false;
        }
        for(int i=0;i<childText.Length;i++){
            childText[i].enabled = false;
        }
    }
    public void OnviewButtonUI(){
        Image[] childImage = tform_ButtonGroup.GetComponentsInChildren<Image>();
        Text [] childText  = tform_ButtonGroup.GetComponentsInChildren<Text>();
        for (int i=0;i<childImage.Length;i++){
            Debug.Log(i);
            childImage[i].enabled = true;
        }
        for(int i=0;i<childText.Length;i++){
            childText[i].enabled = true;
        }
    }

}
