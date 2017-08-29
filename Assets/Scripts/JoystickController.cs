using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;

public class JoystickController : MonoBehaviour 
{
	Animator anim;
	NavMeshAgent navi;
	public Slider slider;
	public int health=100;

	int Fight = Animator.StringToHash ("Bite");

	public float moveSpeed = 5f;
	public float terminalRotationSpeed = 25f;
	public VirtualJoystick moveJoystick;

	private CharacterController controller;

	public Transform R_Hand;


	private void Start()
	{
		anim = GetComponent<Animator> ();
		controller = GetComponent <CharacterController> ();
		navi = GetComponent<NavMeshAgent> ();

	}

	private void Update()
	{
		//Ходити
		Vector3 dir = Vector3.zero;

		if (moveJoystick.InputDirection != Vector3.zero)
		{
			dir = moveJoystick.InputDirection;
			transform.forward = Vector3.Normalize (moveJoystick.InputDirection);
			if (dir != Vector3.zero)
			{
				anim.SetBool ("Runing", true);
			} 
		} 
		else 
		{
			anim.SetBool ("Runing", false);
		}
			
		controller.Move (dir * moveSpeed * Time.deltaTime);
	}

	//ХП,Шкода
	public void Health(int dmg) 
	{
			health -= dmg;
			slider.value = health;
			if (health <= 0)
				anim.SetBool ("Kill", true);
	}
		
	//Говорити,Бити
	public void TalknBite ()
	{
		Debug.DrawRay (transform.position + Vector3.up, transform.forward * 2f, Color.cyan);
		RaycastHit info;
		if (Physics.Raycast (transform.position + transform.up, transform.forward, out info, 2f))
		{
			if (info.collider.tag == "NPC")
			{
				info.collider.GetComponent<NPC> ().ShowDialogue = true;
			} 
			else 
			{
				anim.SetTrigger (Fight);
			}
		}
	}

	//Зброя(взяти в руку)
	public void EqWeapon(EquipItem EqIt)
	{
		EqIt.transform.SetParent (R_Hand);
		EqIt.transform.localPosition = EqIt.position;
		EqIt.transform.localRotation = Quaternion.Euler (EqIt.rotation);
		Destroy (EqIt.GetComponent<Rigidbody> ());
		EqIt.GetComponent<BoxCollider> ().isTrigger = true;
		EqIt.gameObject.AddComponent<DamageE> ();
	}
}