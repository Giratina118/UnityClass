using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_String2Int : MonoBehaviour
{
    public int XX = 0;
    public int YY = 0;

    //string[] strArr = new string[3];



    protected void Test()
    {
        //System.Text.RegularExpressions.Regex;

        string tempstr = "Mine_[30, 10]";

        string tempstr2 = tempstr.Substring(6);
        int pos = tempstr2.IndexOf(']');
        string tempstr3 = tempstr.Substring(0, pos);

        string[] splite = tempstr3.Split(",");

        XX = int.Parse(splite[0]);
        YY = int.Parse(splite[1]);

        XX = System.Convert.ToInt32(splite[0]);
        YY = System.Convert.ToInt32(splite[1]);

    }

    void Start()
    {
        Test();

        
    }


    void Update()
    {
        
    }
}
