using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
//called by idle state on nearing enemy object
class AttackingState:State
{
    float timeShot = 0.25f;
    GameObject enemyGameObject;
	float closeRange = 50.0f;
	public GameObject GameManagerLink;

    //public override string Description()
    //{
        //return "Attacking State";
    //}

    public AttackingState(GameObject myGameObject, GameObject enemyGameObject):base(myGameObject)
    {
        this.enemyGameObject = enemyGameObject;
    }

    public override void Enter()
    {
		GameManagerLink = GameObject.Find ("GameManager");

		if (myGameObject != GameObject.Find ("Sador")) 
		{
			myGameObject.GetComponent<SteeringBehaviours> ().TurnOffAll ();
			myGameObject.GetComponent<SteeringBehaviours> ().OffsetPursuitEnabled = true;
			myGameObject.GetComponent<SteeringBehaviours> ().offsetPursuitOffset = new Vector3 (30, 10, 40);
			myGameObject.GetComponent<SteeringBehaviours> ().offsetPursueTarget = enemyGameObject;
		}

		if (myGameObject == GameObject.Find ("Sador")  && GameManagerLink.GetComponent<GameManager>().CowboyShipDead == false) 
		{
			myGameObject.GetComponent<SteeringBehaviours> ().TurnOffAll ();
			myGameObject.GetComponent<SteeringBehaviours> ().FollowPathEnabled = true;
			myGameObject.GetComponent<StateMachine>().ChangeState(new IdleState(myGameObject, enemyGameObject));
			//myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-431, 0, 325));
			//myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-805, 0, 8));
			//myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-380, 0, 8));
		}

		if (myGameObject == GameObject.Find ("Sador")  && GameManagerLink.GetComponent<GameManager>().CowboyShipDead == true) 
		{
			myGameObject.GetComponent<SteeringBehaviours> ().TurnOffAll ();
			myGameObject.GetComponent<SteeringBehaviours> ().FollowPathEnabled = true;
			myGameObject.GetComponent<StateMachine>().ChangeState(new IdleState(myGameObject, enemyGameObject));
			//myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-431, 0, 325));
			//myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-805, 0, 8));
			//myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-380, 0, 8));
		}

    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        float range = 100.0f;
        timeShot += Time.deltaTime;
        float fov = Mathf.PI / 4.0f;
        // Can I see the enemy?

		if ((enemyGameObject.transform.position - myGameObject.transform.position).magnitude > range)
        {
            myGameObject.GetComponent<StateMachine>().ChangeState(new IdleState(myGameObject, enemyGameObject));
        }
        else
        {
            float angle;
            Vector3 toEnemy = (enemyGameObject.transform.position - myGameObject.transform.position);
            toEnemy.Normalize();
            angle = (float) Math.Acos(Vector3.Dot(toEnemy, myGameObject.transform.forward));
            if (angle < fov)
            {
                if (timeShot > 0.25f)
                {
                    GameObject lazer = new GameObject();
                    lazer.AddComponent<Lazer>();
                    lazer.transform.position = myGameObject.transform.position;
                    lazer.transform.forward = myGameObject.transform.forward;
                    timeShot = 0.0f;
                }
            }
		}
		if (myGameObject != GameObject.Find ("Sador")) 
				{
						if ((enemyGameObject.transform.position - myGameObject.transform.position).magnitude < closeRange) 
						{
								myGameObject.GetComponent<SteeringBehaviours> ().EvadeEnabled = true;
								myGameObject.GetComponent<SteeringBehaviours> ().evadeTarget = enemyGameObject;
						}
				}


    }
}
