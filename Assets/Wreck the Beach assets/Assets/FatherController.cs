using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherController : MonoBehaviour {

	public Animator animator;

	public int exitAfterLoops;

	private int loops;

	// Use this for initialization
	void Start () {
		loops = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TallyLoop()
	{
		loops++;

		if (loops >= exitAfterLoops)
		{
			animator.SetTrigger("exit");
		}
	}
}
