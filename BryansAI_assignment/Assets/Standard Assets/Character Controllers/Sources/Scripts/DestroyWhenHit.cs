﻿using UnityEngine;
using System.Collections;
//this script call explosion when something hits its collider and also seeks nearest tagged enemy, script used by enemy torpedo.
public class DestroyWhenHit : MonoBehaviour 
{

	public Transform explosionPrefab;
	public float DestroyTimer = 6;
	GameObject[] gos;
	public GameObject closest;

	//float howfar;

	void Update()
	{
		DestroyTimer -= Time.deltaTime;

		if (DestroyTimer <= 1) 
		{
			Instantiate(explosionPrefab, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		FindClosestEnemy ();
		gameObject.GetComponent<SteeringBehaviours> ().seekPos = closest.transform.position;


		//Debug.Log (howfar);
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
		
		gos = GameObject.FindGameObjectsWithTag("Akir");
		
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