using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedEvents : MonoBehaviour {

	public static ScriptedEvents instance { get; private set; }

	public GameObject[] scriptedEvents;

	private int index;

	// Use this for initialization
	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}

		index = -1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void HideCurrentScript()
	{
		scriptedEvents[index].SetActive(false);
	}

	public void ShowNextScript()
	{
		if (index >= 0)
		{
			scriptedEvents[index].SetActive(false);
		}

		index++;
		Invoke("ShowNextScriptInternal", 1.0f);
	}

	private void ShowNextScriptInternal()
	{
		if (index < scriptedEvents.Length)
		{
			scriptedEvents[index].SetActive(true);
		}
	}
}
