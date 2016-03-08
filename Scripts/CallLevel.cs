using UnityEngine;
using System.Collections;

public class CallLevel : MonoBehaviour {

	public void NextLevelButton(int index)
		{
			Application.LoadLevel(index);
		}
		
		public void NextLevelButton(string levelName)
		{
			Application.LoadLevel("Level_1");
		}
}
