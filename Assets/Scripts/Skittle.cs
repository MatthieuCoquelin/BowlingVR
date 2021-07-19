using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skittle : MonoBehaviour
{
	float xPosition;
    float yPosition;
    float zPosition;

    //AudioSource skittleDownSound;

    public Transform redSkittle;
    public Transform whiteSkittle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitiateSkittlePositionCoroutine(1.0f));
        OnTrigger.numberOfSkittleDown = 0;
    }

    Skittle()
	{
        OnTrigger.state1 = true;
        OnTrigger.state2 = true;
        OnTrigger.state3 = true;
        OnTrigger.state4 = true;
        OnTrigger.state5 = true;
        OnTrigger.state6 = true;
        OnTrigger.state7 = true;
        OnTrigger.state8 = true;
        OnTrigger.state9 = true;
        OnTrigger.state10 = true;
	}

    // Update is called once per frame
    void Update()
    {
        if ((xPosition != gameObject.transform.position.x || yPosition != gameObject.transform.position.y || zPosition != gameObject.transform.position.z) && OnTrigger.set == true)
		{
            if(OnTrigger.state1 == true && gameObject.tag == "1")
			{
                OnTrigger.state1 = false;
                OnTrigger.numberOfSkittleDown++;
            }
            if (OnTrigger.state2 == true && gameObject.tag == "2")
            {
                OnTrigger.state2 = false;
                OnTrigger.numberOfSkittleDown++;
            }
            if (OnTrigger.state3 == true && gameObject.tag == "3")
            {
                OnTrigger.state3 = false;
                OnTrigger.numberOfSkittleDown++;
            }
            if (OnTrigger.state4 == true && gameObject.tag == "4")
            {
                OnTrigger.state4 = false;
                OnTrigger.numberOfSkittleDown++;
            }
            if (OnTrigger.state5 == true && gameObject.tag == "5")
            {
                OnTrigger.state5 = false;
                OnTrigger.numberOfSkittleDown++;
            }
            if (OnTrigger.state6 == true && gameObject.tag == "6")
            {
                OnTrigger.state6 = false;
                OnTrigger.numberOfSkittleDown++;
            }
            if (OnTrigger.state7 == true && gameObject.tag == "7")
            {
                OnTrigger.state7 = false;
                OnTrigger.numberOfSkittleDown++;
            }
            if (OnTrigger.state8 == true && gameObject.tag == "8")
            {
                OnTrigger.state8 = false;
                OnTrigger.numberOfSkittleDown++;
            }
            if (OnTrigger.state9 == true && gameObject.tag == "9")
            {
                OnTrigger.state9 = false;
                OnTrigger.numberOfSkittleDown++;
            }
            if (OnTrigger.state10 == true && gameObject.tag == "10")
            {
                OnTrigger.state10 = false;
                OnTrigger.numberOfSkittleDown++;
            }
           /* skittleDownSound = gameObject.GetComponent<AudioSource>();
            skittleDownSound.Play(0);*/
            Destroy(gameObject, 1.0f);
		}
        
    }
	public static void DestroySkittle()
	{
        GameObject one = GameObject.FindGameObjectWithTag("1");
        GameObject two = GameObject.FindGameObjectWithTag("2");
        GameObject three = GameObject.FindGameObjectWithTag("3");
        GameObject four = GameObject.FindGameObjectWithTag("4");
        GameObject five = GameObject.FindGameObjectWithTag("5");
        GameObject six = GameObject.FindGameObjectWithTag("6");
        GameObject seven = GameObject.FindGameObjectWithTag("7");
        GameObject eight = GameObject.FindGameObjectWithTag("8");
        GameObject nine = GameObject.FindGameObjectWithTag("9");
        GameObject ten = GameObject.FindGameObjectWithTag("10");

        Destroy(one);
        Destroy(two);
        Destroy(three);
        Destroy(four);
        Destroy(five);
        Destroy(six);
        Destroy(seven);
        Destroy(eight);
        Destroy(nine);
        Destroy(ten);
	}

    IEnumerator InitiateSkittlePositionCoroutine(float time)
	{
        yield return new WaitForSeconds(time);
        InitiatePosition();
	}

    public  void InitiatePosition()
	{
        xPosition = gameObject.transform.position.x;
        yPosition = gameObject.transform.position.y;
        zPosition = gameObject.transform.position.z;
    }
}