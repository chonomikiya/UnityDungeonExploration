using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUiCtl : MonoBehaviour
{
    [SerializeField] GameObject input_ui_prefab = null;
    [SerializeField] Transform SeedInputButton = null;
    GameObject seed_input_ui = null;    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCreateSeedInputUi(){
        seed_input_ui = Instantiate(input_ui_prefab ) as GameObject;
    }
    public void OnExitButtonDestory(){
        Destroy(this.seed_input_ui.gameObject);
    }
}
