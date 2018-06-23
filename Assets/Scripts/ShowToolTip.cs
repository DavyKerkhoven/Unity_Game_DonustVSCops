using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowToolTip : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
	
	public GameObject tooltip;

	// Use this for initialization
	void Start () 
	{
		tooltip.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
	{
		tooltip.SetActive (true);
	}

	public void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
	{
		tooltip.SetActive (false);
	}
}
