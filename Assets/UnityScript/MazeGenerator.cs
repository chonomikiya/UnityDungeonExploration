using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonExploration.Maze;
using System;
public class MazeGenerator : MonoBehaviour
{
    MazeDigger myMazeDigger = new MazeDigger(15,15);
    int [,] Maze;
    [SerializeField] int init0ffset = 10;

    [SerializeField] GameObject CubePrefab = null;
    [SerializeField] GameObject PathPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            Maze = myMazeDigger.CreateMaze();
            instanceMaze(Maze);
        }
    }
    void DebugArray(int[,] argmaze){
        for(int y=0;y<argmaze.GetLength(1);y++){
            int arrayvalue = 9;
            for(int x=0;x<argmaze.GetLength(0);x++){
                arrayvalue *= 10;
                // arrayvalue += argmaze[x,y];
                // Debug.Log(argmaze[x,y]);
                Debug.Log(arrayvalue);
            }
            // Debug.Log(arrayvalue);
            
        }
    }
    void instanceMaze(int [,] maze){
        for(int z=0;z<maze.GetLength(1);z++){
            for(int x=0;x<maze.GetLength(0);x++){
                if(maze[x,z] == 1){
                    GameObject Cube = Instantiate(CubePrefab,new Vector3(x*init0ffset,0,z*init0ffset),Quaternion.identity) as GameObject;
                    Cube.name = (x + "+" + z + "Wall"); 
                }
                if(maze[x,z] == 0){
                    GameObject Path = Instantiate(PathPrefab,new Vector3(x*init0ffset,0,z*init0ffset),Quaternion.identity) as GameObject;
                    Path.name = (x + "+" + z + "Path");
                }
                // arrayvalue += argmaze[x,y];
                // Debug.Log(argmaze[x,y]);
            }
            // Debug.Log(arrayvalue);
            
        }
    }
}
/*

*/
