using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Dialog
{
    private static Dialog instance;
    public static Dialog Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Dialog();
            }
            return instance;
        }
    }

    public List<string[]> DialogList = new List<string[]>
    {
        new string[] { "3", "0", "4", "2","5", "0","6", "2","7", "0","8", "1",  },//0
        new string[] { "9", "1","10", "2","11", "0",  },//1
        new string[] { "12", "0","13", "2","14", "0",},//2
        new string[] { "15", "0","16", "Tu","17", "0",},//3

    };

    public string[] GetDialog(int index)
    {
        if (index >= 0 && index < DialogList.Count)
        {
            return DialogList[index];
        }
        else
        {
            Debug.LogWarning("Index nằm ngoài phạm vi: " + index);
            return null;
        }
    }
}

