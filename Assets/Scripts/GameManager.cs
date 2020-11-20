using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class GameManager : MonoBehaviour
{

public AudioSource theMusic;

public bool startPlaying;

public BeatScroller theBS;

public static GameManager instance;
public Text scText;
public Text mxText;
public int currentScore;

public int scorePerNote = 100;
public int scorePerGoodNote = 125;
public int scorePerPerfectNote = 150;

public int currentMultiplier;
public int multiplierTracker;
public int [] multiplierThresholds;

public string scoreText;
public string multiText;
public float totalBeats;
public float normalHits;
public float goodHits;
public float perfectHits;
public float missedHits;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

	
		//scoreText.text = "Score: 0";
		//currentMultiplier = 1;

		totalBeats = FindObjectsOfType<NoteObject>().Length;

	scoreText = "Score: 0";
	currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
	{
	if(Input.anyKeyDown)
		{
			startPlaying = true;
			theBS.hasStarted = true;

			theMusic.Play();
		}
	}
    }

	public void NoteHit()
	{
	Debug.Log("Hit On Time");

	if(currentMultiplier - 1 < multiplierThresholds.Length)
	{

	
	scText = GameObject.FindGameObjectWithTag("ScoreTag").GetComponent<Text>();
	mxText = GameObject.FindGameObjectWithTag("MultiplierTag").GetComponent<Text>();

	multiplierTracker++;

	if(multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
		{
		multiplierTracker = 0;
		currentMultiplier++;
		}
	}

	mxText.text = "Multiplier: x" + currentMultiplier.ToString();

	//currentScore += scorePerNote * currentMultiplier;
	scText.text = "Score: " + currentScore.ToString();
	}

	public void NormalHit()
	{
		currentScore += scorePerNote * currentMultiplier;
		NoteHit();
		Debug.Log(multiText);
		Debug.Log(scoreText);

		normalHits++;
	}

	public void GoodHit()

	{
		currentScore += scorePerGoodNote * currentMultiplier;
		NoteHit();

		goodHits++;
	}

	public void PerfectHit()

	{
		currentScore += scorePerPerfectNote * currentMultiplier;
		NoteHit();

		perfectHits++;
	}

	public void NoteMissed()
	{
	Debug.Log("Missed Note");

	currentMultiplier = 1;
	multiplierTracker = 0;

	multiText = "Multiplier: x" + currentMultiplier.ToString();

	missedHits++;
	}
}
