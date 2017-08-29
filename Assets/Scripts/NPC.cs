using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {
	Animator anim;
	public DialogueNode[] node;
	public int currentnode;
	public bool ShowDialogue = false;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	

	void Update () {
	
	}


	void OnGUI()
	{
		if (ShowDialogue == true)
		{
			GUI.Box (new Rect (Screen.width / 2 - 300, Screen.height - 300, 600, 250), "");
			GUI.Label (new Rect (Screen.width / 2 - 250, Screen.height - 250, 500, 90), node [currentnode].NpcText);
			for (int i = 0; i < node [currentnode].PlayerAnswer.Length; i++) 
			{
				if (GUI.Button (new Rect (Screen.width / 2 - 250, Screen.height - 200 + 25 * i, 500, 25), node [currentnode].PlayerAnswer [i].Text)) 
				{
					currentnode = node [currentnode].PlayerAnswer [i].ToNode;
					if (node [currentnode].PlayerAnswer [i].SpeakEnd)  
					{
						ShowDialogue = false;
					}
				}
			}
		}
	}


	[System.Serializable]
	public class DialogueNode 
	{
		public string NpcText;
		public Answer [] PlayerAnswer;
	}

	[System.Serializable]
	public class Answer
	{
		public string Text;
		public int ToNode;
		public bool SpeakEnd;

	}
}
