using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonExploration.Maze;
public class MazeGenerator : MonoBehaviour
{
    MazeDigger myMazeDigger = new MazeDigger(15,15);
    int [,] Maze;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            Maze = myMazeDigger.CreateMaze();
        
        }
    }
    void DebugArray(int[,] argmaze){
        // for(int i=0;i<argmaze.GetLength(0);i++){
        //     for(int j=0;j<argmaze.GetLength(1);j++){

        //     }
        // }
    }
}
