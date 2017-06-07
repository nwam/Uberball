using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighscoreTable : MonoBehaviour {

	private const string HS_PREFIX = "hs"; //sketchy, this is also in HighscoreManager
	private const string TITLE_WIN_TEXT = "NEW HIGHSCORE!";

	private GameObject title;
	private GameObject score1;
	private GameObject score2;
	private GameObject score3;
	private GameObject score4;
	private GameObject score5;

	private GameObject text1;
	private GameObject text2;
	private GameObject text3;
	private GameObject text4;
	private GameObject text5;

	private GameObject thumb1;
	private GameObject thumb2;
	private GameObject thumb3;
	private GameObject thumb4;
	private GameObject thumb5;

	private GameObject panel1;
	private GameObject panel2;
	private GameObject panel3;
	private GameObject panel4;
	private GameObject panel5;

	private Image darken;

	void Start() {
		darken = GameObject.Find ("Canvas/Darken").GetComponent<Image> ();
		title = transform.FindDeepChild ("title").gameObject;
		score1 = transform.FindDeepChild ("score1").gameObject;
		score2 = transform.FindDeepChild ("score2").gameObject;
		score3 = transform.FindDeepChild ("score3").gameObject;
		score4 = transform.FindDeepChild ("score4").gameObject;
		score5 = transform.FindDeepChild ("score5").gameObject;
		text1 = transform.FindDeepChild ("1").gameObject;
		text2 = transform.FindDeepChild ("2").gameObject;
		text3 = transform.FindDeepChild ("3").gameObject;
		text4 = transform.FindDeepChild ("4").gameObject;
		text5 = transform.FindDeepChild ("5").gameObject;
		thumb1 = transform.FindDeepChild ("thumb1").gameObject;
		thumb2 = transform.FindDeepChild ("thumb2").gameObject;
		thumb3 = transform.FindDeepChild ("thumb3").gameObject;
		thumb4 = transform.FindDeepChild ("thumb4").gameObject;
		thumb5 = transform.FindDeepChild ("thumb5").gameObject;
		panel1 = transform.Find ("panel1").gameObject;
		panel2 = transform.Find ("panel2").gameObject;
		panel3 = transform.Find ("panel3").gameObject;
		panel4 = transform.Find ("panel4").gameObject;
		panel5 = transform.Find ("panel5").gameObject;
	}


	// sets the text of the highscore table based on the highscores
	public void setScores(){
		score1.GetComponent<Text>().text = HighscoreManager.Instance.getHighscore(1).ToString().PadLeft(7,' ');
		score2.GetComponent<Text>().text = HighscoreManager.Instance.getHighscore(2).ToString().PadLeft(7,' ');
		score3.GetComponent<Text>().text = HighscoreManager.Instance.getHighscore(3).ToString().PadLeft(7,' ');
		score4.GetComponent<Text>().text = HighscoreManager.Instance.getHighscore(4).ToString().PadLeft(7,' ');
		score5.GetComponent<Text>().text = HighscoreManager.Instance.getHighscore(5).ToString().PadLeft(7,' ');

		thumb1.GetComponent<RawImage>().texture = HighscoreManager.Instance.getHighscoreThumbnail (1);
		thumb2.GetComponent<RawImage>().texture = HighscoreManager.Instance.getHighscoreThumbnail (2);
		thumb3.GetComponent<RawImage>().texture = HighscoreManager.Instance.getHighscoreThumbnail (3);
		thumb4.GetComponent<RawImage>().texture = HighscoreManager.Instance.getHighscoreThumbnail (4);
		thumb5.GetComponent<RawImage>().texture = HighscoreManager.Instance.getHighscoreThumbnail (5);
	}
/*
	public void show() {
		setScores ();
		title.GetComponent<Text>().enabled = true;
		score1.GetComponent<Text>().enabled = true;
		score2.GetComponent<Text>().enabled = true;
		score3.GetComponent<Text>().enabled = true;
		score4.GetComponent<Text>().enabled = true;
		score5.GetComponent<Text>().enabled = true;
		darken.GetComponent<Text>().enabled = true;
	}
*/
	public void hilight(int n){
		// change title text
		title.GetComponent<Text>().text = TITLE_WIN_TEXT;

		// hilight title text
		title.GetComponent<TextLerp>().enabled = true;

		//hilight the new score's text
		switch (n) {
		case 1:
			score1.GetComponent<TextLerp> ().enabled = true;
			text1.GetComponent<TextLerp> ().enabled = true;
			panel1.GetComponent<ImageColorLerp>().enabled = true;
			break;
		case 2:
			score2.GetComponent<TextLerp> ().enabled = true;
			text2.GetComponent<TextLerp> ().enabled = true;
			panel2.GetComponent<ImageColorLerp>().enabled = true;
			break;
		case 3:
			score3.GetComponent<TextLerp> ().enabled = true;
			text3.GetComponent<TextLerp> ().enabled = true;
			panel3.GetComponent<ImageColorLerp>().enabled = true;
			break;
		case 4:
			score4.GetComponent<TextLerp> ().enabled = true;
			text4.GetComponent<TextLerp> ().enabled = true;
			panel4.GetComponent<ImageColorLerp>().enabled = true;
			break;
		case 5:
			score5.GetComponent<TextLerp> ().enabled = true;
			text5.GetComponent<TextLerp> ().enabled = true;
			panel5.GetComponent<ImageColorLerp>().enabled = true;
			break;
		}
	}
}