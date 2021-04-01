using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainedItem : MonoBehaviour
{
    List<DataRow> myItems = new List<DataRow>();
    LookTableContents mylooktablecontents;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddItemList(List<DataRow> src){
        myItems.Add(src[0]);
        foreach(DataRow dr in myItems){
            var val1 = dr["id"];
            var val2 = dr["item"];
            var val3 = dr["sell"];
        }
    }
    public List<DataRow> GetObtainedList(){
        return this.myItems;
    }
}
