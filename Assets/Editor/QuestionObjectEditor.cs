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

        QuestionObject script = target as QuestionObject;
        if (GUILayout.Button("Build Object"))
        {
            script.pageList = new List<GameObject>();
            Transform[] array = script.gameObject.GetComponentsInChildren<Transform>(true);

            for(int i = 0; i < array.Length; i++)
            {
                if(array[i].name.Contains("Page"))
                {
                    script.pageList.Add(array[i].gameObject);
                }
                
            }

        }
    }


}
