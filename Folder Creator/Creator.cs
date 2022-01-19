using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FolderCreator : EditorWindow
{
    public string[] folderNames = { "Scripts", "Materials", "Textures", "Sprites", "UI", "Models", "Prefabs", "Particles", "Font", "Thirdparty", "Sounds" };

    [MenuItem("Tools/Folder Creator")]
    private static void CreateFolderList()
    {
        GetWindow<FolderCreator>("Folder Creator"); // Creates a new window
    }

    private void OnGUI()
    {
        ScriptableObject target = this; // instance of this class
        SerializedObject so = new SerializedObject(target); // serialized object of this class
        SerializedProperty stringsProperty = so.FindProperty("folderNames"); // Find the strings property

        EditorGUILayout.PropertyField(stringsProperty, true); // True means show children
        so.ApplyModifiedProperties(); // Remember to apply modified properties

        GUILayout.Space(15);

        if (GUILayout.Button("Create Folders"))
        {
            CreateFolders();
        }
    }

    private void CreateFolders()
    {
        foreach (var folderName in folderNames)
        {
            if (!AssetDatabase.IsValidFolder("Assets/" + folderName)) // If the folder doesn't exist
            {
                AssetDatabase.CreateFolder("Assets", folderName); // Create the folder
            }
        }
    }
}
