using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonExploration.Maze{

    [RequireComponent(typeof(Sprite))]
    public class MazeInfo : MonoBehaviour
        {
            [SerializeField] SpriteRenderer maprenderer = null;
            [SerializeField] int xpos,zpos;
            [SerializeField] int dir;
            [SerializeField] string strDir;
            [SerializeField] Map maptype = Map.Block;
            [SerializeField] int [] intdir = new int [] {0,0,0,0};
            [SerializeField] GameObject myMapUI = null;
            MazeType myMazeType;
            private bool onMapView = false;

            virtual protected void Awake() {
                GetComponentMapSprite();
            }
            protected void GetComponentMapSprite(){
                this.maprenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
            }
            public void SetMapPos(int _z,int _x){
                this.zpos = _z;
                this.xpos = _x;
            }
            //NESW
            public void SetMapDir(int _dir){
                this.dir = _dir;
            }
            public void SetIntDir(int[] _mazedir){
                this.intdir = _mazedir;
            }
            public Map GetMapRoad(){
                return maptype;
            }
            public void SetMapRoad(Map _map){
                this.maptype = _map;
            }
            public void SetMazeType(MazeType _type){
                this.myMazeType = _type;
            }
            public MazeType GetMazeType(){
                return this.myMazeType;
            }
            virtual public void SetMapSprite(Sprite _sprite){
                this.maprenderer.sprite = _sprite;
            }

            virtual public void ChangeMapSprite(){
                SetMapSprite(GetComponentMapUI().GetMapSprite(maptype));
            }
            public void SetMapUI_Alias(GameObject _mapui){
                myMapUI = _mapui;
            }
            public MapUI GetComponentMapUI(){
                return this.myMapUI.GetComponent<MapUI>();
            }
            public void ViewMiniMap(){
                if(!onMapView){
                    maprenderer.enabled = true;
                    onMapView = true;
                }
            }
            public bool GetBoolMapView(){
                return onMapView;
            }
        }
}