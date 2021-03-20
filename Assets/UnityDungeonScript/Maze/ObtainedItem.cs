using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainedItem : MonoBehaviour
{
    List<DataRow> myItems = new List<DataRow>();
    // [SerializeField] GameObject tresuremanage = null;
    LookTableContents mylooktablecontents;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        // mylooktablecontents = tresuremanage.GetComponent<LookTableContents>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    // public void AddItemList(){
    //     DataTable dt = mylooktablecontents.GetSqlSelectTable("id,item,sell","user_possession");
    //     myItems.Add(dt.Rows[0]);
    //     foreach(DataRow dr in myItems){
    //         var val1 = dr["id"];
    //         var val2 = dr["item"];
    //         var val3 = dr["sell"];
    //         Debug.Log(val1);
    //         Debug.Log(val2);
    //         Debug.Log(val3);
    //     }
    // }
    public void AddItemList(List<DataRow> src){
        myItems.Add(src[0]);
        foreach(DataRow dr in myItems){
            var val1 = dr["id"];
            var val2 = dr["item"];
            var val3 = dr["sell"];
            Debug.Log(val1);
            Debug.Log(val2);
            Debug.Log(val3);
        }
    }
    public List<DataRow> GetObtainedList(){
        return this.myItems;
    }
}
