using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonExploration.Maze{

    public enum Map{
            Block = 0b_0000,
            //  8   4   2   1
            //  W   S   E   N   
            N = 0b_0001,
            NE = N|E,
            
            NES = N|E|S,
            NESW = N|E|S|W,
            NEW = N|E|W,
            NS = N|S,
            NSW = N|S|W,
            NW = N|W,
            E = 0b_0010,
            ES = E|S,
            ESW = E|S|W,
            EW = E|W,
            S = 0b_0100,
            SW = S|W,
            W = 0b_1000,
        }

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

            
            // Start is called before the first frame update
            void Start()
            {
                
            }
            private void Awake() {
                maprenderer = this.transform.GetChild(1).GetComponent<SpriteRenderer>();
            }
            
            // Update is called once per frame
            void Update()
            {
                
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
            public void SetMapSprite(Sprite _sprite){
                
                this.maprenderer.sprite = _sprite;
            }
            public void ChangeMapTexture(){
                SetMapSprite(myMapUI.GetComponent<MapUI>().GetMapSprite(maptype));
            }
            public void SetMapUI_Alias(GameObject _go){
                myMapUI = _go;
            }
        }
}