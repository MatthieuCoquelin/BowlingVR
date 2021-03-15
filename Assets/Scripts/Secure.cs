using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secure : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bowl")
		{
			if (other.name == "BowlForRightHanded")
				other.gameObject.transform.position = new Vector3(-0.88f, 0.845f, 10.83f);
			else if (other.name == "BowlForLeftHanded")
				other.gameObject.transform.position = new Vector3(0.85f, 0.845f, 10.83f);
			other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
	}
}
