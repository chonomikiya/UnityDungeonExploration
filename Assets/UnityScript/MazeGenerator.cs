using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DungeonExploration.Maze;

public class MazeGenerator : MonoBehaviour
{
    MazeDigger myMazeDigger = new MazeDigger(15,15);
    RandomCtl myRandomCtl = new RandomCtl();
    int [,] Maze;
    [SerializeField] int init0ffset = 10;

    [SerializeField] GameObject WallPrefab = null;
    [SerializeField] GameObject PathPrefab = null;
    GameObject MazeGroup = null;
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
    void instanceMaze(int [,] maze){
        MazeGroup = new GameObject("empty");
        for(int z=0;z<maze.GetLength(1);z++){
            for(int x=0;x<maze.GetLength(0);x++){
                if(maze[x,z] == 1){
                    GameObject Cube = Instantiate(WallPrefab,new Vector3(x*init0ffset,0,-z*init0ffset),Quaternion.identity) as GameObject;
                    Cube.name = (x + "+" + z + "Wall"); 
                    Cube.transform.parent = MazeGroup.transform;
                }
                if(maze[x,z] == 0){
                    GameObject Path = Instantiate(PathPrefab,new Vector3(x*init0ffset,0,-z*init0ffset),Quaternion.identity) as GameObject;
                    Path.name = (x + "+" + z + "Path");
                    Path.transform.parent = MazeGroup.transform;
                }
                // arrayvalue += argmaze[x,y];
                // Debug.Log(argmaze[x,y]);
            }
            // Debug.Log(arrayvalue);
            
        }
    }
}

