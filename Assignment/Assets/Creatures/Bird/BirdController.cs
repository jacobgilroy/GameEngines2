using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : StateMachine {

    // declare health stats:
    public int hunger;
    public int hungerThresh = 15; // if hunger grows above this level, the bird must find food
    public int energyThresh = 25; // if hunger grows above this level, the bird becomes tired

    //declare unumeration states:
    public enum State
    {
        Hungry,
        Tired,
        Happy
    }

    public Stack<State> feelings = new Stack<State>();

    //declare emotional states:
    Hungry hungry;
    Tired tired;
    Happy happy;

    // Use this for initialization
    void Start ()
    {

        // set initial values:
        hunger = 0;

        // get the other components:
        hungry = GetComponent<Hungry>();
        tired = GetComponent<Tired>();
        happy = GetComponent<Happy>();


	}
	
	// Update is called once per frame
	void Update () {

        Assess();
        Act();
	}
    // this method assesses the bird's feelings and determines its state.
    public override void Assess()
    {
        if (feelings.Count == 0) // if the stack is empty
        {
            PushState(0);
        }
        else
        {
            if (hunger >= hungerThresh)
            {
                if (hunger >= energyThresh)
                {
                    PushState(1); //tired
                }
                else
                {
                    PushState(0); //hungry
                }

            }//end if
            else if (hunger < hungerThresh)
            {
                PushState(2); //happy
            }//end else if

        }//end else
        

    }

    // this method checks the state from the stack & calls the corresponding script.
    public override void Act()
    {
        switch (GetState())
        {
            case State.Hungry:
                {
                    hungry.Run();
                    break;
                }
            case State.Tired:
                {
                    tired.Run();
                    break;
                }
            case State.Happy:
                {
                    happy.Run();
                    break;
                }
        }//end switch

    }

    public override void Die()
    {
        
    }

    public override void PopState()
    {
        feelings.Pop();
    }

    public override void PushState(int state)
    {
        feelings.Push((State)state);
    }

    public State GetState()
    {
        return feelings.Peek();
    }
}
