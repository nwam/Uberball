using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Logger : MonoBehaviour {

	public static void log(string message){
		print (DateTime.Now.ToString () + SceneManager.GetActiveScene ().name + ": " + message);
	}
}
