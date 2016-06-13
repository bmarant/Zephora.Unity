using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PassingData : MonoBehaviour {

    public string names;

   
    public GameObject persistentObject;
    public InputField userdata;
    LoginScript userpass;

    void Start()
    {
        DontDestroyOnLoad(persistentObject);
    }

    public void Pass()
    {

     

        userdata = GameObject.Find("UsernameField").GetComponent<InputField>();
        persistentObject = GameObject.Find("LoginObject");
        userpass = new LoginScript();


        names = userdata.text.ToString();

     


        Debug.Log(names);


        Debug.Log("Not destroyed");
    }



	
	
	
}
