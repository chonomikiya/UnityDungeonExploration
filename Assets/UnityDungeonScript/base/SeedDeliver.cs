using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedDeliver
{
    private static int Seed;
    public void SetSeed(){
        Seed = new System.Random().Next(0,999999);
    }
    public void SetSeed(int _src){
        Seed = _src;
    }
    public int GetSeed(){
        Debug.Log(Seed);
        return Seed;
    }
}