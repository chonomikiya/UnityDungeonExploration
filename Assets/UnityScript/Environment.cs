using System;
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
    public enum MazeType{
        Path = 0,
        Wall = 1,
        Tresure = 2,
        Gateway = 3,
    }
}