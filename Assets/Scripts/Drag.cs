using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Transform char_W;
	public Transform old;


	void Start () 
	{
		char_W = GameObject.Find ("Character_Window").transform;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		old = transform.parent;
		transform.SetParent (char_W);
		GetComponent<CanvasGroup> ().blocksRaycasts = false;

	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent == char_W) 
		{
			transform.SetParent (old);
		}
	}

}
