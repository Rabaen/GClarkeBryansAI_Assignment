using UnityEngine;
using System.Collections;
//This script attached to camera and called by events in camera animation
public class CameraEvents : MonoBehaviour 
{
	public GUITexture PilotImage;

	public bool ValkyrAttack = false;  //bools to activate images on screen
	public bool GeltAttack = false;
	public bool KaymanAttack = false;
	public bool NestorAttack = false;
	public bool CowboyAttack = false;
	public bool ChadAttack = false;
	public bool SadorAttack = false;
	public bool SadorDeathBool = false;

	public bool TheEndBool = false;

	public bool TextureOn = false;

	public Texture2D Valkyr;  //stores images
	public Texture2D Gelt;
	public Texture2D Kayman;
	public Texture2D Nestor;
	public Texture2D Cowboy;
	public Texture2D Chad;
	public Texture2D Sador;

	public Texture2D defaultBlank;  //default to blank image
	//public Texture2D Valkyr;
	public float DestroyTimer = 5;  //time image is on screen
	public GameObject GameManagerCamLink;

	public Vector3 offSet = new Vector3 (-10, 20, -10);  //offset for explosion
	public GUIText title3;  //stores End text
	//audio slots

	public AudioClip ValkyrAudio;  //stores audio to be played with images
	public AudioClip GeltAudio;
	public AudioClip KaymonAudio;
	public AudioClip NestorAudio;
	public AudioClip CowboyAudio;
	public AudioClip ChadAudio;
	public AudioClip SadorAudio;
	public AudioClip Kaymon2Audio;
	public AudioClip SadorDeath;

	public Transform explosionPrefab;  //explosion store
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (TextureOn == true) 
		{
			DestroyTimer -= Time.deltaTime;
		}

		if (DestroyTimer <= 0)   //turn off images when timer runs out
		{
			PilotImage.guiTexture.texture = defaultBlank;
			DestroyTimer = 5;
			TextureOn = false;
			ValkyrAttack = false;
			GeltAttack = false;
			KaymanAttack = false;
			NestorAttack = false;
			CowboyAttack = false;
			ChadAttack = false;
			SadorAttack = false;
			SadorDeathBool = false;
		}

		if(KaymanAttack == true && DestroyTimer < 1) //play kaymon second audtion when first is over
		{
			audio.clip = Kaymon2Audio;
			audio.Play();
		}
	}

	void OnGUI()  //display images on gui
	{
		if (ValkyrAttack == true && TextureOn == true) 
		{
			PilotImage.guiTexture.texture = Valkyr; 

		}

		if (GeltAttack == true && TextureOn == true) 
		{
			PilotImage.guiTexture.texture = Gelt; 
		}

		if (KaymanAttack == true && TextureOn == true) 
		{
			PilotImage.guiTexture.texture = Kayman; 
		}

		if (NestorAttack == true && TextureOn == true) 
		{
			PilotImage.guiTexture.texture = Nestor; 
		}

		if (CowboyAttack == true && TextureOn == true) 
		{
			PilotImage.guiTexture.texture = Cowboy; 
		}

		if (ChadAttack == true && TextureOn == true) 
		{
			PilotImage.guiTexture.texture = Chad; 
		}

		if (SadorAttack == true && TextureOn == true) 
		{
			PilotImage.guiTexture.texture = Sador; 
		}

		if (SadorDeathBool == true && TextureOn == true) 
		{
			PilotImage.guiTexture.texture = Sador; 
		}

		if (TheEndBool == true) 
		{
			title3.guiText.text = "The End";
		}
	}

	void ValkyrGo()  //methods to call images and audio, activated in Camera Animation events
	{
		ValkyrAttack = true;
		TextureOn = true;
		audio.clip = ValkyrAudio;
		audio.Play();
	}

	void GeltGo()
	{
			GeltAttack = true;
			TextureOn = true;
		audio.clip = GeltAudio;
		audio.Play();
	}

	void KaymanGo()
	{
			KaymanAttack = true;
			TextureOn = true;
		audio.clip = KaymonAudio;
		audio.Play();
	}

	void NestorGo()
	{
			NestorAttack = true;
			TextureOn = true;
		audio.clip = NestorAudio;
		audio.Play();
	}

	void CowboyGo()
	{
			GameObject cowboy1 = GameObject.Find ("Cowboy");
			cowboy1.GetComponent<DestroySelf>().enabled = true;
			cowboy1.GetComponent<DestroySelf>().HealthCount = 10;
			CowboyAttack = true;
			TextureOn = true;
			audio.clip = CowboyAudio;
			audio.Play();
	}


	void ChadGo()
	{
			ChadAttack = true;
			TextureOn = true;
		audio.clip = ChadAudio;
		audio.Play();
	}

	void SadorGo()
	{
			SadorAttack = true;
			TextureOn = true;
		audio.clip = SadorAudio;
		audio.Play();
	}

	void KillFighters()
	{	

		GameObject die = GameObject.Find ("FighterLead");
		Instantiate (explosionPrefab, die.transform.position, die.transform.rotation);
		Instantiate (explosionPrefab, die.transform.position, die.transform.rotation);
		Destroy (die);
		GameObject cowboy2 = GameObject.Find ("Cowboy");
		Instantiate (explosionPrefab, cowboy2.transform.position, cowboy2.transform.rotation);
		Instantiate (explosionPrefab, cowboy2.transform.position, cowboy2.transform.rotation);
		Destroy (cowboy2);
		GameManagerCamLink.GetComponent<GameManager> ().CowboyShipDead = true;
	}

	void SadorDeathGo1()
	{
				SadorDeathBool = true;
				TextureOn = true;
				audio.clip = SadorDeath;
				audio.Play ();
	}


	void SadorDeathGo()
	{
		DestroyTimer = 10;
		GameObject Sador = GameObject.Find ("Sador");
		Instantiate (explosionPrefab, Sador.transform.position, Sador.transform.rotation);
		Sador.GetComponent<SteeringBehaviours> ().maxSpeed = 5;
		GameObject Nell = GameObject.Find ("NellShip");
		Instantiate (explosionPrefab, Nell.transform.position, Nell.transform.rotation);
		GameManagerCamLink.GetComponent<GameManager> ().NellShipDead = true;
		Destroy (Nell);
		Destroy (Sador);

	}

	void Explode()
	{
		GameObject Sador = GameObject.Find ("Sador");
		Instantiate (explosionPrefab, Sador.transform.position, Sador.transform.rotation);
		Instantiate (explosionPrefab, Sador.transform.position + offSet + offSet, Sador.transform.rotation);
		Instantiate (explosionPrefab, Sador.transform.position + offSet, Sador.transform.rotation);
		Instantiate (explosionPrefab, Sador.transform.position + offSet - offSet, Sador.transform.rotation);
		Instantiate (explosionPrefab, Sador.transform.position - offSet, Sador.transform.rotation);
	}

	void TheEnd()
	{
		TheEndBool = true;
	}
}
