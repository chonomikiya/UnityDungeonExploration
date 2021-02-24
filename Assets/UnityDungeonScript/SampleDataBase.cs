using UnityEngine;
using System.Collections.Generic;

public class SampleDataBase : MonoBehaviour {
    public SqliteDatabase SqliteDatabase;
    private const string itemtable = "itemtable";
    private void Start() {
        SqliteDatabase = new SqliteDatabase("default.db");
        string query = "SELECT name,dummy FROM example";
        // string query1 = "insert into example values(\"script\",3)";
        //                                             (\"+ var +\",int);
        // SqliteDatabase.ExecuteQuery(query1);
        DataTable dt = SqliteDatabase.ExecuteQuery(query);
        string name;
        int dummy;
        foreach(DataRow dr in dt.Rows){
            name = (string)dr["name"];
            dummy = (int)dr["dummy"];
            Debug.Log("name: "+name.ToString());
            Debug.Log("dummy: "+dummy);
            }
        SelectFromItemTable();
        }

    
    void SelectFromItemTable(){
        SqliteDatabase = new SqliteDatabase("default.db");
        string column = "id,item,sell";
        string query = "SELECT " + column + " FROM " + itemtable;
        DataTable dt = SqliteDatabase.ExecuteQuery(query);
        int _id;
        string _item;
        int _sell;
        foreach(DataRow dr in dt.Rows){
            _id = (int)dr["id"];
            _item = (string)dr["item"];
            _sell = (int)dr["sell"];
            Debug.Log("id = "+_id+" ,item = " +_item+" ,sell = " +_sell);
        }
    }
}