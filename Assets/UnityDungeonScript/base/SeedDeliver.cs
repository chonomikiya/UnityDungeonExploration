using System.Collections;
using System.Collections.Generic;

public class SeedDeliver
{
    private static int Seed;
    public void SetSeed(int _src){
        Seed = _src;
    }
    public void SetSeed(){
        Seed = new System.Random().Next(0,999999);
    }
    public int GetSeed(){
        
        return Seed;
    }
    public void DeleteSeed(){
    }
}