using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[ExecuteInEditMode]
public class NFTsID_Nice1 : MonoBehaviour
{

    [SerializeField] string idNFT;
    
    [System.Serializable]
    public class Ids
    {
        public string id;
        public string type;
    }


    public List<Ids> idsList = new List<Ids>(1);
    public List<Ids> gamesList = new List<Ids>(1);
    public List<Ids> collectionsList = new List<Ids>(1);
    public List<Ids> namesList = new List<Ids>(1);
    public List<Ids> amountList = new List<Ids>(1);

    /* public void AddNew()
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
     }*/

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


        // game
        gamesList.Add(new Ids());
        gamesList[0].id = "Pixel 3D";
        gamesList[0].type = "type0";
        gamesList.Add(new Ids());
        gamesList[1].id = "Trix Foolish";
        gamesList[1].type = "type1";

        // Collection
        collectionsList.Add(new Ids());
        collectionsList[0].id = "Collection_1";
        collectionsList[0].type = "type0";
        collectionsList.Add(new Ids());
        collectionsList[1].id = "Collection_2";
        collectionsList[1].type = "type1";

        // Name
        namesList.Add(new Ids());
        namesList[0].id = "Sword_1";
        namesList[0].type = "type0";
        namesList.Add(new Ids());
        namesList[1].id = "Coin_1";
        namesList[1].type = "type1";


        // Amount
        amountList.Add(new Ids());
        amountList[0].id = "2";
        amountList[0].type = "type0";
        amountList.Add(new Ids());
        amountList[1].id = "10";
        amountList[1].type = "type1";
}

}

