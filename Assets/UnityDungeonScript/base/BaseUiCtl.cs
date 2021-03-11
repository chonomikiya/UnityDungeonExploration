using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LookTableContents))]
public class BaseUiCtl : MonoBehaviour
{
    [SerializeField] GameObject input_ui_prefab = null;
    [SerializeField] Transform tform_ButtonGroup = null;
    [SerializeField] Text money_ui = null;
    GameObject seed_input_ui = null;    
    LookTableContents myLookTableContents;
    bool isSeedInput = false;
    // const int LAYER_INVISIBLE = 12,LAYER_UI = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        myLookTableContents = this.GetComponent<LookTableContents>();
        // m_sqldatabase = new SqliteDatabase("default.db");
        OnViewMoneyUI();
        // SeedDeliver seeddeliver = new SeedDeliver();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnNextSceneButton(){
        if(isSeedInput){
            SceneManager.LoadScene("playgame");
        }
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
    //上にUIを重ねる場合、上層下層にボタンがあると被って見辛くなるのでけしたがいいやも
    //UIのLayerをレンダリングしないものに変える
    //引数にGameObjectを持ってきてそれを見えなくする方が後々使いやすくなるかも
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
            Debug.Log(i);
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
    public void SetIsSeedInput(bool _judge){
        this.isSeedInput = _judge;
    }
}
