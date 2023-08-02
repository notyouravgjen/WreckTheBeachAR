using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Animator))]
public class TieredAnimation : MonoBehaviour {
    public int numStages;
    private int currStage;
    private Animator myAnimator;
	// Use this for initialization
	void Start () {
        myAnimator = gameObject.GetComponent<Animator>();
	}
	
    // Returns if currStage is now the final stage
    public bool AdvanceStage()
    {
        currStage++;
        if (currStage <= numStages)
        {
            myAnimator.SetInteger("NumHits", currStage);
        }
        return currStage >= numStages;
    }
}
