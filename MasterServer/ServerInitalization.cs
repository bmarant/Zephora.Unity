using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ServerInitalization : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    //Server Inialization//


    public void Connect()
    {
        Debug.Log("Connected to Server");
        SceneManager.LoadScene("LoadingScreen");
    }


  
}
