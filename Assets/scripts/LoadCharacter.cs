using UnityEngine;
using System.Collections;

public class LoadCharacter : MonoBehaviour {
	private const string SELECTED_CHARACTER = "character"; //sketchy

	void Start () {
		string selectedCharacterPath = PlayerPrefs.HasKey(SELECTED_CHARACTER) ? PlayerPrefs.GetString (SELECTED_CHARACTER) : "ball/null";
		Material selectedCharacterMaterial = (Material) Resources.Load (selectedCharacterPath);
		GetComponent<Renderer>().material = selectedCharacterMaterial;
	}

}
