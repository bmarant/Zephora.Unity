using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class CharacterLists : MonoBehaviour {
  


    public Button nameList;
    public Text NameofCharacter;
    public Text levelOfCharacter;

   private Items playAttributes;
    private ShopCharacters scrollList;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.GetString("User");
    }
    public void SetUp(Items names, ShopCharacters currentScollList)
    {
        playAttributes = names;


        NameofCharacter.text = playAttributes.ItemName;
        levelOfCharacter.text = playAttributes.level.ToString();
        scrollList = currentScollList;
    }


       

	
	

}
