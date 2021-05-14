using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[ExecuteInEditMode]
public class NFTsID : MonoBehaviour
{
    [SerializeField] string idNFT;
    
    [System.Serializable]
    public class Ids
    {
        public string id;
        public string type;
    }


    public List<Ids> idsList = new List<Ids>(1);

    public void AddNew()
    {
        idsList.Add(new Ids());
        string myString = "";
        for (int j = 0; j < 32; j++)
        {
            myString += glyphs[Random.Range(0, glyphs.Length)];
        }
        idsList[idsList.Count-1].id = myString;
        idsList[idsList.Count - 1].type = "type" + (idsList.Count - 1).ToString();
    }

    private void Remove(int index)
    {
        idsList.RemoveAt(index);
    }

    const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
    
    
    private void Start()
    { 
        for (int i = 0; i < 10; i++)
        {
            string myString = "";
            idsList.Add(new Ids());
            for (int j = 0; j < 32; j++)
            {
                myString += glyphs[Random.Range(0, glyphs.Length)];
            }
            idsList[i].id = myString;
            idsList[i].type = "type" + i;
        }
        
    }

}

