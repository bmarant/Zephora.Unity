using UnityEngine;
using UnityEngine.UI;



public class InvetorySystem : MonoBehaviour {

   public GameObject InvetoryWindow;
    public Text Charactersname;
    public Text characterthreed;
    public TextMesh Name3d;
   
    private bool invetoryOnOff;
	// Use this for initialization
	void Start () {

        InvetoryWindow = GameObject.Find("Invetory");
        Charactersname = GameObject.Find("CharactersName").GetComponent<Text>();
        characterthreed = GameObject.Find("Name").GetComponent<Text>();
        Name3d = GameObject.Find("NameofCharacter").GetComponent<TextMesh>();

        Player newPlayer = new Player();
        newPlayer.Name = "Johnny";

        Charactersname.text = newPlayer.Name;
        characterthreed.text = newPlayer.Name;
        Name3d.text = newPlayer.Name;
       
        


	

	}
	
	// Update is called once per frame
	void Update () {

    

        if (Input.GetKeyDown("i"))
        //  print("I Key was pressed!");
        {
          
                invetoryOnOff = !invetoryOnOff;
                InvetoryWindow.SetActive(invetoryOnOff);
            
            }

    }







   
}
