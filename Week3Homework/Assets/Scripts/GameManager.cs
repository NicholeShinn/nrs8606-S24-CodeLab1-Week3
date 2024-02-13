using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //declaring the 3 lines that will be changeable after loading saved data
    public string line01 = "";
    public string line02 = "";
    public string line03 = "";

    const string KEY_LINE_ONE = "Line 01";
    
    //I did this by applying each line into their own .txt data file. Maybe there is an easier way!
    //you have to have the string to be filled, and use get & set to find the stored string and then fill it, until it is replaced
    public string Line01
    {
        get
        {
            if (File.Exists(DATA_FULL_LINEONE_FILE_PATH)) 
            {
                string fileContents = File.ReadAllText(DATA_FULL_LINEONE_FILE_PATH); //file contents for line 1 is read from the stored text
                line01 = fileContents; //therefore line 1 equals the file contents
            }
            
            return line01; //so we return with that data saved
        }

        set
        {
             line01 = value; //now we set the live version that we see from this "get" value
             Debug.Log("line changed!");
             
             string fileContent = "" + line01;

             if (!Directory.Exists(Application.dataPath + DATA_DIR))
             {
                 Directory.CreateDirectory(Application.dataPath + DATA_DIR);
             }

             File.WriteAllText(DATA_FULL_LINEONE_FILE_PATH, fileContent); //replacing the current saved data, with new by rewriting the saved text
        }
        
    }
    
    //we continue this for each line
    const string KEY_LINE_TWO = "Line 01";
    public string Line02
    {
        get
        {
            if (File.Exists(DATA_FULL_LINETWO_FILE_PATH))
            {
                string fileContents = File.ReadAllText(DATA_FULL_LINETWO_FILE_PATH);
                line02 = fileContents;
            }
            
            return line02;
        }

        set
        {
            line02 = value;
            Debug.Log("line changed!");
             
            string fileContent = "" + line02;

            if (!Directory.Exists(Application.dataPath + DATA_DIR))
            {
                Directory.CreateDirectory(Application.dataPath + DATA_DIR);
            }

            File.WriteAllText(DATA_FULL_LINETWO_FILE_PATH, fileContent);
        }
        
    }
    
    const string KEY_LINE_THREE = "Line 01";
    public string Line03
    {
        get
        {
            if (File.Exists(DATA_FULL_LINETHREE_FILE_PATH))
            {
                string fileContents = File.ReadAllText(DATA_FULL_LINETHREE_FILE_PATH);
                line03 = fileContents;
            }
            
            return line03;
        }

        set
        {
            line03 = value;
            Debug.Log("line changed!");
             
            string fileContent = "" + line03;

            if (!Directory.Exists(Application.dataPath + DATA_DIR))
            {
                Directory.CreateDirectory(Application.dataPath + DATA_DIR);
            }

            File.WriteAllText(DATA_FULL_LINETHREE_FILE_PATH, fileContent);
        }
        
    }
    
    public TextMeshProUGUI poemText;

    //below we are declaring the data folder, and the 3 files to be created for each line
    const string DATA_DIR = "/Data/";
    const string DATA_LINEONE_FILE = "line1.txt";
    const string DATA_LINETWO_FILE = "line2.txt";
    const string DATA_LINETHREE_FILE = "line3.txt";

    //these are the actual paths to use when pulling the .txt files
    string DATA_FULL_LINEONE_FILE_PATH;
    string DATA_FULL_LINETWO_FILE_PATH;
    string DATA_FULL_LINETHREE_FILE_PATH;
    
    void Awake()
    {
        if (instance == null) //if the instance var has not been set
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else //if there is already a singleton of this type
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //on game start we find the path within the application, so that the functions above can call on them
        DATA_FULL_LINEONE_FILE_PATH = Application.dataPath + DATA_DIR + DATA_LINEONE_FILE;
        DATA_FULL_LINETWO_FILE_PATH = Application.dataPath + DATA_DIR + DATA_LINETWO_FILE;
        DATA_FULL_LINETHREE_FILE_PATH = Application.dataPath + DATA_DIR + DATA_LINETHREE_FILE;
    }

    // Update is called once per frame
    void Update()
    {
        //way to reset the key lines
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteKey(KEY_LINE_ONE);
            PlayerPrefs.DeleteKey(KEY_LINE_TWO);
            PlayerPrefs.DeleteKey(KEY_LINE_THREE);
        }

        //this displays the three lines as they change in real time
        poemText.text = "Line 1: " + Line01 + "\nLine 2: " + Line02 + "\nLine 3: " + Line03;
        
    }
}
