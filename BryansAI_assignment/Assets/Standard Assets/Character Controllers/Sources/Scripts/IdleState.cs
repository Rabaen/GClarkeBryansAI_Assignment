using System;
using System.Collections.Generic;
using UnityEngine;

public class IdleState:State
{
    static Vector3 initialPos = Vector3.zero;

    GameObject enemyGameObject;
	public GameObject Manager;

    //public override string Description()
    //{
        //return "Idle State";
    //}

    public IdleState(GameObject myGameObject, GameObject enemyGameObject)
        : base(myGameObject)
    {
        this.enemyGameObject = enemyGameObject;
		Manager = GameObject.Find ("GameManager");
    }

    public override void Enter()
    {	//starting patrols for ships

		if(myGameObject == GameObject.Find("Sador") && Manager.GetComponent<GameManager>().CowboyShipDead == true)
		{
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(620, 0, -180));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(680, 20, -275));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(615, -15, -240));
			
		}

		if(myGameObject == GameObject.Find("Sador") && Manager.GetComponent<GameManager>().NestorShipDead == false)
		{
				myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-431, 0, 325));
				myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-805, 0, 8));
				myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-380, 0, 8));
				//myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(25, 0, -10));

		}

		if(myGameObject == GameObject.Find("Sador") && Manager.GetComponent<GameManager>().NestorShipDead == true  && Manager.GetComponent<GameManager>().CowboyShipDead == false)
		{
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(700, 30, -400));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(800, 30, -400));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(750, 30, -300));
			
		}



		if(myGameObject == GameObject.Find("NellShip"))
		{
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(620, 0, -180));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(680, 20, -275));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(615, -15, -240));
		}

		if(myGameObject == GameObject.Find("Cowboy"))
		{
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(600, 30, -200));
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(700, 0, -250));
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(640, 15, -268));
			
		}

		//if(myGameObject == GameObject.Find("GirlShip1"))
		//{
			//myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(500, -50, -500));
			//myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(300,100, -300));
			//myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(500, 50, -100));
			//myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(700, -100, -300));
			
		//}

		if(myGameObject == GameObject.Find("GeltShip")  && Manager.GetComponent<GameManager>().ChadShipDead == false)
		{
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-380, 0, -140));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-431, 0, 325));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-805, 0, 8));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-380, 0, 8));
			
		}

		if(myGameObject == GameObject.Find("ValkyrShip")  && Manager.GetComponent<GameManager>().ValkyrShipDead == false)
		{
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-451,20, 305));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-825, -20, 18));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-360, 20, 18));
			
		}

		if(myGameObject == GameObject.Find("NestorShip")  && Manager.GetComponent<GameManager>().NestorShipDead == false)
		{
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-300, -50, -100));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-400,0, -2));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-805, 0, 8));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-350, -100, 110));
			
		}

		if(myGameObject == GameObject.Find("KaymonShip1")  && Manager.GetComponent<GameManager>().KaymanShipDead == false)
		{
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-10, 0, -90));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-431, 0, 325));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-805, 0, 8));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-380, 0, 8));
			
		}

		if(myGameObject == GameObject.Find("FighterLead"))
		{
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(650,30, -200));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(660, 15, -250));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(615, -10, -245));
			
		}

		//new waypoint routes for ships after ships start dying

		if(myGameObject == GameObject.Find("GeltShip")  && Manager.GetComponent<GameManager>().ChadShipDead == true)
		{
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(500, -50, -500));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(300,100, -300));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(500, 50, -100));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(700, -100, -300));
			
		}

		/*if(myGameObject == GameObject.Find("NestorShip")  && Manager.GetComponent<GameManager>().NestorShipDead == true)
		{
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(500, -50, -500));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(500,100, 175));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(500, 50, -100));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(700, -100, -300));
			
		}*/
		
		/*if(myGameObject == GameObject.Find("KaymanShip1")  && Manager.GetComponent<GameManager>().KaymanShipDead == true)
		{
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(500, -50, -500));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(300,100, -300));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(500, 50, -100));
			myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(700, -100, -300));
			
		}*/

		//all ships follow waypoint path until enemy in range


		myGameObject.GetComponent<SteeringBehaviours>().path.Looped = true;            
		myGameObject.GetComponent<SteeringBehaviours>().path.draw = true;
		myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
		myGameObject.GetComponent<SteeringBehaviours>().FollowPathEnabled = true;
    }
    public override void Exit()
    {
        myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Clear();
    }

    public override void Update()
    {
				float range = 100.0f;           
				// Can I see the enemy?
				if ((enemyGameObject.transform.position - myGameObject.transform.position).magnitude < range) {
						// Is the leader inside my FOV
						myGameObject.GetComponent<StateMachine> ().ChangeState (new AttackingState (myGameObject, enemyGameObject));
				}

	}
}
