using System.Collections;
using System.Collections.Generic;
using System;
public class randomCtl 
{
    System.Random myRandom;
    private string seed = "";
    public string Seed{get{return seed;}set{seed = value;}}
    public void InitRandom(){
        
        myRandom = new System.Random();
    }
}
