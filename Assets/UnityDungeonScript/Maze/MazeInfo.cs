using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonExploration.Maze{

    [RequireComponent(typeof(Sprite))]
    public class MazeInfo : MonoBehaviour
        {
            [SerializeField] Sprite minimap =null;
            [SerializeField] SpriteRenderer maprenderer = null;
            [SerializeField] int xpos,zpos;
            [SerializeField] int dir;
            [SerializeField] string strDir;
            [SerializeField] Map maptype = Map.Block;
            [SerializeField] int [] intdir = new int [] {0,0,0,0};
            [SerializeField] GameObject myMapUI = null;
            private bool onMapView = false;

            
            // Start is called before the first frame update
            void Start()
            {
                
            }
            virtual protected void Awake() {
                GetComponentMapSprite();
            }
            
            // Update is called once per frame
            void Update()
            {
                
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
            public Map GetMapType(){
                return maptype;
            }
            public void SetMapType(Map _map){
                this.maptype = _map;
            }
            virtual public void SetMapSprite(Sprite _sprite){
                this.maprenderer.sprite = _sprite;
            }
            // virtual public void SetMapSprite(){
            //     this.maprenderer.sprite = this.myMapUI.GetComponent<MapUI>().GetMapSprite(GetMapType());
            // }
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