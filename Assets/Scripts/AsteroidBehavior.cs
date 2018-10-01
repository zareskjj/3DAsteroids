using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour {

    public float dist;
    Vector3 direction;

    // Use this for initialization
    void Start()
    {
        direction = Camera.main.transform.forward * -1;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + (direction) * dist * Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        string t = other.gameObject.tag;
        if (t.Equals("Asteroid")) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        string t = other.gameObject.tag;
        if (t.Equals("Asteroid"))
        {
            Destroy(gameObject);
        }
    }

}
