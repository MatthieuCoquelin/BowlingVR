using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnTrigger : MonoBehaviour
{
    public TextMeshProUGUI canvas;
    public TextMeshProUGUI score;

    private int points;
    private bool blockStike;
    private bool reset;
    private bool delate;
    public static bool set = false;

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

    public Transform redSkittle;
    public Transform whiteSkittle;

    private bool firstThrow;
	private bool secondThrow;


    private void Start()
    {
        points = 0;
        firstThrow = false;
        secondThrow = false;
        numberOfSkittleDown = 0;
        canvas.text = "";
        score.text = "0";
        reset = false;
        delate = false;
        StartCoroutine(SetSkittleCoroutine(1.0f));
        blockStike = false;
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
        if (firstThrow == true && secondThrow == false /*&& numberOfSkittleDown == 10*/)
        {
            reset = false;
            delate = false; 
            canvas.text = "firstThrow: " + firstThrow.ToString() + "\nsecondThrow: " + secondThrow.ToString() + "\nSkittleDown: " + numberOfSkittleDown.ToString();
            if (numberOfSkittleDown == 10 && blockStike == false)
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
                blockStike = true;

                //on compte le quilles pour les points

            }
        }
        else if (firstThrow == true && secondThrow == true )
        {
            blockStike = false;
            canvas.text = "firstThrow: " + firstThrow.ToString() + "\nsecondThrow: " + secondThrow.ToString() + "\nSkittleDown: " + numberOfSkittleDown.ToString();

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

    }

    private IEnumerator ResetTourCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
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
        int coeff;
        if (firstThrow == true && secondThrow == false)
            coeff = 2;
        else
            coeff = 1;
        points += (numberOfSkittleDown * coeff);
        score.text = points.ToString();
    }

    private void ResetTour()
    {
        CountPoint();
        numberOfSkittleDown = 0;
        firstThrow = false;
        secondThrow = false;
        reset = true;
        delate = true;
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

}
