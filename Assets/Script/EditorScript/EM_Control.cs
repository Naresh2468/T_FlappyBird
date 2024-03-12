using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class EM_Control : Editor // parent class use for playmode
{

    static EM_Control() //t's executed when Unity loads the editor
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged; //triggered whenever the playmode is state changes.
    }


    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        //  check if the editor is transitioning into Play Mode  and  editor is not already in Play Mode.
        if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = true;
        }
        
        
    }
    [MenuItem("N.R_Collections/PlayModeToggle _SPACE")]
    private static void TogglePlayMode()
    {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                EditorApplication.isPlaying = false;
            }
            else
            {
                 EditorApplication.isPlaying = true;
            }
    }
}
