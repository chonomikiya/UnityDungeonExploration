using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class titleCtl : MonoBehaviour
{
    [SerializeField] GameObject OperationUiPrefab = null;
    [SerializeField] GameObject OperationUi2Prefab = null;
    [SerializeField] GameObject ButtonGroup = null;
    [SerializeField] GameObject AudioManagePrefab = null;
    GameObject explanation;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindWithTag("AudioObj")==null){
            GameObject AudioManager = Instantiate(AudioManagePrefab) as GameObject;
            DontDestroyOnLoad(AudioManager);
        }
    }

    public void SceneChange_Base(){
        SceneManager.LoadScene("base");
    }
    public void ToEndGame(){
        Application.Quit();
    }
    public void ToOperationManual(){
        InvisibleUI(ButtonGroup);
        explanation = Instantiate(OperationUiPrefab) as GameObject;
        explanation.GetComponentInChildren<Button>().onClick.AddListener(ToNextPageManual);
    }
    public void ToNextPageManual(){
        Destroy(explanation);
        explanation = Instantiate(OperationUi2Prefab) as GameObject;
        explanation.GetComponentInChildren<Button>().onClick.AddListener(DestroyManualUi);
    }
    public void DestroyManualUi(){
        Destroy(explanation);
        DisplayUi(ButtonGroup);
    }
    public void InvisibleUI(GameObject target){
        Image [] childimage = target.GetComponentsInChildren<Image>();
        TextMeshProUGUI [] childTMPUGUI = target.GetComponentsInChildren<TextMeshProUGUI>();
        for(int i=0;i<childimage.Length;i++){
            childimage[i].enabled = false;
        }
        for(int i=0;i<childTMPUGUI.Length;i++){
            childTMPUGUI[i].enabled = false;
        }
    }
    public void DisplayUi(GameObject target){
        Image [] childimage = target.GetComponentsInChildren<Image>();
        TextMeshProUGUI [] childTMPUGUI = target.GetComponentsInChildren<TextMeshProUGUI>();
        for(int i=0;i<childimage.Length;i++){
            childimage[i].enabled = true;
        }
        for(int i=0;i<childTMPUGUI.Length;i++){
            childTMPUGUI[i].enabled = true;
        }
    }
}
