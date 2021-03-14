using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DungeonExploration.Maze;
using System;

    
public class MazeGenerator : MonoBehaviour
{
    [SerializeField] int Width = 11,Height = 11;

    RandomCtl myRandomCtl = new RandomCtl();
    MazeDigger myMazeDigger;
    int [,] Maze;
    [SerializeField] int init0ffset = 10;
    [SerializeField] GameObject myMapUI = null;

    [SerializeField] GameObject WallPrefab = null;
    [SerializeField] GameObject PathPrefab = null;
    [SerializeField] GameObject TresurePrefab = null;
    [SerializeField] GameObject DoorPrefab = null;
    [SerializeField] GameObject myWholeMapCamera = null;
    [SerializeField] GameObject TresureManage = null;
    [SerializeField] GameObject Player = null;
    GameObject MazeGroup = null;


    const int WALL = 1,PATH = 0,TRESURE = 2,ENTRANCE = 3,DOOR = 4;

    // Start is called before the first frame update
    void Start(){
        SeedDeliver seeddeliver = new SeedDeliver();
        myRandomCtl.InitRandom(seeddeliver.GetSeed());
        MazeGenerate();
    }
    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.E)){
        //     DeleteMaze();    
        // }
    }
    public void MazeGenerate(){
        myMazeDigger = new MazeDigger(Width,Height);
        myMazeDigger.InitMazeSeed(myRandomCtl.GetRandom());
        Maze = myMazeDigger.CreateMaze();
        instanceMaze(Maze);
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
        TresureManage.GetComponent<LookTableContents>().SetRandomAlias(myRandomCtl.GetRandom());
        TresureManage.GetComponent<LookTableContents>().InitTableContentsCount();
        myWholeMapCamera.GetComponent<wholeMapCamera>().SetWholePos(new Vector3((Width*init0ffset)/2,0,-(Height*init0ffset)/2));
        MazeGroup = new GameObject("empty");
        //自信がなかったためforeachを使わなかったので可読性が宜しくない,要改善
        for(int _z=0;_z<maze.GetLength(1);_z++){
            for(int _x=0;_x<maze.GetLength(0);_x++){
                if(maze[_z,_x] == WALL){
                    GameObject Cube = Instantiate(WallPrefab,new Vector3(_x*init0ffset,0,-_z*init0ffset),Quaternion.identity) as GameObject;
                    Cube.name = (_z + "+" + _x + "Wall"); 
                    Cube.transform.parent = MazeGroup.transform;
                    Cube.AddComponent<MazeInfo>();
                    Cube.GetComponent<MazeInfo>().SetMapPos(_x,_z);
                }
                if((maze[_z,_x] == PATH )||(maze[_z,_x] == ENTRANCE) ){
                    GameObject Path = Instantiate(PathPrefab,new Vector3(_x*init0ffset,0,-_z*init0ffset),Quaternion.identity) as GameObject;
                    Path.name = (_z + "+" + _x + "Path");
                    Path.transform.parent = MazeGroup.transform;
                    Path.AddComponent<MazeInfo>();
                    Path.GetComponent<MazeInfo>().SetMapPos(_x,_z);
                    Path.GetComponent<MazeInfo>().SetMapDir(GetMazeDirection(maze ,_z,_x));
                    Path.GetComponent<MazeInfo>().SetIntDir(GetMazeDirArray(maze,_z,_x));
                    Path.GetComponent<MazeInfo>().SetMapRoad(GetMapTypeDirection(_z,_x));
                    Path.GetComponent<MazeInfo>().SetMapUI_Alias(myMapUI);
                    Path.GetComponent<MazeInfo>().SetMazeType(CheckMazeType(_z,_x));
                    Path.GetComponent<MazeInfo>().ChangeMapSprite();
                    if(maze[_z,_x] == ENTRANCE){
                        this.Player.transform.position = Path.transform.position;
                    }
                }
                if((maze[_z,_x]) == TRESURE){
                    GameObject Tresure = Instantiate(TresurePrefab,new Vector3(_x*init0ffset,0,-_z*init0ffset),GetTresureDirection(_z,_x)) as GameObject;
                    Tresure.name = (_z + "+" + _x + "Tresure");
                    Tresure.transform.parent = MazeGroup.transform;
                    Tresure.AddComponent<TresureInfo>();
                    Tresure.GetComponent<TresureInfo>().SetMapPos(_x,_z);
                    Tresure.GetComponent<TresureInfo>().SetMapDir(GetMazeDirection(maze,_z,_x));
                    Tresure.GetComponent<TresureInfo>().SetIntDir(GetMazeDirArray(maze,_z,_x));
                    Tresure.GetComponent<TresureInfo>().SetMapRoad(GetMapTypeDirection(_z,_x));
                    Tresure.GetComponent<TresureInfo>().SetMapUI_Alias(myMapUI);
                    Tresure.GetComponent<TresureInfo>().SetMazeType(CheckMazeType(_z,_x));
                    Tresure.GetComponent<TresureInfo>().ChangeMapSprite();
                    Tresure.GetComponent<TresureInfo>().SetTresureList(TresureManage.GetComponent<LookTableContents>().GetItemTableForList());

                }
                if(maze[_z,_x]== DOOR){
                    GameObject Tresure = Instantiate(DoorPrefab,new Vector3(_x*init0ffset,0,-_z*init0ffset),GetTresureDirection(_z,_x)) as GameObject;
                    Tresure.name = (_z + "+" + _x + "Door");
                    Tresure.transform.parent = MazeGroup.transform;
                    Tresure.AddComponent<TresureInfo>();
                    Tresure.GetComponent<TresureInfo>().SetMapPos(_x,_z);
                    Tresure.GetComponent<TresureInfo>().SetMapDir(GetMazeDirection(maze,_z,_x));
                    Tresure.GetComponent<TresureInfo>().SetIntDir(GetMazeDirArray(maze,_z,_x));
                    Tresure.GetComponent<TresureInfo>().SetMapRoad(GetMapTypeDirection(_z,_x));
                    Tresure.GetComponent<TresureInfo>().SetMapUI_Alias(myMapUI);
                    Tresure.GetComponent<TresureInfo>().SetMazeType(CheckMazeType(_z,_x));
                    Tresure.GetComponent<TresureInfo>().ChangeMapSprite();
                }
                // arrayvalue += argmaze[x,y];
            }
        }
    }
    public Vector3 GetDirectionVector3(int _z,int _x){
        Vector3 _vector3 = new Vector3(0,0,0);
        int _dir = GetMazeDirection(Maze,_z,_x);
        switch(_dir){
            case 1:
                _vector3 = new Vector3(0,90f,0);
                break;
            case 2:
                _vector3 = new Vector3(0,0,0);
                break;
            case 4:
                _vector3 = new Vector3(0,270f,0);
                break;
            case 8:
                _vector3 = new Vector3(0,180f,0);
                break;
            default:
                Debug.Log("Tresure Room Entrance Direction err");
                break;
        }
        return _vector3;
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
    public Map GetMapTypeDirection(int _z,int _x){
        Map _map = Map.Block;
        //up dir
        if(Maze[(_z-1),_x] != WALL) _map = _map |Map.N;
        //right dir 
        if(Maze[_z,(_x+1)] != WALL) _map = _map|Map.E;
        //down dir
        if(Maze[(_z+1),_x] != WALL) _map = _map | Map.S;
        //left dir
        if(Maze[_z,(_x-1)] != WALL) _map = _map| Map.W;
        return _map;
    }
    public int GetMazeDirection(int [,] _maze ,int _z,int _x){
        int  mymap = 0;
        //up dir
        if(_maze[(_z-1),_x] != WALL) mymap += 8;
        //right dir 
        if(_maze[_z,(_x+1)] != WALL) mymap += 4;
        //down dir
        if(_maze[(_z+1),_x] != WALL) mymap += 2;
        //left dir
        if(_maze[_z,(_x-1)] != WALL) mymap += 1;
        
        return mymap;
    }
    //debug様に作った関数
    //用途的にはこちらの方がわかりやすいので採用
    public int [] GetMazeDirArray(int[,] _maze,int _z,int _x){
        int [] mazedir = new int [] {0,0,0,0};
        //up dir
        if(_maze[(_z-1),_x] != WALL) mazedir[0] = 1;
        //right dir 
        if(_maze[_z,(_x+1)] != WALL) mazedir[1] = 1;
        //down dir
        if(_maze[(_z+1),_x] != WALL) mazedir[2] = 1;
        //left dir
        if(_maze[_z,(_x-1)] != WALL) mazedir[3] = 1;
        return mazedir;
    }
    public MazeType CheckMazeType(int _z,int _x){
        MazeType _type = new MazeType();
        switch(Maze[_z,_x]){
            case WALL:
                _type = MazeType.Wall;
                break;
            case PATH:
                _type = MazeType.Path;
                break;
            case TRESURE:
                _type = MazeType.Tresure;
                break;
            case ENTRANCE:
                _type = MazeType.Entrance;
                break;
            case DOOR:
                _type = MazeType.Door;
                break;
            default:
                Debug.Log("MazeType Check Err");
                break;
            }
        return _type;
    }

}
