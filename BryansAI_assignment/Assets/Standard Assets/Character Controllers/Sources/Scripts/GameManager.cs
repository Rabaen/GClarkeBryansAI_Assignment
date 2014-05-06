using UnityEngine;
using System.Collections;
//this script manages various game events, setting ships speeds for timing of runs mainly
public class GameManager : MonoBehaviour {

	public GameObject Sador;
	public GameObject Nell;
	public GameObject Gelt;
	public GameObject Cowboy;
	public GameObject Valkyr;
	public GameObject Nestor;
	public GameObject Kayman;
	public GameObject Girl;
	public GameObject Fighter;

	public GameObject Planet;


	//shipdeath bools
	public bool ValkyrShipDead = false;
	public bool NestorShipDead = false;
	public bool ChadShipDead = false;
	public bool CowboyShipDead = false;
	public bool KaymanShipDead = false;
	public bool NellShipDead = false;
	public bool FighterDead = false;

	// Use this for initialization
	void Start () 
	{
        //GameObject leader = GameObject.FindGameObjectWithTag("leader");
        //GameObject teaser = GameObject.FindGameObjectWithTag("teaser");

        //leader.GetComponent<StateMachine>().SwicthState(new IdleState(leader, teaser));
        //teaser.GetComponent<StateMachine>().SwicthState(new TeaseState(teaser, leader));

        //leader.renderer.material.color = Color.red;
        //teaser.renderer.material.color = Color.blue;

		Sador.GetComponent<StateMachine> ().ChangeState (new IdleState (Sador, Valkyr));
		Sador.GetComponent<SteeringBehaviours> ().maxSpeed = 5;

		//Nell.GetComponent<StateMachine> ().ChangeState (new IdleState (Nell, Sador));
		Nell.GetComponent<SteeringBehaviours> ().maxSpeed = 10;

		//Cowboy.GetComponent<StateMachine> ().ChangeState (new IdleState (Cowboy, Fighter));
		Cowboy.GetComponent<SteeringBehaviours> ().maxSpeed = 10;

		//Girl.GetComponent<StateMachine> ().ChangeState (new IdleState (Girl, Fighter));
		//Girl.GetComponent<SteeringBehaviours> ().maxSpeed = 8;


		Valkyr.GetComponent<StateMachine> ().ChangeState (new IdleState (Valkyr, Sador));
		Valkyr.GetComponent<SteeringBehaviours> ().maxSpeed = 7;


		Gelt.GetComponent<StateMachine> ().ChangeState (new IdleState (Gelt, Sador));
		Gelt.GetComponent<SteeringBehaviours> ().maxSpeed = 12;


		Nestor.GetComponent<StateMachine> ().ChangeState (new IdleState (Nestor, Sador));
		Nestor.GetComponent<SteeringBehaviours> ().maxSpeed = 14;

		Kayman.GetComponent<StateMachine> ().ChangeState (new IdleState (Kayman, Sador));
		Kayman.GetComponent<SteeringBehaviours> ().maxSpeed = 7.5f;

		Fighter.GetComponent<StateMachine> ().ChangeState (new IdleState (Fighter, Cowboy));
		Fighter.GetComponent<SteeringBehaviours> ().maxSpeed = 10;


	
		Nell.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(620, 0, -180));
		Nell.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(680, 20, -275));
		Nell.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(615, -15, -240));
		Nell.GetComponent<SteeringBehaviours>().path.Looped = true;            
		Nell.GetComponent<SteeringBehaviours>().path.draw = true;
		Nell.GetComponent<SteeringBehaviours>().TurnOffAll();
		Nell.GetComponent<SteeringBehaviours>().FollowPathEnabled = true;
			
		Cowboy.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(600, 30, -200));
		Cowboy.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(700, 0, -250));
		Cowboy.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(640, 15, -268));
		Cowboy.GetComponent<SteeringBehaviours>().path.Looped = true;            
		Cowboy.GetComponent<SteeringBehaviours>().path.draw = true;
		Cowboy.GetComponent<SteeringBehaviours>().TurnOffAll();
		Cowboy.GetComponent<SteeringBehaviours>().FollowPathEnabled = true;

	}
	
	// Update is called once per frame
	void Update () 
	{
		//call image and audio as ships attack sador




		///switch Sador state as ships die
		if (ValkyrShipDead == true  && ChadShipDead == false) 
		{
			Sador.GetComponent<StateMachine> ().ChangeState (new IdleState (Sador, Gelt));
		}

		if (ChadShipDead == true  && KaymanShipDead == false) 
		{
			Sador.GetComponent<StateMachine> ().ChangeState (new IdleState (Sador, Kayman));
		}

		if (KaymanShipDead == true  && NestorShipDead == false) 
		{
			Sador.GetComponent<StateMachine> ().ChangeState (new IdleState (Sador, Nestor));
		}

		if (NestorShipDead == true  && CowboyShipDead == false) 
		{
			//Sador.GetComponent<StateMachine> ().ChangeState (new IdleState (Sador, Cowboy));
			Sador.GetComponent<StateMachine> ().ChangeState (new IdleState (Sador, Nell));
			Sador.GetComponent<SteeringBehaviours> ().maxSpeed = 17;
		}

		if (CowboyShipDead == true  && NellShipDead == false) 
		{
			Sador.GetComponent<StateMachine> ().ChangeState (new IdleState (Sador, Girl));
			//Fighter.GetComponent<StateMachine> ().ChangeState (new IdleState (Fighter, Nell));
			//Nell.GetComponent<StateMachine> ().ChangeState (new IdleState (Nell, Sador));
			Nell.GetComponent<SteeringBehaviours>().FollowPathEnabled = false;
			Nell.GetComponent<SteeringBehaviours>().SeekEnabled = true;
			Nell.GetComponent<SteeringBehaviours>().seekPos = Sador.transform.position;
			Nell.GetComponent<SteeringBehaviours> ().maxSpeed = 15;
		}

		if (NellShipDead == true) 
		{

			//Fighter.GetComponent<StateMachine> ().ChangeState (new IdleState (Fighter, Nell));
			//Nell.GetComponent<StateMachine> ().ChangeState (new IdleState (Nell, Sador));
			Girl.GetComponent<SteeringBehaviours>().OffsetPursuitEnabled = false;
			Girl.GetComponent<SteeringBehaviours>().SeekEnabled = true;
			Girl.GetComponent<SteeringBehaviours>().seekPos = Planet.transform.position;
			Girl.GetComponent<SteeringBehaviours> ().maxSpeed = 20;
		}


	}
}
