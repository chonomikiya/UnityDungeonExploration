using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonExploration.Maze{
public class MazeInfo : MonoBehaviour
    {
        [SerializeField] int xpos,zpos;
        [SerializeField] int dir;
        [SerializeField] string strDir;
        Map mapdir;

        enum Map{
            Block = 0,
            //  8   4   2   1
            //  W   S   E   N   
            N = 1,
            E = 2,
            S = 4,
            W = 8,
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void SetMapPos(int _x,int _z){
            this.xpos = _x;
            this.zpos = _z;
        }
        //NESW
        public void SetMapDir(int _dir){
            
        }
    }
}