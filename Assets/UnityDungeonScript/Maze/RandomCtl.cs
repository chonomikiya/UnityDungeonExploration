using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

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
         

        //seedが数字のみなら引数にしてRndomを初期化
        //そうでない場合はランダムに初期化
        public void InitRandom(){
            
            int result;
            
            bool isParsed = Int32.TryParse(seed, out result);
            if(isParsed){
                myRandom = new System.Random(result);
            }else{
                Debug.Log("init err");
                System.Random rnd = new System.Random();
                SetRndSeed(rnd.Next(0,999999)); 
                Debug.Log(GetRndSeed());
                myRandom = new System.Random(GetRndSeed());
            }
            
        }
        public System.Random GetRandom(){
            return myRandom;
        }
    }
}