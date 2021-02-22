using UnityEngine;
using System.Collections.Generic;

public class SampleDataBase : MonoBehaviour {
    public SqliteDatabase SqliteDatabase;
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
        }    
}