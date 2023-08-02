using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
    public delegate void DamageThings(float damage);
    public static event DamageThings DamageThingsEvent;
    public delegate void TookDamage(bool wasDestroyed);
    public static event TookDamage TookDamageEvent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void BroadcastDamageThings(float damage)
    {
        if (DamageThingsEvent != null)
        {
            DamageThingsEvent(damage);
        }
    }

    public static void BroadcastTookDamage(bool wasDestroyed)
    {
        if (TookDamageEvent != null)
        {
            TookDamageEvent(wasDestroyed);
        }
    }
}
