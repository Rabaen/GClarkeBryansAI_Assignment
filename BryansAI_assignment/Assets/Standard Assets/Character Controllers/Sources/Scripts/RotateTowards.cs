using UnityEngine;
using System.Collections;

public class RotateTowards : MonoBehaviour 
{
	//public GameObject target;
	// Use this for initialization
	public float TurretRotationSpeed = 0.2f;
	public bool HaveTarget = false;
	public Transform Target;
	public float Stimer;
	//private Quaternion flip = (0,180,0);
	private Vector3 RotateToTarget;
	//public float rotateSpeed = 45;
	GameObject[] gos;
	GameObject closest;

	void Awake() 
	{
		//PlayerCamera = GameObject.Find("PlayerCamera");
		Target = gameObject.transform;
	}
	
	void Update () 
	{
		//Target = GameObject.FindGameObjectWithTag ("Akir");
		Stimer -= Time.deltaTime;
		if (Stimer <= 1)
		{
			Target = FindClosestEnemy ().transform;
			Stimer = 8;
		}

		Target = FindClosestEnemy ().transform;


		//Target = FindClosestEnemy ().transform;
		
		Quaternion newRotation = Quaternion.LookRotation(transform.position - Target.position);
		transform.localEulerAngles = new Vector3(270, transform.localEulerAngles.y, 0);
		newRotation *= Quaternion.Euler(0,90,0);
		//newRotation.z = 0.0;
		//newRotation.x = 0.0;
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
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
				}
			}
			return closest;
		}

}
