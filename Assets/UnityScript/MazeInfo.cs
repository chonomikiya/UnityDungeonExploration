using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonExploration.Maze{
    public enum Map{
            Block = 0b_0000,
            //  8   4   2   1
            //  W   S   E   N   
            N = 0b_1000,
            E = 0b_0100,
            S = 0b_0010,
            W = 0b_0001,
        }
    public class MazeInfo : MonoBehaviour
        {
            [SerializeField] int xpos,zpos;
            [SerializeField] int dir;
            [SerializeField] string strDir;
            [SerializeField] Map mapdir = Map.E|Map.N|Map.S|Map.W;
            [SerializeField] int [] intdir = new int [] {0,0,0,0};

            
            // Start is called before the first frame update
            void Start()
            {
                
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
        }
}