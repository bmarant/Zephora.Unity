using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
[System.Serializable]


public class Items
{
    public string ItemName;
    public float level = 1;

}



public class ShopCharacters : MonoBehaviour {
    public const string Connection = "http://74.80.233.83/CharacterR.php";
    public List<Items> playNames;
    public Transform contentPanel;
    public ShopCharacters characters;
    public Text Username;
    string[] characterNames;


    public SimpleObjectPool buttonObjectPool;
    public float levels = 1f;

	// Use this for initialization
	void Start () {
        RefreshDisplay();

        Username.text = PlayerPrefs.GetString("User");
	}


    public void RefreshDisplay()
    {
        

        AddButtons();
    }
	
	// Update is called once per frame
	
    private void AddButtons()
    {
        WWWForm forming = new WWWForm();
        WWW names = new WWW(Connection, forming);
       
        forming.AddField(Username.text.ToString(), PlayerPrefs.GetString("User"));
 
        
     characterNames = names.text.Split(' ');

    

        for(int i = 0; i < characterNames.Length; i++)
        {
            Items items = playNames[i];
        
            GameObject doButton = buttonObjectPool.GetObject();
            doButton.transform.SetParent(contentPanel);
            CharacterLists newCharacters = doButton.GetComponent<CharacterLists>();
            newCharacters.SetUp(items, this);
        }
    }
}
