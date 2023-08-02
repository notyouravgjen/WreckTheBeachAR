using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ProgressToNextLevel()
	{
		GameManager.instance.ProgressRound();
	}
}
