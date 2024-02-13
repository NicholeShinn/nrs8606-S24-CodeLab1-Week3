using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    public static string inputText01; //identifying line 1 of poem
    public static string inputText02; //identifying line 2 of poem
    public static string inputText03; //identifying line 3 of poem
    
    //creating an on input (when you press return/enter) to be recorded
    //and then reflected into the game manager text line.
    //you must do it for all 3 lines to change them individually 
    public void ReadStringInput(string a)
    {
        inputText01 = a;
        Debug.Log(inputText01);
        GameManager.instance.Line01 = inputText01;
    }
    
    public void ReadStringInput2(string b)
    {
        inputText02 = b;
        Debug.Log(inputText02);
        GameManager.instance.Line02 = inputText02;
    }
    
    public void ReadStringInput3(string c)
    {
        inputText03 = c;
        Debug.Log(inputText03);
        GameManager.instance.Line03 = inputText03;
    }
}
