using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public GUIText scoreValue;
	public GUIText highScoreValue;

	static int highScore = 13;
	int score = 0;

	void Start()
	{
		AddScore(0);
		highScoreValue.color = Color.white;
	}

	public void AddScore(int s)
	{
		score += s;
		if (score > highScore)
		{
			highScore = score;
			highScoreValue.color = Color.green;
		}

		scoreValue.text = "" + score;
		highScoreValue.text = "" + highScore;
	}
}
