using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using UXF; 

public class TrialListReader : MonoBehaviour
{
    private static readonly string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r"; // \n va daccapo su Mac, \r is for Windows

    public string[] TrialList;

    public void Awake()
    {
    Debug.Log("Reading Trial List...\n");
        TextAsset trialListFile = Resources.Load<TextAsset>("TrialList"); //reads the csv file (providing its path)
        if (trialListFile == null)
        {
            Debug.Log("Trial List file not found\n");
            return;
        }

        TrialList = Regex.Split(trialListFile.text, LINE_SPLIT_RE); 

        if (TrialList.Length <= 1)
            return;
        }

    }