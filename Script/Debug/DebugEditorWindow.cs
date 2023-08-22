using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

#if false
public class DebugEditorWindow : EditorWindow
{
    

    [MenuItem("Debug/GetPoint")]
    private static void GetPoint()
    {
        var point = PlayerPrefs.GetInt("POINT", 0);
        point += 10;
        PlayerPrefs.SetInt("POINT", point);
    }
    
}
#endif
