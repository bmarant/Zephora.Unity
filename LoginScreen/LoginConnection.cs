using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoginConnection : MonoBehaviour {

  public InputField Username;
  public InputField Password;

    public const string Connection = "http://74.80.233.83/LoginPhp.php";
    public string hash = "hashcode";


	// Use this for initialization
	void Start () {

        Username = GameObject.Find("Username").GetComponent<InputField>();
        Password = GameObject.Find("Password").GetComponent<InputField>();
       }
	
    public void LoginSystem()
    {

        StartCoroutine(Login());
    }




    IEnumerator Login()
    {
       
     
        WWWForm form = new WWWForm();

        form.AddField("login", hash.ToString());
        form.AddField("User",Username.text.ToString());
        form.AddField("Pass", Password.text.ToString());
        PlayerPrefs.GetString("User", Username.text.ToString());


        WWW connection = new WWW(Connection, form);


        yield return connection;
        if (connection.error != null)
        {
             Debug.Log(connection.text); //if there is an error, tell us
        }
        else
        {
            print("Test ok");
            print(connection.text.ToString());
          //here we return the data our PHP told us
            connection.Dispose(); //clear our form in game

            if (Username.text == "" || Password.text == "")
            {
                Debug.Log("Please enter a username and or password if left blank");
            }
            else
            {


                SceneManager.LoadScene("CharacterSelection");
            }
        }
    
    }

}
