using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour {

    public string electronsPerShell;
    public string atom;
    public GameObject protonPrefab;
    public GameObject electronPrefab;

    // Use this for initialization
    void Start () {

        electronsPerShell = "1";
        atom = "Hydrogen";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
