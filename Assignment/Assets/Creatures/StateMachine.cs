using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract void Assess();
    public abstract void Act();
    public abstract void PopState();
    public abstract void PushState(int state);
    public abstract void Die();
}
