using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour 
{
	Animator anim;
	NavMeshAgent navi;
	GameObject player;
	int Fight = Animator.StringToHash ("Bite");
	public float vision = 10;
	public int health = 100;
	public Slider slider;
	public GameObject Slider;
	public GameObject Pouch;
	Collider coll;

	void Start () 
	{
		anim = GetComponent<Animator> ();
		navi = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}


	public void Health(int dmg) 
	{
		health -= dmg;
		slider.value = health;
		if (health == 0)
		{
			anim.SetBool ("Kill", true);

			Destroy (this);
			Instantiate (Pouch).transform.position = transform.position;
			Destroy (gameObject,10f);
		}
	}

	void Update () 
	{
	
		if (player != null) 
		{

			float distance = Vector3.Distance (transform.position, player.transform.position);
			if (distance < 3f) 
			{
				Slider.SetActive (true);
				anim.SetTrigger (Fight);

			} 
			else if (distance < vision) 
			{
				Slider.SetActive (false);
				navi.destination = player.transform.position;
			} 

		}


		if (navi.velocity.magnitude > 2f) 
		{
			anim.SetBool ("Runing", true);
		} 
		else 
		{
			anim.SetBool ("Runing", false);
		}
	}
}