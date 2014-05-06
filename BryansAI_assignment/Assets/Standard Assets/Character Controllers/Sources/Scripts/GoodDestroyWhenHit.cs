using UnityEngine;
using System.Collections;
//this script used by good guy torpedo to track nearest enemy and destroy self on collision or after set time.
public class GoodDestroyWhenHit : MonoBehaviour 
{
	
	public Transform explosionPrefab;
	public float DestroyTimer = 5;
	GameObject[] gos;
	public GameObject closest;
	
	//float howfar;
	
	void Update()
	{

		FindClosestEnemy ();

		DestroyTimer -= Time.deltaTime;
		
		if (DestroyTimer <= 1) 
		{
			Instantiate(explosionPrefab, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		gameObject.GetComponent<SteeringBehaviours> ().seekPos = closest.transform.position;
		//Debug.Log (howfar);

		if (closest = null) 
		{
			gameObject.GetComponent<SteeringBehaviours> ().seekPos = this.gameObject.transform.position;
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
		Destroy(gameObject);
	}
	
	GameObject FindClosestEnemy() 
	{
		
		gos = GameObject.FindGameObjectsWithTag("Sador");
		
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) 
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) 
			{
				closest = go;
				distance = curDistance;
				//howfar = curDistance;
			}
		}
		return closest;
	}
}