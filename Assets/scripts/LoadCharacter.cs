using UnityEngine;
using System.Collections;

public class LoadCharacter : Singleton<LoadCharacter> {
	private const string SELECTED_CHARACTER = "character"; //sketchy? yes, TODO: factor out into character selection

	private const string CHARACTER_MATERIALS_PATH = "ball/";
	private const string CHARACTER_THUMBS_PATH = "ball/thumbs/";
	private const string CHARACTER_THUMBS_SUFFIX = "_thumb";

	private const string DEFAULT_CHARACTER = "null";

	private string characterName;

	void Start () {
		characterName = PlayerPrefs.HasKey(SELECTED_CHARACTER) ? PlayerPrefs.GetString (SELECTED_CHARACTER) : DEFAULT_CHARACTER;
		Material selectedCharacterMaterial = (Material) Resources.Load (CHARACTER_MATERIALS_PATH + characterName);
		GetComponent<Renderer>().material = selectedCharacterMaterial;
	}

	public string getCharacterName(){
		return characterName;
	}

	public Texture getCurrentCharacterThumbnail(){
		return getCharacterThumbnail (characterName);
	}

	public static Texture getCharacterThumbnail(string characterName){
		return (Texture)Resources.Load (CHARACTER_THUMBS_PATH + characterName + CHARACTER_THUMBS_SUFFIX);
	}

}
