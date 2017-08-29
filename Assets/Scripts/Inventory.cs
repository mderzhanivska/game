using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {


	public List <Item> list;
	public GameObject inventory;
	public GameObject Char_W;
	public GameObject container;
	public GameObject player;
	public JoystickController PlayerJC;
	Animator anim;
	int Take = Animator.StringToHash ("Taking");

	public Text Coins;
	public int Gold=0;
	public Item Selected;
	public GameObject SelIt;
	public Transform WeapCel;


	void Start () 
	{
		anim = player.GetComponent<Animator> ();
		list = new List<Item> ();
		Coins = GameObject.Find("Coins").GetComponent<Text> ();
	}

	void Update () 
	{
		Coins.text= "" + Gold;
	}

	public void TakingItems()
	{
		anim.SetTrigger (Take);
		GameObject[] Its;
		Its = GameObject.FindGameObjectsWithTag ("Item");
		foreach (GameObject go in Its)
		{
			Item item = go.GetComponent<Item>();
			float distance = Vector3.Distance (player.transform.position, go.transform.position);
			if (distance < 3f) 
			{
				list.Add (item);
				plusCoins (item.price);
				Destroy (go,1f);
			} 
		}
	}

	public void Open_I()
	{

		if (Char_W.activeSelf)
		{
			Char_W.SetActive(false);
			for (int i = 0; i < inventory.transform.childCount; i++) 
			{
				if (inventory.transform.GetChild (i).transform.childCount > 0) 
				{
					Destroy (inventory.transform.GetChild (i).transform.GetChild (0).gameObject);
				}
			}
		}
		else 
		{
			Char_W.SetActive(true);
			int count = list.Count;
			for (int i = 0; i < count; i++) 
			{
				Item it = list [i];
				if (inventory.transform.childCount >= i) 
				{
					GameObject img = Instantiate (container);
					img.transform.SetParent (inventory.transform.GetChild (i).transform);
					img.GetComponent<Image> ().sprite = Resources.Load<Sprite>(it.sprite);
					img.AddComponent<Button> ().onClick.AddListener (() => chosen (it,img));
				}
				else break;

			}
		}
	}

	//Вибраний предмет
	public void chosen(Item it, GameObject img)
	{
		Selected = it;
		SelIt = img;
	}


	//Кнопки інвентаря
	public void Delete()
	{
		list.Remove (Selected);
		Destroy (SelIt);
	}
	public void Equip()
	{
		if (Selected.type == "Weapon") 
		{
			list.Remove (Selected);
			SelIt.transform.SetParent (WeapCel);
			EquipItem EqIt = Instantiate<GameObject> (Resources.Load<GameObject> (Selected.prefab)).GetComponent<EquipItem> ();
			player.GetComponent<JoystickController> ().EqWeapon (EqIt);
		}
	}



	public void plusCoins(int gold)
	{
		Gold += gold;
	}
	public void minusCoins(int gold){
		Gold -= gold;
	}


}