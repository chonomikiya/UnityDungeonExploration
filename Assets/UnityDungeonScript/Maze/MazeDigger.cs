using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;

//https://algoful.com/Archive/Algorithm/MazeDig
//Algoful様のサイトよりC#の迷路生成アルゴリズム

namespace DungeonExploration.Maze{
    public class MazeDigger
    {
            // 2次元配列の迷路情報
            [SerializeField]private int initvalue = 15;
            private int[,] Maze;
            private int Width { get; set; }
            private int Height { get; set; }
            private bool door_install = false;
            private System.Random myrnd;

            // 穴掘り開始候補座標
            private List<Cell> StartCells;

            // コンストラクタ
            public MazeDigger(int width, int height)
            {
                // 5未満のサイズや偶数では生成できない
                if (width < 5 || height < 5) throw new ArgumentOutOfRangeException();
                if (width % 2 == 0) width++;
                if (height % 2 == 0) height++;

                // 迷路情報を初期化
                this.Width = width;
                this.Height = height;
                Maze = new int[width, height];
                StartCells = new List<Cell>();
            }
            // 生成処理
            public int[,] CreateMaze()
            {
                // 全てを壁で埋める
                // 穴掘り開始候補(x,yともに偶数)座標を保持しておく
                for (int y = 0; y < this.Height; y++)
                {
                    for (int x = 0; x < this.Width; x++)
                    {
                        if (x == 0 || y == 0 || x == this.Width - 1 || y == this.Height - 1)
                        {
                            Maze[x, y] = PATH;  // 外壁は判定の為通路にしておく(最後に戻す)
                        }
                        else
                        {
                            Maze[x, y] = WALL;
                        }
                    }
                }
                Cell mazestart = new Cell();
                mazestart.X = (myrnd.Next(Width/2)*2)+1;
                mazestart.Y = (myrnd.Next(Height/2)*2)+1;                
                // 穴掘り開始
                this.Dig(mazestart.X, mazestart.Y);

                // 外壁を戻す
                for (int y = 0; y < this.Height; y++)
                {
                    for (int x = 0; x < this.Width; x++)
                    {
                        if (x == 0 || y == 0 || x == this.Width - 1 || y == this.Height - 1)
                        {
                            Maze[x, y] = WALL;
                        }
                        if(x == mazestart.X && y == mazestart.Y){
                            Maze[x,y] = START;
                        }
                    }
                }
                return Maze;
            }

            // 座標(x, y)に穴を掘る
            private void Dig(int x, int y)
            {
                // 指定座標から掘れなくなるまで堀り続ける
                int count = 0;
                var rnd = this.myrnd;
                while (true)
                {
                    count++;

                    // 掘り進めることができる方向のリストを作成
                    var directions = new List<Direction>();
                    if (this.Maze[x, y - 1] == WALL && this.Maze[x, y - 2] == WALL)
                        directions.Add(Direction.Up);
                    if (this.Maze[x + 1, y] == WALL && this.Maze[x + 2, y] == WALL)
                        directions.Add(Direction.Right);
                    if (this.Maze[x, y + 1] == WALL && this.Maze[x, y + 2] == WALL)
                        directions.Add(Direction.Down);
                    if (this.Maze[x - 1, y] == WALL && this.Maze[x - 2, y] == WALL)
                        directions.Add(Direction.Left);
                    
                    // 掘り進められない場合、ループを抜ける
                    if (directions.Count == 0) break;

                    //カウンタがしきい値を超えた時、周りに繋げられる壁があったら繋げる
                    if (count>threshold && ConnectPath(x,y)){
                        count = 0;
                    }
                    // 指定座標を通路とし穴掘り候補座標から削除
                    SetPath(x, y);
                    // 掘り進められる場合はランダムに方向を決めて掘り進める
                    var dirIndex = rnd.Next(directions.Count);
                    // 決まった方向に先2マス分を通路とする
                    switch (directions[dirIndex]){
                        case Direction.Up:
                            SetPath(x, --y);
                            SetPath(x, --y);
                            break;
                        case Direction.Right:
                            SetPath(++x, y);
                            SetPath(++x, y);
                            break;
                        case Direction.Down:
                            SetPath(x, ++y);
                            SetPath(x, ++y);
                            break;
                        case Direction.Left:
                            SetPath(--x, y);
                            SetPath(--x, y);
                            break;
                    }
                    GetDeadEndPath(x,y);
                }

                // どこにも掘り進められない場合、穴掘り開始候補座標から掘りなおし
                // 候補座標が存在しないとき、穴掘り完了
                
                var cell = GetStartCell();
                if (cell != null)
                {
                    Dig(cell.X, cell.Y);
                }
            }
            //周りの壁を調べて、問題が無ければ2つ先にある通路と繋げる
            //繋いだらtrue、繋がらない時はfalse
            bool ConnectPath(int _x,int _y){
                bool connected = false;
                List<Direction> mydirection = new List<Direction>();
                if (this.Maze[_x, _y - 1] == WALL && this.Maze[_x, _y - 2] == PATH){
                        mydirection.Add(Direction.Up);
                    }
                if (this.Maze[_x + 1, _y] == WALL && this.Maze[_x + 2, _y] == PATH){
                        mydirection.Add(Direction.Right);
                    }
                if (this.Maze[_x, _y + 1] == WALL && this.Maze[_x, _y + 2] == PATH){
                        mydirection.Add(Direction.Down);}

                if (this.Maze[_x - 1, _y] == WALL && this.Maze[_x - 2, _y] == PATH){
                        mydirection.Add(Direction.Left);
                    }
                if(mydirection.Count != 0){
                    int dirindex = myrnd.Next(mydirection.Count);
                    connected = true;
                    switch(mydirection[dirindex]){
                        case Direction.Up:
                            SetPath(_x, (_y-1));
                            break;
                        case Direction.Right:
                            SetPath((_x+1), _y);
                            break;
                        case Direction.Down:
                            SetPath(_x, (_y+1));
                            break;
                        case Direction.Left:
                            SetPath((_x-1), _y);
                            break;
                    }
                }
                return connected;
            }
            //行き止まりを確認、何処にも進むなかったらその箇所をTresure、Doorにする
            void GetDeadEndPath(int x,int y){
                var directions = new List<Direction>();
                if (this.Maze[x, y - 1] == WALL && this.Maze[x, y - 2] == WALL)
                    directions.Add(Direction.Up);
                if (this.Maze[x + 1, y] == WALL && this.Maze[x + 2, y] == WALL)
                    directions.Add(Direction.Right);
                if (this.Maze[x, y + 1] == WALL && this.Maze[x, y + 2] == WALL)
                    directions.Add(Direction.Down);
                if (this.Maze[x - 1, y] == WALL && this.Maze[x - 2, y] == WALL)
                    directions.Add(Direction.Left);
                
                if (directions.Count == 0){
                    if(!door_install){    
                        Maze[x,y] = DOOR;
                        door_install =true;
                    }else{
                        Maze[x,y] = TRESURE;
                    }
                }
            }

            // 座標を通路とする(穴掘り開始座標候補の場合は保持)
            private void SetPath(int x, int y)
            {
                this.Maze[x, y] = PATH;
                if (x % 2 == 1 && y % 2 == 1)
                {
                    // 穴掘り候補座標
                    StartCells.Add(new Cell() { X = x, Y = y });
                }
            }
            private void  SetTresure(int x,int y){
                this.Maze[x, y] = TRESURE;
            }

            // 穴掘り開始位置をランダムに取得する
            private Cell GetStartCell()
            {
                if (StartCells.Count == 0) return null;

                // ランダムに開始座標を取得する
                //default var rnd = new Random();
                var rnd = myrnd;
                var index = rnd.Next(StartCells.Count);
                var cell = StartCells[index];
                StartCells.RemoveAt(index);

                return cell;
            }

            // // デバッグ用処理
            // public static void DebugPrint(int[,] maze)
            // {
            //     Console.WriteLine($"Width: {maze.GetLength(0)}");
            //     Console.WriteLine($"Height: {maze.GetLength(1)}");
            //     for (int y = 0; y < maze.GetLength(1); y++)
            //     {
            //         for (int x = 0; x < maze.GetLength(0); x++)
            //         {
            //             Console.Write(maze[x, y] == Wall ? "■ " : "　");
            //         }
            //         Console.WriteLine();
            //     }
            // }

            // 通路・壁情報
            const int threshold = 13;
            const int PATH = 0;
            const int WALL = 1;
            const int TRESURE = 2;
            const int START = 3;
            const int DOOR= 4;

            // セル情報
            private class Cell
            {
                public int X { get; set; }
                public int Y { get; set; }
            }
            public void InitMazeSeed(System.Random argRandom){
                myrnd = argRandom;
            } 
            // 方向
            private enum Direction
            {
                Up = 0,
                Right = 1,
                Down = 2,
                Left = 3
            }
    }
}