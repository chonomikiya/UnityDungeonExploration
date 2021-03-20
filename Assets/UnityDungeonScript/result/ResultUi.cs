using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultUi : MonoBehaviour
{
    //Rowが多い場合はContentのHeightを加える
    [SerializeField] RectTransform Content = null;
    [SerializeField] GameObject RowTarget = null;

    [SerializeField] GameObject RowPrefab = null;
    [SerializeField] GameObject TotalPrefab = null;
    [SerializeField] GameObject AddTotalUi = null;
    [SerializeField] GameObject TotalMoneyUi = null;
    SqliteDatabase m_sqlitedatabase;
    UiAnime myuianime;
    //デバッグ用の変数、叩くと増えるので
    int cookie =1;
    //UIの調整用変数
    const int UI_SPACE = -25;
    const float UI_RECT_OFFSET = 17.3311f;
    [SerializeField] const int TOTAL_OFFSET = -10;
    GameObject UserPossession = null;
    // Start is called before the first frame update
    void Start()
    {
        
        myuianime = this.GetComponent<UiAnime>();
        m_sqlitedatabase = new SqliteDatabase("default.db");
        //ここから
        SetTotalMoney();
        if(GameObject.Find("PassToResult") != null){
            UserPossession = GameObject.Find("PassToResult");
            GetUserPossession(UserPossession.GetComponent<ObtainedItem>().GetObtainedList());
            Destroy(UserPossession);
        }else{
            GetUserPossession();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     AddUiRow();
        // }
    }
    public void SetTotalMoney(){
        int money = GetSqlMoneyTable();
        TotalMoneyUi.GetComponent<MoneyUi>().SetTotalMoneyUi(money);
    }
    public int GetSqlMoneyTable(){
        DataTable dt = m_sqlitedatabase.ExecuteQuery(string.Format("SELECT {0} FROM {1}","total","money"));
        return  (int)dt.Rows[0]["total"];
    }
    //Debug用
    // public void AddUiRow(){
    //     DataTable dt = m_sqlitedatabase.ExecuteQuery("SELECT id,item,sell FROM user_possession");
    //     foreach(DataRow dr in dt.Rows){
    //         GameObject AddRow = Instantiate(RowPrefab) as GameObject;
    //         AddRow.name = "Row_"+cookie;
    //         AddRow.transform.SetParent(RowTarget.transform,false);
    //         AddRow.GetComponent<ItemRow>().ChangePosition(new Vector3(0,UI_SPACE*cookie,0));
    //         AddRow.GetComponent<ItemRow>().SetItemText((string)dr["item"]);
    //         AddRow.GetComponent<ItemRow>().SetPriceText(dr["sell"].ToString());
    //         cookie++;
    //     }
    //     if(cookie > 8){
    //         ContentRectResize(cookie);
    //     }
    // }
    //前シーンで手に入れたものを表示
    public void GetUserPossession(){
        DataTable dt = m_sqlitedatabase.ExecuteQuery("SELECT id,item,sell FROM user_possession");
        int count = 1;
        int total = 0;
        foreach(DataRow dr in dt.Rows){
            GameObject AddRow = Instantiate(RowPrefab) as GameObject;
            AddRow.name = "Row_"+count;
            AddRow.transform.SetParent(RowTarget.transform,false);
            AddRow.GetComponent<ItemRow>().ChangePosition(new Vector3(0,UI_SPACE*count,0));
            AddRow.GetComponent<ItemRow>().SetItemText((string)dr["item"]);
            AddRow.GetComponent<ItemRow>().SetPriceText(dr["sell"].ToString());
            count++;
            total += (int)dr["sell"];
        }
        //最後にTotalを表示
        GameObject totalGameobj = Instantiate(TotalPrefab) as GameObject;
        totalGameobj.name = "total";
        totalGameobj.transform.SetParent(RowTarget.transform,false);
        totalGameobj.GetComponent<ItemRow>().ChangePosition(new Vector3(0,UI_SPACE*count+TOTAL_OFFSET,0));
        totalGameobj.GetComponent<ItemRow>().SetPriceText(total.ToString());
        //8以上でScrollViewからはみ出てしまうので
        if(count > 8){
            ContentRectResize(count);
        }
        //Totalを反映
        AddTotalUi.GetComponent<MoneyUi>().SetAddTotalUi(total);
        myuianime.UiAnimation_DOWN(AddTotalUi);
        TotalMoneyUi.GetComponent<MoneyUi>().UpdateTotalMoney(total);
        UpdateSql(total);
    }
    public void GetUserPossession(List<DataRow> _items){
        if(_items ==null){
            Debug.Log("ItemList is null");
            return;
        }
        int count = 1;
        int total = 0;
        foreach(DataRow dr in _items){
            GameObject AddRow = Instantiate(RowPrefab) as GameObject;
            AddRow.name = "Row_"+count;
            AddRow.transform.SetParent(RowTarget.transform,false);
            AddRow.GetComponent<ItemRow>().ChangePosition(new Vector3(0,UI_SPACE*count,0));
            AddRow.GetComponent<ItemRow>().SetItemText((string)dr["item"]);
            AddRow.GetComponent<ItemRow>().SetPriceText(dr["sell"].ToString());
            count++;
            total += (int)dr["sell"];
        }
        //最後にTotalを表示
        GameObject totalGameobj = Instantiate(TotalPrefab) as GameObject;
        totalGameobj.name = "total";
        totalGameobj.transform.SetParent(RowTarget.transform,false);
        totalGameobj.GetComponent<ItemRow>().ChangePosition(new Vector3(0,UI_SPACE*count+TOTAL_OFFSET,0));
        totalGameobj.GetComponent<ItemRow>().SetPriceText(total.ToString());
        //8以上でScrollViewからはみ出てしまうので
        if(count > 8){
            ContentRectResize(count);
        }
        //Totalを反映
        AddTotalUi.GetComponent<MoneyUi>().SetAddTotalUi(total);
        myuianime.UiAnimation_DOWN(AddTotalUi);
        TotalMoneyUi.GetComponent<MoneyUi>().UpdateTotalMoney(total);
        UpdateSql(total);
    }
    public void UpdateSql(int _total){
        m_sqlitedatabase
        .ExecuteQuery(string.Format("Update {0} SET {1} = {2}","money","total",(GetSqlMoneyTable()+_total).ToString()));
    }
    public void ContentRectResize(int _count){
        Content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,180f + (_count-8)*UI_RECT_OFFSET);
    }
    public void ChangeSceneBase(){
        SceneManager.LoadScene("base");
    }
}
