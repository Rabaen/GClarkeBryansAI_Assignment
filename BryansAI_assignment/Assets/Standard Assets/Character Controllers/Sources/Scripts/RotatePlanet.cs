using UnityEngine;
using System.Collections;

public class RotatePlanet : MonoBehaviour 
{

		
		public float RotationSpeed = 1f;
		
		void Update () 
		{
			transform.Rotate(transform.up, RotationSpeed * Time.deltaTime, Space.World);
		}
}
