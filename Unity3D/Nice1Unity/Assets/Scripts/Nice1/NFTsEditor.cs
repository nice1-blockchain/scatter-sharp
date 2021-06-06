using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NFTsID_Nice1))]
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
    SerializedProperty ListGame;
    SerializedProperty ListCollection;
    SerializedProperty ListName;
    SerializedProperty ListAmount;
    int ListSize;
    List<bool> toggled = new List<bool>(); // Folded or not

    int index = 0;
    int index2 = 0;
    int index3 = 0;
    int index4 = 0;

    NFTsID_Nice1 t;
    NFTsID_Nice1 t2;
    void OnEnable()
    {
     //   t = (NFTsID_Nice1)target;
     //   GetTarget = new SerializedObject(t);
      //  ThisList = GetTarget.FindProperty("idsList"); // Find the List in our script and create a refrence of it
       // Debug.Log(ThisList.arraySize);

        t2 = (NFTsID_Nice1)target;
        GetTarget = new SerializedObject(t2);
        ListGame = GetTarget.FindProperty("gamesList");
        Debug.Log(ListGame.arraySize);

        ListCollection = GetTarget.FindProperty("collectionsList");
        Debug.Log(ListCollection.arraySize);

        ListName = GetTarget.FindProperty("namesList");
        Debug.Log(ListName.arraySize);

        ListAmount = GetTarget.FindProperty("amountList");
        Debug.Log(ListAmount.arraySize);

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("NFTS Nice1 ", "NFT parameters");

       

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
//        ListSize = ThisList.arraySize;
    //    ListSize = EditorGUILayout.IntField("List Size", ListSize);
 
 /*       if (ListSize != ThisList.arraySize)
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

   */     ListSize = ListGame.arraySize;

        if (ListSize != ListGame.arraySize)
        {
            while (ListSize > ListGame.arraySize)
            {
                ListGame.InsertArrayElementAtIndex(ListGame.arraySize);
            }
            while (ListSize < ListGame.arraySize)
            {
                ListGame.DeleteArrayElementAtIndex(ListGame.arraySize - 1);
            }
        }


        ListSize = ListCollection.arraySize;

        if (ListSize != ListCollection.arraySize)
        {
            while (ListSize > ListCollection.arraySize)
            {
                ListCollection.InsertArrayElementAtIndex(ListCollection.arraySize);
            }
            while (ListSize < ListGame.arraySize)
            {
                ListCollection.DeleteArrayElementAtIndex(ListCollection.arraySize - 1);
            }
        }

        ListSize = ListName.arraySize;

        if (ListSize != ListName.arraySize)
        {
            while (ListSize > ListName.arraySize)
            {
                ListName.InsertArrayElementAtIndex(ListName.arraySize);
            }
            while (ListSize < ListGame.arraySize)
            {
                ListName.DeleteArrayElementAtIndex(ListName.arraySize - 1);
            }
        }

        ListSize = ListAmount.arraySize;

        if (ListSize != ListAmount.arraySize)
        {
            while (ListSize > ListAmount.arraySize)
            {
                ListAmount.InsertArrayElementAtIndex(ListAmount.arraySize);
            }
            while (ListSize < ListAmount.arraySize)
            {
                ListAmount.DeleteArrayElementAtIndex(ListAmount.arraySize - 1);
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
        //  string[] idsArray = new string[ThisList.arraySize];
        string[] gamesArray = new string[ListGame.arraySize];
        string[] collectionsArray = new string[ListCollection.arraySize];
        string[] namesArray = new string[ListName.arraySize];
        string[] amountArray = new string[ListAmount.arraySize];

        /*    for (int i = 0; i < ThisList.arraySize; i++)
            {
                toggled.Add(false); // Initialliazed as false
                SerializedProperty MyListRef = ThisList.GetArrayElementAtIndex(i);
                SerializedProperty MyId = MyListRef.FindPropertyRelative("id");
                SerializedProperty MyType = MyListRef.FindPropertyRelative("type");

                idsArray[i] = MyId.stringValue;


            }*/


        for (int i = 0; i < ListGame.arraySize; i++)
        {          
            toggled.Add(false); // Initialliazed as false
            SerializedProperty MyListRef = ListGame.GetArrayElementAtIndex(i);
            SerializedProperty MyId = MyListRef.FindPropertyRelative("id");    
            gamesArray[i] = MyId.stringValue;
        }

        for (int i = 0; i < ListCollection.arraySize; i++)
        {
            toggled.Add(false); // Initialliazed as false
            SerializedProperty MyListRef = ListCollection.GetArrayElementAtIndex(i);
            SerializedProperty MyId = MyListRef.FindPropertyRelative("id");
            collectionsArray[i] = MyId.stringValue;
        }

        for (int i = 0; i < ListName.arraySize; i++)
        {
            toggled.Add(false); // Initialliazed as false
            SerializedProperty MyListRef = ListName.GetArrayElementAtIndex(i);
            SerializedProperty MyId = MyListRef.FindPropertyRelative("id");
            namesArray[i] = MyId.stringValue;
        }

        for (int i = 0; i < ListAmount.arraySize; i++)
        {
            toggled.Add(false); // Initialliazed as false
            SerializedProperty MyListRef = ListAmount.GetArrayElementAtIndex(i);
            SerializedProperty MyId = MyListRef.FindPropertyRelative("id");
            amountArray[i] = MyId.stringValue;
        }


        /*  EditorGUILayout.Space();
          SerializedProperty idNFT = serializedObject.FindProperty("idNFT");
          EditorGUILayout.Space();
          EditorGUILayout.LabelField("idNFT");
          index = EditorGUILayout.Popup(index, idsArray);*/

        EditorGUILayout.Space();
        SerializedProperty  idNFT = serializedObject.FindProperty("idNFT");
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Game");
        index = EditorGUILayout.Popup(index, gamesArray);


        EditorGUILayout.Space();
         idNFT = serializedObject.FindProperty("idNFT");
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Collection");
        index2 = EditorGUILayout.Popup(index, collectionsArray);

        EditorGUILayout.Space();
         idNFT = serializedObject.FindProperty("idNFT");
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Name");
        index3 = EditorGUILayout.Popup(index, namesArray);

        EditorGUILayout.Space();
         idNFT = serializedObject.FindProperty("idNFT");
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Amount");
        index4 = EditorGUILayout.Popup(index, amountArray);


        EditorGUILayout.Space();
        GUILayout.Button("Apply");

        //Apply the changes to our list
        GetTarget.ApplyModifiedProperties();
    }
}

