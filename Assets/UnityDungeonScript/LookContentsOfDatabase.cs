using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
public class LookContentsOfDatabase : MonoBehaviour
{
    System.Random myrandom;
    SqliteDatabase sqlitedatabase;

    private void Awake() {
        sqlitedatabase = new SqliteDatabase("default.db");
    }
    
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
        DataTable dt = sqlitedatabase.ExecuteQuery(_query);
        return dt;
    }
    public void SetRandomAlias(System.Random _random){
        this.myrandom = _random;
    }
}