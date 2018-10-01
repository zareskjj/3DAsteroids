using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

    public GameObject explosionParticles;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.tag.Equals("Asteroid")) {
            var x = Instantiate(explosionParticles.GetComponent<ParticleSystem>(), transform.position, transform.rotation);
            Destroy(x.gameObject, 2.0f);
            Destroy(other.gameObject);
        }
    }
}
