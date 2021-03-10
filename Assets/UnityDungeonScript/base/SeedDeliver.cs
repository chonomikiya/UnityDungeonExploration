using System.Collections;
using System.Collections.Generic;

public class SeedDeliver
{
    static int Seed;
    public static void SetSeed(int _src){
        Seed = _src;
    }
    public static void SetSeed(){
        Seed = new System.Random().Next(0,999999);
    }
    public static int GetSeed(){
        return Seed;
    }
}