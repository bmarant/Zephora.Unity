using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;

public class Selection : MonoBehaviour, IPointerClickHandler
{

    public Text serverNames;
    public Text servers;

   void Start()
    {
        serverNames = GameObject.Find("ServerName").GetComponent<Text>();
        servers = GameObject.Find("Server").GetComponent<Text>();
    }




    public void OnPointerClick(PointerEventData eventData)
    {

       


            eventData.selectedObject = gameObject;
            servers.text = serverNames.text;
        


    }


    
}
