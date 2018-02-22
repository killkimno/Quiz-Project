using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestionObject))]
public class QuestionObjectEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        QuestionObject aa = target as QuestionObject;
        if (GUILayout.Button("Build Object"))
        {
          //  myScript.BuildObject();
        }
    }


}
