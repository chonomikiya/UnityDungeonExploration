using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LookTableContents))]
public class BaseUiCtl : MonoBehaviour
{
    [SerializeField] GameObject AudioManagePrefab = null;
    [SerializeField] GameObject input_ui_prefab = null;
    [SerializeField] Transform tform_ButtonGroup = null;
    [SerializeField] Text money_ui = null;
    GameObject seed_input_ui = null;    
    LookTableContents myLookTableContents;
    bool isSeedInputFlg = false;
    // const int LAYER_INVISIBLE = 12,LAYER_UI = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindWithTag("AudioObj") == null){
            GameObject AudioManager = Instantiate(AudioManagePrefab) as GameObject;
            DontDestroyOnLoad(AudioManager);
        }
        myLookTableContents = this.GetComponent<LookTableContents>();
        OnViewMoneyUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnNextSceneButton(){
        Destroy(GameObject.FindWithTag("AudioObj"));
        if(isSeedInputFlg){
            SceneManager.LoadScene("playgame");
        }else{
            new SeedDeliver().SetSeed();
            SceneManager.LoadScene("playgame");
        }
    }
    public void InputDone(){
        this.isSeedInputFlg = true;
    }
    //上にUIを重ねる場合、上層下層にボタンがあると被って見辛くなるのでけしたがいいやも
    public void OnCreateSeedInputUi(){
        seed_input_ui = Instantiate(input_ui_prefab ) as GameObject;
        seed_input_ui.GetComponentInChildren<Button>().onClick.AddListener(OnExitButtonDestory);
        seed_input_ui.GetComponentInChildren<Button>().onClick.AddListener(InputDone);
        InvisibleButtonUI();
    }
    public void OnExitButtonDestory(){
        Destroy(this.seed_input_ui.gameObject);
        OnviewButtonUI();
    }
    //上にUIを重ねる場合、上層下層にボタンがあると被って見辛くなるのでけしたがいいやも
    //UIのLayerをレンダリングしないものに変える
    //引数にGameObjectを持ってきてそれを見えなくする方が後々使いやすくなるかも
    //上が上手く行かなかったので直接enabledを弄る方法を採用
    public void InvisibleButtonUI(){
        Image[] childImage = tform_ButtonGroup.GetComponentsInChildren<Image>();
        Text [] childText  = tform_ButtonGroup.GetComponentsInChildren<Text>();
        for (int i=0;i<childImage.Length;i++){
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
            childImage[i].enabled = true;
        }
        for(int i=0;i<childText.Length;i++){
            childText[i].enabled = true;
        }
    }
    public void OnViewMoneyUI(){
        DataTable dt = myLookTableContents.GetSqlSelectTable("total","money");
        int money =  (int)dt.Rows[0]["total"];
        SetMoneyToText(money);
        // m_sqldatabase.ExecuteQuery("SELECT total FROM money");
    }
    public void SetMoneyToText(int _money){
        string str_money =string.Format("{0:#,0}",_money);
        money_ui.text =str_money;
    }
    public void ChangeScene_title(){
        SceneManager.LoadScene("title");
    }
}
