using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//面倒だったためC#のParse関数を使用
//stringをchar配列に変換し、charの要素をint変換するのが主流、要改善
namespace DungeonExploration.Maze{
    public class RandomCtl 
    {
         
        System.Random myRandom;
    
        private string seed = "";
        public string GetSeed(){return this.seed;}
        public void SetSeed(string s){this.seed = s;}
        private int randomSeed;
        public int GetRndSeed(){return randomSeed;}
        public void SetRndSeed(int value){randomSeed = value;}
        public void InitRandom(int val){
            SetRndSeed(val);
            myRandom = new System.Random(val);
        }
        public int GetRandomLength(int index){
            return myRandom.Next(index);
        }
        public System.Random GetRandom(){
            return myRandom;
        }
    }
}