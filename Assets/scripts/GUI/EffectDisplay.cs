using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EffectDisplay : Singleton<EffectDisplay> {
	private const int MAX_TIME_DISPLAY = 99999;

	public enum EffectType {bounce, heavy, magnet, shape, space, xctrl};

	private Texture[] storedIcons;
	public Texture bounceIcon;
	public Texture heavyIcon;
	public Texture magnetIcon;
	public Texture shapeIcon;
	public Texture spaceIcon;
	public Texture xctrlIcon;

	public Texture blankTexture;

	private Text[] times;
	private RawImage[] icons;

	private int currentIndex;
	private int highestIndexOnDisplay;

	// Use this for initialization
	void Start () {
		times = transform.GetComponentsInChildren<Text> ();
		icons = transform.GetComponentsInChildren<RawImage> ();
		currentIndex = -1;
		highestIndexOnDisplay = -1;

		storedIcons = new Texture[6] {
			bounceIcon,
			heavyIcon,
			magnetIcon,
			shapeIcon,
			spaceIcon,
			xctrlIcon
		};
	}



	void LateUpdate(){
		if (highestIndexOnDisplay > currentIndex) {
			for (int i = highestIndexOnDisplay; i > currentIndex; i--) {
				takeDownEffect (i);
			}
		}
		highestIndexOnDisplay = currentIndex;
		currentIndex = -1;
	}
		


	public void addEffect (EffectType type, int timeRemaining){
		currentIndex += 1;
		icons [currentIndex].texture = storedIcons [(int)type];
		times [currentIndex].text = timeRemaining > MAX_TIME_DISPLAY ? "\u221E" : timeRemaining.ToString();
	}



	private void takeDownEffect(int i){
		icons [i].texture = blankTexture;
		times [i].text = "";
	}
}
