using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Creation : MonoBehaviour {


    bool toggle = false;
    public InputField CharName;
    public Toggle Male;
    public Toggle Female;
    public Dropdown dropDown;
    public string classes;
    public Text characterNames;
    public string nameing;
    XmlSave saving;
    public string Gender;


   void Start()
    {
        saving = new XmlSave();
      
    }

    public void CharacterName()
    {
        nameing = characterNames.text;

        Debug.Log("Name of Character is: " + nameing);

    }



    //Check what toggle is active//
    public void ActiveToggle()
    {

  

        if(Male.isOn)
        {
            Debug.Log("You have selected Male");
            Gender = Male.name;
            
        }
        else if(Female.isOn)
        {
            Debug.Log("You have Selected Female");
            Gender = Female.name;

        }
        else
        {
            Debug.Log("Please make a selection");
        }
    }


    public void OnChangedHandler(Dropdown target)
    {
       

      classes = target.options[target.value].text;

        Debug.Log("Class Selected: " + target.value + " " + classes);


    }

    public void OnSubmit()
    {

        saving = new XmlSave();
        //Check active toggle//
        ActiveToggle();

        OnChangedHandler(dropDown);

        CharacterName();

        saving.SaveCharacter(characterNames.text.ToString(), classes,Gender);

        
    }
	
}
