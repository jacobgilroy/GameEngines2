using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hungry : MonoBehaviour {

    public BirdController controller;
    bool anyFood;
    GameObject closestFood;

	// Use this for initialization
	void Start () {

        controller = GetComponent<BirdController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Run()
    {
        Vector3 dist;
        Vector3 shortestDist;


        // find the closest food:

        GameObject[] availableFruit = GameObject.FindGameObjectsWithTag("food");

        if (availableFruit.Length > 0)
        {
            anyFood = true;
            shortestDist = (availableFruit[0].transform.position - transform.position);

            foreach (GameObject f in availableFruit)
            {
                dist = f.transform.position - transform.position;

                if (dist.magnitude < shortestDist.magnitude)
                {
                    shortestDist = dist;
                    closestFood = f;
                }
            }

            
            if (GetComponent<Seek>())
            {
                Debug.Log("I'm Here!!!");
            }
            

            // set the Seek script's target object to be the nearest fruit:
            GetComponent<Seek>().enabled = true;
            GetComponent<Seek>().targetObj = closestFood;

        }
        else
        {
            anyFood = false;
            GetComponent<Seek>().enabled = false;

        }
    }
}
