using UnityEngine;
using System.Collections;

public class DamageE : MonoBehaviour {
	public int damage = 10;
	void OnTriggerEnter (Collider coll)
	{

		if (coll.tag=="Enemy")
			coll.GetComponent<Enemy>().Health (damage);
	}
}