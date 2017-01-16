using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginScripts : MonoBehaviour {

    public Text Usernames;

	// Use this for initialization
	void Start () {

        Usernames.text = PlayerPrefs.GetString("User");
	
	}
	
	
}
