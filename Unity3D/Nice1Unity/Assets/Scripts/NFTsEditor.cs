using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NFTsID))]
[CanEditMultipleObjects]
public class NFTsEditor : Editor
{
    SerializedProperty isNFT;

    // FROM MANAGER
    // Get
    // - nfts
    //  - id
    //  - amount

    enum displayFieldType { DisplayAsAutomaticFields, DisplayAsCustomizableGUIFields }
    displayFieldType DisplayFieldType;

    SerializedObject GetTarget;
    SerializedProperty ThisList;
    int ListSize;
    List<bool> toggled = new List<bool>(); // Folded or not

    int index = 0;

    NFTsID t;
    void OnEnable()
    {
        t = (NFTsID)target;
        GetTarget = new SerializedObject(t);
        ThisList = GetTarget.FindProperty("idsList"); // Find the List in our script and create a refrence of it

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("NFTS Nice1: ", "NFT parameters");

       

        serializedObject.ApplyModifiedProperties();


             //Update our list
 
        GetTarget.Update();
 
        //Choose how to display the list<> Example purposes only
     //   EditorGUILayout.Space();
    //    EditorGUILayout.Space();
     //   DisplayFieldType = (displayFieldType)EditorGUILayout.EnumPopup("", DisplayFieldType);
 
        //Resize our list
    //    EditorGUILayout.Space();
    //    EditorGUILayout.Space();
    //    EditorGUILayout.LabelField("Define the list size with a number");
        ListSize = ThisList.arraySize;
    //    ListSize = EditorGUILayout.IntField("List Size", ListSize);
 
        if (ListSize != ThisList.arraySize)
        {
            while (ListSize > ThisList.arraySize)
            {
                ThisList.InsertArrayElementAtIndex(ThisList.arraySize);
            }
            while (ListSize < ThisList.arraySize)
            {
                ThisList.DeleteArrayElementAtIndex(ThisList.arraySize - 1);
            }
        }
 
 /*       EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Or");
        EditorGUILayout.Space();
        EditorGUILayout.Space();*/
 
        //Or add a new item to the List<> with a button
     //   EditorGUILayout.LabelField("Add a new item with a button");
 
    /*    if (GUILayout.Button("Add New"))
        {
                t.idsList.Add(new NFTsID.Ids());
        }
 
        EditorGUILayout.Space();
        EditorGUILayout.Space();*/

        //Display our list to the inspector window
        string[] idsArray = new string[ThisList.arraySize];
 
        for (int i = 0; i < ThisList.arraySize; i++)
        {
            toggled.Add(false); // Initialliazed as false
            SerializedProperty MyListRef = ThisList.GetArrayElementAtIndex(i);
            SerializedProperty MyId = MyListRef.FindPropertyRelative("id");
            SerializedProperty MyType = MyListRef.FindPropertyRelative("type");

            idsArray[i] = MyId.stringValue;

          //  toggled[i] = EditorGUILayout.Foldout(toggled[i], "[" + i +"]"); // Index Foldout
            // Display the property fields in two ways.
       /*     if (toggled[i] == true)
            {
                if (DisplayFieldType == 0)
                {// Choose to display automatic or custom field types. This is only for example to help display automatic and custom fields.
                 //1. Automatic, No customization <-- Choose me I'm automatic and easy to setup
                    EditorGUILayout.LabelField("Automatic Field By Property Type");
                    EditorGUILayout.PropertyField(MyId);
                    EditorGUILayout.PropertyField(MyType);
 
                    // Array fields with remove at index
                    EditorGUILayout.Space();
    
                }
                else
                {
                    //Or
 
                    //2 : Full custom GUI Layout <-- Choose me I can be fully customized with GUI options.
                    EditorGUILayout.LabelField("Customizable Field With GUI");

                    Debug.Log(MyId.stringValue);
                    MyId.stringValue = EditorGUILayout.TextField("Id: ", MyId.stringValue);
                    MyType.stringValue = EditorGUILayout.TextField("My Custom type", MyType.stringValue);
                 
                  
                }
 
                EditorGUILayout.Space();
 
                //Remove this index from the List
                EditorGUILayout.LabelField("Remove an index from the List<> with a button");
                if (GUILayout.Button("Remove This Index (" + i.ToString() + ")"))
                {
                    ThisList.DeleteArrayElementAtIndex(i);
                }
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
            }*/
        }

        EditorGUILayout.Space();
        SerializedProperty idNFT = serializedObject.FindProperty("idNFT");
        EditorGUILayout.Space();
        index = EditorGUILayout.Popup(index, idsArray);

        //Apply the changes to our list
        GetTarget.ApplyModifiedProperties();
    }
}

