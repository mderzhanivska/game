using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Item : MonoBehaviour {

	public string type;
	public string sprite;
	public string prefab;
	public int price;
	public void Update(){
		price = Random.Range (0, 10);
	}
}
