using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonExploration.Maze;
using TMPro;

public class TresureBox : MonoBehaviour
{
    Animator tresure_animetor;
    [SerializeField] GameObject PopupPosition = null;
    [SerializeField] TextMeshPro popup_name = null;
    UiAnime myuianime;
    string itemname = "test";
    // Start is called before the first frame update
    void Start()
    {
        tresure_animetor = this.GetComponent<Animator>();
        myuianime = GetComponent<UiAnime>();
    }
    public void Animation_OPEN(){
        SetItemName();
        tresure_animetor.Play("open");
        this.transform.parent.GetComponent<TresureInfo>().OpenSound_Play();
    }

    public void SetItemName(){
        itemname = this.transform.parent.GetComponent<TresureInfo>().GetTresureItem();
        this.transform.parent.GetComponent<TresureInfo>().PassToItemList();
    }
    public void PopupGetUi(){
        popup_name.text = itemname + " を手に入れた";
        myuianime.ObjAnimation_UP(popup_name.gameObject);
        myuianime.TMPAnimation_Fade(popup_name);
    }
}
