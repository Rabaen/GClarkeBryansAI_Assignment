using UnityEngine;
using System.Collections;
//this script used by ships to destroy themselves when damaged to 0 health, call explosion and set bool in gamemanager
public class DestroySelf : MonoBehaviour 
	{
		
		public Transform explosionPrefab;
		public float DestroyTimer = 10;
		public float HealthCount = 10;
		public GameObject GameManager;

		void Start()
		{

		}
		
		void Update()
		{
			//DestroyTimer -= Time.deltaTime;
			
			if (HealthCount <= 0) 
			{
			if(this.gameObject == GameObject.Find("ValkyrShip"))
			   	{
				GameManager.GetComponent<GameManager>().ValkyrShipDead = true;
				}
			if(this.gameObject == GameObject.Find("GeltShip"))
			{
				GameManager.GetComponent<GameManager>().ChadShipDead = true;
			}
			if(this.gameObject == GameObject.Find("KaymonShip1"))
			{
				GameManager.GetComponent<GameManager>().KaymanShipDead = true;
			}
			if(this.gameObject == GameObject.Find("NestorShip"))
			{
				GameManager.GetComponent<GameManager>().NestorShipDead = true;
			}
			if(this.gameObject == GameObject.Find("Cowboy"))
			{
				GameManager.GetComponent<GameManager>().CowboyShipDead = true;
			}
			if(this.gameObject == GameObject.Find("FighterLead"))
			{
				GameManager.GetComponent<GameManager>().FighterDead = true;
			}

				Instantiate(explosionPrefab, transform.position, transform.rotation);
				Destroy (gameObject);
				
			}
		}
		
		void OnCollisionEnter(Collision collision) 
		{
			
			//foreach (ContactPoint hit in collision.contacts) 
			//{
			//    Debug.DrawRay(hit.point, hit.normal, Color.white);
			//}
			
			
			ContactPoint contact = collision.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			Instantiate(explosionPrefab, pos, rot);
			HealthCount --;
		}
	}