using UnityEngine;
using System.Collections;

public class DamageP : MonoBehaviour {
	public int damage = 5;
	void OnTriggerEnter (Collider coll)
	{
		if (coll.tag == "Player")
			coll.GetComponent<JoystickController> ().Health (damage);
	
	}
}