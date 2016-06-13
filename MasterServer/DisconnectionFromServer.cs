using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DisconnectionFromServer : MonoBehaviour {

	// Use this for initialization
	
    public void DisconnectFromServer()
    {
        if(Network.peerType == NetworkPeerType.Client)
        {
            Debug.Log("Disconnected from Server");
        //    Network.Disconnect(250);
         
            SceneManager.LoadScene("LoadingScreen");
        }
        else
        {
            if(Network.peerType == NetworkPeerType.Server)
            {
                
                Debug.Log("Server has been shut down");
                Network.Disconnect(250);
            }
        }
    }
}
