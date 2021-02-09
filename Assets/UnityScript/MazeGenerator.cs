using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DungeonExploration.Maze;
using System;

    
public class MazeGenerator : MonoBehaviour
{
    RandomCtl myRandomCtl = new RandomCtl();
    MazeDigger myMazeDigger = new MazeDigger(19,19);
    int [,] Maze;
    [SerializeField] int init0ffset = 10;

    [SerializeField] GameObject WallPrefab = null;
    [SerializeField] GameObject PathPrefab = null;
    GameObject MazeGroup = null;

    const int Wall = 1,Path = 0;

    // Start is called before the first frame update
    void Start(){}
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            myRandomCtl.InitRandom();
            myMazeDigger.InitMazeSeed(myRandomCtl.GetRandom());
            Maze = myMazeDigger.CreateMaze();
            instanceMaze(Maze);
        }
        if(Input.GetKeyDown(KeyCode.E)){
            DeleteMaze();    
        }
    }
    void DeleteMaze(){
        if( MazeGroup != null){
            Destroy(MazeGroup.gameObject);
        }else{
            Debug.Log("cantDelete");
        }
    }
    //InputField UI からstringを受け取るための関数
    public void SetInputValue(string s){
        myRandomCtl.SetSeed(s);
    }
    //intの配列からmazeを起こす
    public void instanceMaze(int [,] maze){
        MazeGroup = new GameObject("empty");
        for(int _x=0;_x<maze.GetLength(1);_x++){
            for(int _z=0;_z<maze.GetLength(0);_z++){
                if(maze[_x,_z] == 1){
                    GameObject Cube = Instantiate(WallPrefab,new Vector3(_z*init0ffset,0,-_x*init0ffset),Quaternion.identity) as GameObject;
                    Cube.name = (_z + "+" + _x + "Wall"); 
                    Cube.transform.parent = MazeGroup.transform;
                    Cube.AddComponent<MazeInfo>();
                    Cube.GetComponent<MazeInfo>().SetMapPos(_z,_x);
                }
                if(maze[_x,_z] == 0){
                    GameObject Path = Instantiate(PathPrefab,new Vector3(_z*init0ffset,0,-_x*init0ffset),Quaternion.identity) as GameObject;
                    Path.name = (_x + "+" + _z + "Path");
                    Path.transform.parent = MazeGroup.transform;
                    Path.AddComponent<MazeInfo>();
                    Path.GetComponent<MazeInfo>().SetMapPos(_z,_x);
                    Path.GetComponent<MazeInfo>().SetMapDir(GetMazeDirection(maze ,_z,_x));
                }
                // arrayvalue += argmaze[x,y];
                // Debug.Log(argmaze[x,y]);
            }
            // Debug.Log(arrayvalue);       
        }
    }
    public int GetMazeDirection(int [,] _maze ,int _z,int _x){
        int mymap = 0;
        //up dir
        if(_z != 0 && _maze[_z-1,_x] != Wall) mymap += 8;
        //right dir 
        if(_x != _maze.GetLength(0) && _maze[_z,_x+1] != Wall) mymap += 2;
        //down dir
        if(_z != _maze.GetLength(1) && _maze[_z+1,_x] != Wall) mymap += 4;
        //left dir
        if(_x != 0 && _maze[_z,_x-1] != Wall) mymap += 1;
        
        return mymap;
    }
}
