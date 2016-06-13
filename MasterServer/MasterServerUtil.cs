using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;

public class MasterServerUtil : MonoBehaviour {


    string serverNameRegistered = "ZephoraTheBeginningServer";
    public Text serverName;
    public Text server;
    bool isRefreshing = false;
    HostData[] hostData;
    HostData data;
    PassingData login;
   public Transform playerPrefab;
    public Text user;
    float requestTimeLength = 1.0f;
    GameObject persistant;
    string users;
    NetworkClient myClient;

    // Use this for initialization
    void Start()
    {


       // PassingData newData = new PassingData();
       // Debug.Log(newData.names.ToString());



        if (Network.isClient || Network.isServer)
            return;


        MasterServer.ipAddress = "74.80.233.83";
        Network.natFacilitatorIP = "74.80.233.83";
        Network.natFacilitatorPort = 50005;
        
        MasterServer.port = 4545;

        Network.InitializeServer(16, 4545, !Network.HavePublicAddress());

        MasterServer.RegisterHost(serverNameRegistered, "The Beginning", "The New Beginning");
        MasterServer.RequestHostList(serverNameRegistered);


        user = GameObject.Find("Users").GetComponent<Text>();

       // user.text = PlayerPrefs.GetString("Using");
        print(PlayerPrefs.GetString("Using"));
       

        users = PlayerPrefs.GetString("Using");

        user.text = users;
        Debug.Log(users);

        

        data = new HostData();




        serverName = GameObject.Find("ServerName").GetComponent<Text>();
        server = GameObject.Find("ServePopulation").GetComponent<Text>();
        persistant = GameObject.Find("LoginObject");


       


        Debug.Log(MasterServer.ipAddress + MasterServer.port.ToString());


        MasterServer.RequestHostList(serverNameRegistered);

        //   login = new LoginScript();






    }


    public void ServerInitial()
    {

    }
 
   

    void OnServerInitialized()
    {
        Debug.Log("Server has been initialized");
       

    }

    void OnMasterServerEvent(MasterServerEvent masterServerEvent)
    {
        if (masterServerEvent == MasterServerEvent.RegistrationSucceeded)
            Debug.Log("Registration Successful");

    

    }

   

	
	// Update is called once per frame
	

    public IEnumerator RefreshServerList()
    {
        Debug.Log("Refreshing....");
        MasterServer.RequestHostList(serverNameRegistered);
        float timeStart = Time.time;
        float timeEnded = Time.time + requestTimeLength;

        while (Time.time < timeEnded)
        {



            hostData = MasterServer.PollHostList();
            yield return new WaitForEndOfFrame();
        }
        if (hostData == null || hostData.Length == 0)
        {
            Debug.Log("No active servers have been found!");
        }
        else
            Debug.Log(hostData.Length + " Server has been found");

        

    }


    public void SetupClient()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            Network.Connect("74.80.233.83", 4545);
            Debug.Log("Connected");
            SceneManager.LoadScene("LoadingScreen");
        }



    }
    private void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Client is connected!");

    }

    public void StartServer()
    {
        StartCoroutine(RefreshServerList());
       
        if (hostData != null)
        {
            for (int i = 0; i < hostData.Length; i++)
            {
                serverName.text = hostData[i].gameName;
                server.text = data.connectedPlayers.ToString();
                
                
                
                
            }
        }

    }
}
