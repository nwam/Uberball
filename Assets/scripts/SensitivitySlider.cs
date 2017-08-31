using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : Sensitivity {
	private const string SLIDER_TEXT_PREFIX = "sensitivity ";

	public Slider slider;
	public Text sliderText;

	// Use this for initialization
	void Start () {

		slider.onValueChanged.AddListener (delegate {
			updateSensitivity ();
		});

		float sensitivity = getSensitivity ();
		setSliderText (sensitivity);
		slider.value = sensitivity;
	}

	private void updateSensitivity(){
		// convert slider value to sensitivity value
		float sensitivity = slider.value;

		// update display
		setSliderText(sensitivity);

		// update playerprefs and current sensitivity
		setSensitivity(sensitivity);
	}



	private void setSliderText(float sensitivity){
		sliderText.text = SLIDER_TEXT_PREFIX + ((int)sensitivity).ToString ();
	}

	/*
	private float sliderToSensitivity(float x){
		return x;

		// it appears to be much nicer with a linear scale :'(
		//return Mathf.Pow(SLIDER_SCALE, x * Mathf.Log(MAX_SENSITIVITY-MIN_SENSITIVITY)/Mathf.Log(SLIDER_SCALE)) 
		//	+ MIN_SENSITIVITY;
	}
		
	private float sensitivityToSlider(float y){
		return y;
	}
	*/

}
