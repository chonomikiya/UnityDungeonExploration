using System.Collections;
using System.Collections.Generic;

public class randomCtl 
{
    System.Random myRandom;
    private string seed;
    public string Seed{
        set{this.seed=value;}
        get{return seed;}
    }
    public void InitRandom(){
        myRandom = new System.Random(Seed.get);
    }
}
