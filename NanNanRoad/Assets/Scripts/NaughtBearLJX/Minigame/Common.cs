using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common
{
    private int hp;
    public int HP { get { return hp; } set{ hp = value; }}
    public Common() { hp = 1; }
}

public class Tree : Common
{
    public Tree(): base() {  }
}

public class Stone : Common
{
    public Stone() : base() { }
}



