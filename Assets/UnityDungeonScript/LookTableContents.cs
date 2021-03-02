using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System;

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
//SQLiteで色々扱う為のクラス、必要があれば別のものを用意する
public class LookTableContents : MonoBehaviour
{
    System.Random myrandom;
    SqliteDatabase sqlitedatabase;
    int [] item_id,prefix_id;
    DataTable itemtable,prefixtable;

    private void Awake() {
        sqlitedatabase = new SqliteDatabase("default.db");
        // int myitemid = GetRandomItemId();
        // int myprefixid = GetRandoomPrefixId();
        // Debug.Log(myitemid);
        // Debug.Log(myprefixid);
    }
    public void InitTableContentsCount(){
        SetItemId();
        SetPrefixId();
    }

    // public DataRow GetItemDataRow(){
    //     DataTable dt = GetSqlSelectTable("id ,item ,sell","itemtable","id = "+GetRandomItemId());
    //     DataRow dr = dt.Rows;
    //     return  dr;
    // }

    //今はItemTableのみでTresureをセットする
    //後からPrefixとmagnification
    public List<DataRow> GetItemTableForList(){
        DataTable dt = GetSqlSelectTable("id ,item ,sell","itemtable","id = "+GetRandomItemId());
        List<DataRow> mylist =dt.Rows;
        foreach(DataRow dr in mylist){
            var val1 = dr["id"];
            var val2 = dr["item"];
            var val3 = dr["sell"];
            Debug.Log(val1);
            Debug.Log(val2);
            Debug.Log(val3);
        }
        return mylist;
    }

    //itemIDの初期化
    public void SetItemId(){
        string id = "id";
        string itemtable = "itemtable";
        // DataTable dt = SqliteDatabase.ExecuteQuery("SELECT id FROM itemtable");
        DataTable dt = GetSqlSelectTable(id,itemtable);
        int count = dt.Rows.Count; 
        this.item_id = new int [count];
        for (int i=0;i<dt.Rows.Count;i++){
            DataRow dr = dt.Rows[i];
            item_id[i] = (int)dr[id];
        }
    }
    //prefixIDの初期化
    public void SetPrefixId(){
        string id = "id";
        string prefixtable = "prefixtable";
        // DataTable dt = SqliteDatabase.ExecuteQuery("SELECT id FROM itemtable");
        DataTable dt = GetSqlSelectTable(id,prefixtable);
        int count = dt.Rows.Count; 
        this.prefix_id = new int [count];
        for (int i=0;i<dt.Rows.Count;i++){
            DataRow dr = dt.Rows[i];
            prefix_id[i] = (int)dr[id];
        }
    }
    public int GetRandomItemId(){
        int _element = myrandom.Next(item_id.Length);
        return item_id[_element];
    }
    
    public int GetRandoomPrefixId(){
        int _element = myrandom.Next(prefix_id.Length);
        return prefix_id[_element];
    }
    
    // public void GetItemtableId(){
    //     string id = "id";
    //     string itemtable = "itemtable";
    //     // DataTable dt = SqliteDatabase.ExecuteQuery("SELECT id FROM itemtable");
    //     DataTable dt = GetSqlSelectTable(id,itemtable);
    //     int count = dt.Rows.Count;
    //     int [] array = new int[count];
    //     //for文で列の要素をint配列へ格納
    //     for (int i=0;i<dt.Rows.Count;i++){
    //         DataRow dr = dt.Rows[i];
    //         array[i] = (int)dr[id];
    //     }
    //     //配列からランダムな値を取り出す
    //     System.Random myrandom = new System.Random(1234);
    //     for (int i=0;i<array.Length;i++){
    //         int rndvalue = myrandom.Next(array.Length);
    //         Debug.Log("RandomValue = "+rndvalue);
    //         Debug.Log(array[rndvalue]);
    //     }
    // }

    public DataTable GetSqlSelectTable(string _column,string _table){
        string _query = string.Format("SELECT {0} FROM {1}",_column,_table);
        DataTable dt = sqlitedatabase.ExecuteQuery(_query);
        return dt;
    }
    public DataTable GetSqlSelectTable(string _column,string _table ,string _whare){
        string _query = string.Format("SELECT {0} FROM {1} WHERE {2}",_column,_table,_whare);
        DataTable dt = sqlitedatabase.ExecuteQuery(_query);
        return dt;
    }

    public void SetRandomAlias(System.Random _random){
        this.myrandom = _random;
    }
}