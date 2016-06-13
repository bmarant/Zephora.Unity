using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.MasterServer
{
    class Networkconnections : MonoBehaviour
    {

        void PrintText(string text, NetworkMessageInfo info)
        {
            Debug.Log(text + "from" + info.sender);
        }
        public void OnConnectedToServer()
        {
            


                SceneManager.LoadScene("LoadingScreen");



            





        }
    }
}
