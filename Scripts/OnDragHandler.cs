using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class OnDragHandler : MonoBehaviour, IDragHandler,IBeginDragHandler ,IPointerClickHandler {


    public static GameObject itemBeingDragged;
    private Vector3 startPosition;
    private Transform startParent;


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;


      //  Debug.Log("Hello");
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Hello");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Weeeee ive been clicked!");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Weeeee ive been clicked!");
    }
}
