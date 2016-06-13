using UnityEngine;
using System.Collections;

using UnityEngine.UI;

using System.Net;
using System.Net.Sockets;
using ZephorasWorld.UDPCLientServer;
using ZephorasWorld.UDPCLientServer.ZephorasWorld.UDPCLientServer;
using System;
using System.Text;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour {

    

    private const string hostName = "74.80.233.85";

    #region Server Members
    IPEndPoint server;
    private Socket clientSocket;
    private EndPoint epServer;
    private byte[] dataStream = new byte[1024];
    private delegate void DisplayMessageDelegate(string message);
    private DisplayMessageDelegate displayMessageDelegate = null;
    public InputField username;
    public InputField password;
    string URL = "http://74.80.233.83/LoginPhp.php";
    string hash = "hashcode";
    string registerGameName = "ZephoraServer";
    public GameObject users;
    public string names;
   
    #endregion

    // Use this for initialization
    void Start() {


       
       

        GameObject newusers = GameObject.Find("UsernameField");
        GameObject newpassword = GameObject.Find("PasswordField");

    

        username = newusers.GetComponent<InputField>();
        password = newpassword.GetComponent<InputField>();
        
        
        users = GameObject.Find("LoginObject");
       
      


    }
  
    void Awake()
    {
        DontDestroyOnLoad(this);
    }


    // Update is called once per frame

  
    public void ConnectionToLoginServer()
    {
        StartCoroutine(Login());

        LoginPacket NewLogin = new LoginPacket();

        NewLogin.ChatName = username.text.ToString() + "\n"+ "Password: " + password.text.ToString();
        NewLogin.ChatDataIdentifier = DataIdentifier.LogIn;










        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        IPAddress serverIP = IPAddress.Parse("74.80.233.85");

        server = new IPEndPoint(serverIP, 4546);


        epServer = (EndPoint)server;

        byte[] data = NewLogin.GetDataStream();


        clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, epServer, new AsyncCallback(this.SendData), null);


        clientSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref epServer, new AsyncCallback(this.ReceiveData), null);



        Debug.Log(server);

        Debug.Log(NewLogin.ChatName);
      
    }

    private void ReceiveData(IAsyncResult ar)
    {

        Console.WriteLine("Receiving...");
        var udpClient = new UdpClient(4546);
        var endPoint = new IPEndPoint(IPAddress.Any, 0);
        byte[] data = udpClient.Receive(ref endPoint);
        Debug.Log("Received '{0}'." + Encoding.UTF8.GetString(data));
        udpClient.Close();





        // Continue listening for broadcasts

        clientSocket.BeginReceiveFrom(this.dataStream, 0, this.dataStream.Length, SocketFlags.None, ref epServer, new AsyncCallback(this.ReceiveData), null);


       


    }

   

    private void SendData(IAsyncResult ar)
    {
        try
        {
            clientSocket.EndSend(ar);
        }
        catch(SocketException e)
        {
            Debug.Log("There was an error with username and or password");
        }
    }


    IEnumerator Login()
    {

     
        names = username.text.ToString();

      

        WWWForm login = new WWWForm();

       
        

            login.AddField("login", hash.ToString());
            login.AddField("User", username.text.ToString());
            login.AddField("Pass", password.text.ToString());
      



       


            WWW connect = new WWW(URL, login);




            yield return connect;




            if (connect.error != null)
            {
                Debug.Log(connect.error);
            }
            else
            {

                string connections = connect.text.ToString();

                string[] connecting = connections.Split(';');
                Debug.Log(connect.text);
                if(connecting[0]== "Success")
                {
                    Debug.Log(connecting[0]);
               
                PlayerPrefs.SetString("Using", username.text.ToString());
                PlayerPrefs.Save();
                SceneManager.LoadScene("ServerScreen");
            }
              
               


               

               


            

          





        }
    }
}
public class StateObject
{
    // Client socket.
    public Socket workSocket = null;
    // Size of receive buffer.
    public const int BufferSize = 256;
    // Receive buffer.
    public byte[] buffer = new byte[BufferSize];
    // Received data string.
    public StringBuilder sb = new StringBuilder();
}
