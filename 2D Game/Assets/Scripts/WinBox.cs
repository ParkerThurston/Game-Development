using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBox : MonoBehaviour {

	 void OnTriggerEnter2D (Collider2D other) {
		
		if(other.name== "PC"){
			SceneManager.LoadScene(2);
		}
	 }
}