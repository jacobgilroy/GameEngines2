using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    List<SteeringBehaviour> behaviours = List<SteeringBehaviour>();

    public Vector3 force = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public VEctor3 velocity = Vector3.zero;
    public int mass = 1;
    public float maxSpeed = 10.0f;
    public float distFromNucleus;

	// Use this for initialization
	void Start () {

        SteeringBehaviour[] behaviours = GetComponent<SteeringBehaviour>();

        foreach (SteeringBehaviour b in behaviours)
        {
            this.behaviours.Add(b);
        }
	}

    public Vector3 seekForce(Vector3 target)
    {
        Vector3 between = target - transform.position;
        between.normalize();
        between *= maxSpeed;
        return between - velocity;
    }

    public Vector3 Calculate()
    {
        force = Vector3.zero;

        foreach (SteeringBehaviour b in behaviours)
        {
            if (b.isActiveAndEnabled)
            {
                force += b.calculate() * b.weight;
            }
        }

        return force;
    }
    
	
	// Update is called once per frame
	void Update () {

        force = Calculate();


	}
}
