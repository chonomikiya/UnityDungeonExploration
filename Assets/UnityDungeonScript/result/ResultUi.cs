using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResultUi : MonoBehaviour
{
    //Rowが多い場合はContentのHeightを加える
    [SerializeField] GameObject Content = null;
    [SerializeField] GameObject RowPrefab = null;
    SqliteDatabase m_sqlitedatabase;
    const int UI_OFFSET = -25;
    // Start is called before the first frame update
    void Start()
    {
        m_sqlitedatabase = new SqliteDatabase("default.db");
        GetUserPossession();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            // GameObject AddRow = Instantiate(RowPrefab,Content.transform.position,Quaternion.identity) as GameObject;
            GameObject AddRow = Instantiate(RowPrefab) as GameObject;
            AddRow.transform.SetParent(Content.transform,false);
        }
    }
    public void GetUserPossession(){
        DataTable dt = m_sqlitedatabase.ExecuteQuery("SELECT id,item,sell FROM user_possession");
        int count = 1;
        foreach(DataRow dr in dt.Rows){
            GameObject AddRow = Instantiate(RowPrefab) as GameObject;
            AddRow.name = "Row_"+count;
            AddRow.transform.SetParent(Content.transform,false);
            AddRow.GetComponent<ItemRow>().ChangePosition(new Vector3(0,UI_OFFSET*count,0));
            AddRow.GetComponent<ItemRow>().SetItemText((string)dr["item"]);
            AddRow.GetComponent<ItemRow>().SetPriceText(dr["sell"].ToString());
            Debug.Log(dr["id"]);
            Debug.Log(dr["item"]);
            Debug.Log(dr["sell"]);
            count++;
        }
    }
    public void ChangeSceneBase(){
        SceneManager.LoadScene("base");
    }
}
