using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnTrigger : MonoBehaviour
{
    public TextMeshProUGUI canvas;
    public TextMeshProUGUI score;
    public TextMeshProUGUI finalScore;
    public Canvas endGameCanvas;

    public GameObject rightController;
    public GameObject leftController;

    public GameObject rightHand;
    public GameObject leftHand;


    private float points;
    private int tour;

    private bool blockStrike;
    private bool reset;
    private bool delate;

    public static bool state1;
    public static bool state2;
    public static bool state3;
    public static bool state4;
    public static bool state5;
    public static bool state6;
    public static bool state7;
    public static bool state8;
    public static bool state9; 
    public static bool state10;

    public static int numberOfSkittleDown;
    public static bool skittlePositionned;
    public static bool set = false;

    public Transform redSkittle;
    public Transform whiteSkittle;

    private bool firstThrow;
	private bool secondThrow;

    [SerializeField]
    private TextMeshProUGUI[] bestScore = new TextMeshProUGUI[3];

    [SerializeField]
    private TextMeshProUGUI fallen;
    
    [SerializeField]
    private TextMeshProUGUI titleTour;

    private void Start()
    {
        GetPlayerScore();
        rightController.SetActive(false);
        leftController.SetActive(false);
        endGameCanvas.gameObject.SetActive(false);
        tour = 1;
        points = 0.0f;
        firstThrow = false;
        secondThrow = false;
        numberOfSkittleDown = 0;
        canvas.text = "";
        score.text = "0";
        finalScore.text = "";
        reset = false;
        delate = false;
        StartCoroutine(SetSkittleCoroutine(1.0f));
        blockStrike = false;
        fallen.text = "0";
        titleTour.text = "";
        classement.text = "";
    }
	
    private void GetPlayerScore()
	{
        for(int i = 1; i <= 3; i++)
		{
            float tmp = PlayerPrefs.GetFloat("bestScore" + i.ToString(), 0);
            bestScore[i - 1].text = i + ". " + tmp.ToString();
		}
	}

    private void DispSkittleFallen()//TODO OnTrigger: modifier affichage
    {
        fallen.text = numberOfSkittleDown.ToString();
    }

    private void DispTour()
	{
        titleTour.text = "Tour n° " + tour.ToString();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Bowl")
		{
			if(other.name == "BowlForRightHanded")
				other.gameObject.transform.position = new Vector3(-0.88f, 0.845f, 10.83f);
			else if (other.name == "BowlForLeftHanded")
				other.gameObject.transform.position = new Vector3(0.85f, 0.845f, 10.83f);
			other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

			if (firstThrow == false && secondThrow == false)
			{
				firstThrow = true;
			}
			else if (firstThrow == true && secondThrow == false)
			{
				secondThrow = true;
			}
		}
	}


    // Update is called once per frame
    void Update()
    {
        DispTour();

        if (firstThrow == true && secondThrow == false /*&& numberOfSkittleDown == 10*/)
        {
            reset = false;
            delate = false;
            canvas.text = "Tour n° " + tour.ToString();
            if (numberOfSkittleDown == 10 && blockStrike == false)
            {
                //strike
                canvas.text = "strike";

                //on compte le quilles pour les points

                //reset
                if (reset == false)
                    StartCoroutine(ResetTourCoroutine(2.0f));
                ResetTour();
            }
            else if(numberOfSkittleDown < 10)
			{
                blockStrike = true;

                //on compte le quilles pour les points

            }
        }
        else if (firstThrow == true && secondThrow == true )
        {
            blockStrike = false;
            canvas.text = "Tour n° " + tour.ToString() ;

            if (numberOfSkittleDown == 10)
            {
                //spare
                canvas.text = "spare";

                //on compte le quilles pour les points
               
            }
            else if (numberOfSkittleDown < 10)
            {
                //on compte le quilles pour les points

                //on supprime les quilles restantes
                if (delate == false)
                    StartCoroutine(DestroySkittleCoroutine(2.0f));
            }
            //reset
            if (reset == false)
                StartCoroutine(ResetTourCoroutine(4.0f));
            ResetTour();
        }
    
        DispSkittleFallen();
    }

    private IEnumerator ResetTourCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        canvas.text = "";
        SetSkittle();
    }
    private IEnumerator SetSkittleCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        if (set == false)
            set = true;
        else
            set = false;
    }

    private IEnumerator DestroySkittleCoroutine(float time)
	{
        yield return new WaitForSeconds(time);
        Skittle.DestroySkittle();
    }

    private void CountPoint()
    {
        float coeff;
        if (firstThrow == true && secondThrow == false)
            coeff = 3.0f;
        else if (firstThrow == true && secondThrow == true && numberOfSkittleDown == 10)
            coeff = 1.5f;
        else
            coeff = 1.0f;
        points += ((float)numberOfSkittleDown * coeff);
        score.text = points.ToString();
    }

    private void ResetTour()
    {
        CountPoint();
        tour++;
        numberOfSkittleDown = 0;
        firstThrow = false;
        secondThrow = false;
        reset = true;
        delate = true;
        fallen.text = "0";
        if (tour == 11)
            EndGame();
    }

    private void SetSkittle()
    {
        set = false;
        Instantiate(redSkittle, new Vector3(-0.02000001f, 0.48f, -6.76f), Quaternion.identity);
        whiteSkittle.tag = "2";
        Instantiate(whiteSkittle, new Vector3(0.121f, 0.48f, -7.115f), Quaternion.identity);
        whiteSkittle.tag = "3";
        Instantiate(whiteSkittle, new Vector3(-0.18f, 0.48f, -7.12f), Quaternion.identity);
        whiteSkittle.tag = "4";
        Instantiate(whiteSkittle, new Vector3(0.31f, 0.48f, -7.45f), Quaternion.identity);
        whiteSkittle.tag = "5";
        Instantiate(whiteSkittle, new Vector3(-0.03999999f, 0.48f, -7.45f), Quaternion.identity);
        whiteSkittle.tag = "6";
        Instantiate(whiteSkittle, new Vector3(-0.37f, 0.48f, -7.48f), Quaternion.identity);
        whiteSkittle.tag = "7";
        Instantiate(whiteSkittle, new Vector3(0.47f, 0.48f, -7.79f), Quaternion.identity);
        whiteSkittle.tag = "8";
        Instantiate(whiteSkittle, new Vector3(0.14f, 0.48f, -7.78f), Quaternion.identity);
        whiteSkittle.tag = "9";
        Instantiate(whiteSkittle, new Vector3(-0.22f, 0.48f, -7.81f), Quaternion.identity);
        whiteSkittle.tag = "10";
        Instantiate(whiteSkittle, new Vector3(-0.53f, 0.48f, -7.83f), Quaternion.identity);
        StartCoroutine(SetSkittleCoroutine(1.0f));
    }

    private void SetPlayerScore()
	{
        for(int i = 1; i <= 3; i++)
		{
            if (PlayerPrefs.GetFloat("bestScore" + i.ToString(), 0) < points)
			{
                if(i == 1)
				{//TODO: revoir ordre
                    bestScore[2] = bestScore[1];
                    bestScore[1] = bestScore[0];

                    PlayerPrefs.SetFloat("bestScore3", PlayerPrefs.GetFloat("bestScore2", 0));
                    PlayerPrefs.SetFloat("bestScore2", PlayerPrefs.GetFloat("bestScore1", 0));
				}
                else if (i == 2)
				{
                    bestScore[2] = bestScore[1];
                    PlayerPrefs.SetFloat("bestScore3", PlayerPrefs.GetFloat("bestScore2", 0));
                }
                PlayerPrefs.SetFloat("bestScore" + i, points);
                break;
            }
		}
	}

    private void EndGame()
	{
        SetPlayerScore();
        GetPlayerScore();

        endGameCanvas.gameObject.SetActive(true);
        
        rightHand.SetActive(false);
        leftHand.SetActive(false);

        rightController.SetActive(true);
        leftController.SetActive(true);

        finalScore.text = "Score : " + score.text;
	}


}
