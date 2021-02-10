using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DungeonExploration.Maze;
using System;

    
public class MazeGenerator : MonoBehaviour
{
    [SerializeField] int Width = 19,Height = 19;

    RandomCtl myRandomCtl = new RandomCtl();
    MazeDigger myMazeDigger;
    int [,] Maze;
    [SerializeField] int init0ffset = 10;

    [SerializeField] GameObject WallPrefab = null;
    [SerializeField] GameObject PathPrefab = null;
    [SerializeField] GameObject TresurePrefab = null;
    GameObject MazeGroup = null;

    const int Wall = 1,Path = 0;

    // Start is called before the first frame update
    void Start(){}
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            
            myRandomCtl.InitRandom();
            myMazeDigger = new MazeDigger(Width,Height);
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
        for(int _z=0;_z<maze.GetLength(1);_z++){
            for(int _x=0;_x<maze.GetLength(0);_x++){
                if(maze[_z,_x] == 1){
                    GameObject Cube = Instantiate(WallPrefab,new Vector3(_x*init0ffset,0,-_z*init0ffset),Quaternion.identity) as GameObject;
                    Cube.name = (_z + "+" + _x + "Wall"); 
                    Cube.transform.parent = MazeGroup.transform;
                    Cube.AddComponent<MazeInfo>();
                    Cube.GetComponent<MazeInfo>().SetMapPos(_x,_z);
                }
                if(maze[_z,_x] == 0){
                    GameObject Path = Instantiate(PathPrefab,new Vector3(_x*init0ffset,0,-_z*init0ffset),Quaternion.identity) as GameObject;
                    Path.name = (_z + "+" + _x + "Path");
                    Path.transform.parent = MazeGroup.transform;
                    Path.AddComponent<MazeInfo>();
                    Path.GetComponent<MazeInfo>().SetMapPos(_x,_z);
                    Path.GetComponent<MazeInfo>().SetMapDir(GetMazeDirection(maze ,_z,_x));
                    Path.GetComponent<MazeInfo>().SetIntDir(GetMazeDirArray(maze,_z,_x));
                }
                if((maze[_z,_x]) == 2){
                    GameObject Tresure = Instantiate(TresurePrefab,new Vector3(_x*init0ffset,0,-_z*init0ffset),GetTresureDirection(_z,_x)) as GameObject;
                    Tresure.name = (_z + "+" + _x + "Tresure");
                    Tresure.transform.parent = MazeGroup.transform;
                    Tresure.AddComponent<MazeInfo>();
                    Tresure.GetComponent<MazeInfo>().SetMapPos(_x,_z);
                    Tresure.GetComponent<MazeInfo>().SetMapDir(GetMazeDirection(maze,_z,_x));
                    Tresure.GetComponent<MazeInfo>().SetIntDir(GetMazeDirArray(maze,_z,_x));
                }
                // arrayvalue += argmaze[x,y];
                // Debug.Log(argmaze[x,y]);
            }
            // Debug.Log(arrayvalue);       
        }
    }
    public Quaternion GetTresureDirection(int _z,int _x){
        Quaternion _entrance = new Quaternion();
        int _dir = GetMazeDirection(Maze,_z,_x);
        switch(_dir){
            case 1:
                _entrance = Quaternion.Euler(0,90f,0);
                break;
            case 2:
                _entrance = Quaternion.Euler(0,0,0);
                break;
            case 4:
                _entrance = Quaternion.Euler(0,270f,0);
                break;
            case 8:
                _entrance = Quaternion.Euler(0,180f,0);
                break;
            default:
                Debug.Log("Tresure Room Entrance Direction err");
                break;
        }
        return _entrance;
    }
    public int GetMazeDirection(int [,] _maze ,int _z,int _x){
        int  mymap = 0;
        //up dir
        if(_maze[(_z-1),_x] != Wall) mymap += 8;
        //right dir 
        if(_maze[_z,(_x+1)] != Wall) mymap += 4;
        //down dir
        if(_maze[(_z+1),_x] != Wall) mymap += 2;
        //left dir
        if(_maze[_z,(_x-1)] != Wall) mymap += 1;
        
        return mymap;
    }
    //debug様に作った関数
    //用途的にはこちらの方がわかりやすいので採用
    public int [] GetMazeDirArray(int[,] _maze,int _z,int _x){
        int [] mazedir = new int [] {0,0,0,0};
        //up dir
        if(_maze[(_z-1),_x] != Wall) mazedir[0] = 1;
        //right dir 
        if(_maze[_z,(_x+1)] != Wall) mazedir[1] = 1;
        //down dir
        if(_maze[(_z+1),_x] != Wall) mazedir[2] = 1;
        //left dir
        if(_maze[_z,(_x-1)] != Wall) mazedir[3] = 1;
        return mazedir;
    }
}
