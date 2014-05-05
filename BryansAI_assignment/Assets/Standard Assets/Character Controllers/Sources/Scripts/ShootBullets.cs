using UnityEngine;
using System.Collections;

public class ShootBullets : MonoBehaviour 

{

//properties go here
	public Vector3 size = new Vector3(0.25f,0.25f,0.25f);
	public float Speed = 300;  //how fast the bullet moves
	public Rigidbody Projectile; //what he shoots, Note; must be set in Unity
	public Transform muzzlePoint; //location of object he shoots from...gun
	public Transform muzzlePoint2; //location of object he shoots from...gun
	public float Stimer = 8;
	
	// Update is called once per frame
	void Update () 
	{
		Stimer -= Time.deltaTime;
		if (Stimer <= 1)
		{
			Shoot ();
			Stimer = 8;
		}

		if (Stimer >= 4  && Stimer <= 5)
		{
			Shoot2 ();
			Stimer = 4;
		}
	
	}
	
	void Shoot()
		
	{
			//creates projectiles
			
			Rigidbody pewpew; 
			pewpew = Instantiate (Projectile, muzzlePoint.position, muzzlePoint.rotation) as Rigidbody;
			pewpew.velocity = muzzlePoint.forward * Time.deltaTime * Speed;
			pewpew.transform.localScale = size;
			pewpew.GetComponent<SteeringBehaviours> ().maxSpeed = 28;
	}

	
	void Shoot2()
		
		{
			Rigidbody pewpew2; 
			pewpew2 = Instantiate(Projectile, muzzlePoint2.position, muzzlePoint2.rotation) as Rigidbody;
			pewpew2.velocity = muzzlePoint2.forward * Time.deltaTime * Speed;
			pewpew2.transform.localScale = size;
			pewpew2.GetComponent<SteeringBehaviours> ().maxSpeed = 20;
		}



}
