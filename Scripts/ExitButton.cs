using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour {
	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape) == true)
		{
			Application.Quit();
		}
	}

}
