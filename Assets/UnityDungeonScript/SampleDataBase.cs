using System.Data;
using System;
using UnityEngine;
using System.Collections.Generic;
/*
SCHEMA

CREATE TABLE itemtable(id INTEGER primary key,item TEXT,sell INTEGER);
CREATE TABLE money(total INTEGER);
CREATE TABLE mazetable (id INTEGER primary key,name TEXT,seed INTEGER);
CREATE TABLE sqlite_sequence(name,seq);
CREATE TABLE prefixtable(id INTEGER PRIMARY KEY,prefix TEXT,magnification REAL);
CREATE TABLE user_possession(id INTEGER PRYMARY KEY, item TEXT,sell INTEGER);

English noobな自分へ                       prefix,接頭辞      magnification,倍率
*/

public class SampleDataBase : MonoBehaviour {
    public SqliteDatabase SqliteDatabase;
    private const string itemtable = "itemtable";
    private const string m_database = "default.db";
    private void Awake() {
        this.SqliteDatabase = new SqliteDatabase("default.db");
    }
    private void Start() {
        // SelectFromExampleTable();
        // SelectFromItemTable();
        // SqliteDatabase.ExecuteQuery(GetQueryProcess(itemtable));
        GetItemtableId();   
    }
    //ランダムなprefixとitemtableのidを取得
    public void GetItemtableId(){
        string id = "id";
        string itemtable = "itemtable";
        // DataTable dt = SqliteDatabase.ExecuteQuery("SELECT id FROM itemtable");
        DataTable dt = GetSqlSelectTable(id,itemtable);
        int count = dt.Rows.Count;
        int [] array = new int[count];
        //for文で列の要素をint配列へ格納
        for (int i=0;i<dt.Rows.Count;i++){
            DataRow dr = dt.Rows[i];
            array[i] = (int)dr[id];
        }
        //配列からランダムな値を取り出す
        System.Random myrandom = new System.Random(1234);
        for (int i=0;i<array.Length;i++){
            int rndvalue = myrandom.Next(array.Length);
            Debug.Log("RandomValue = "+rndvalue);
            Debug.Log(array[rndvalue]);
        }
        // foreach(DataRow dr in dt.Rows){
        //      Debug.Log(dr["id"]);
        // }
    }
    public DataTable GetSqlSelectTable(string _column,string _itemtable){
        string _query = string.Format("SELECT {0} FROM {1}",_column,_itemtable);
        DataTable dt = SqliteDatabase.ExecuteQuery(_query);
        return dt;
    }

    //tableの列数を入手
    string GetTableCount(string _table){
        //Debug.Log("example = "+dt.Rows.Count);
        string _query = "SELECT COUNT(*) FROM "+_table;
        return _query;
    }
    //overload 
    //GetQueryProcess
    string GetQueryProcess(string _table){
        string _query = "SELECT * FROM "+_table;
        return _query;
    }
    string GetQueryProcess(string _column,string _table){
        string _query = "SELECT "+_column+"FROM "+_table;
        return _query;
    }
    
    void SelectFromExampleTable(){
        // SqliteDatabase = new SqliteDatabase("default.db");
        string query = (
        "SELECT name,dummy FROM example");
        // string query1 = "insert into example values(\"script\",3)";
        //                                             (\"+ var +\",int);
        // SqliteDatabase.ExecuteQuery(query1);
        DataTable dt = SqliteDatabase.ExecuteQuery(query);
        string name;
        int dummy;
        Debug.Log("example = "+dt.Rows.Count);
        foreach(DataRow dr in dt.Rows){
            name = (string)dr["name"];
            dummy = (int)dr["dummy"];
            Debug.Log("name: "+name.ToString());
            Debug.Log("dummy: "+dummy);
        }
    }
    
    void SelectFromItemTable(){
        // SqliteDatabase = new SqliteDatabase("default.db");
        string column = "id,item,sell";
        string query = "SELECT " + column + " FROM " + itemtable;
        DataTable dt = SqliteDatabase.ExecuteQuery(query);
        int _id;
        string _item;
        int _sell;
        Debug.Log("itemtable = "+dt.Rows.Count);
        foreach(DataRow dr in dt.Rows){
            _id = (int)dr["id"];
            _item = (string)dr["item"];
            _sell = (int)dr["sell"];
            Debug.Log("id = "+_id+" ,item = " +_item+" ,sell = " +_sell);
        }
    }
}