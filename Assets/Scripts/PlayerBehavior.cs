using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    public GameObject projectile;
    public Transform projectileSpawn;

    GameObject gco;
    GameController gameController;

	// Use this for initialization
	void Start () {
        Vector3 startPosition = new Vector3(0, 0, 0);
        Quaternion startRotation = new Quaternion(0, 0, 0, 0);
        transform.SetPositionAndRotation(startPosition, startRotation);
        gco = GameObject.FindWithTag("GameController");
        gameController = gco.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameController.lives > 0)
        {
            var verticalRot = Input.GetAxis("Vertical") * 20.0f * Time.deltaTime;
            var horizontalRot = Input.GetAxis("Horizontal") * 20.0f * Time.deltaTime;
            transform.Rotate(-1 * verticalRot, horizontalRot, 0);

            Quaternion currRot = transform.rotation;

            var dist = 20.0f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                dist += 10.0f;
            }
            transform.position = transform.position + Camera.main.transform.forward * dist * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                InvokeRepeating("shootProjectile", 0f, 0.2f);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                CancelInvoke("shootProjectile");
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        string t = other.gameObject.tag;
        if (t.Equals("Asteroid")) {
            Destroy(other.gameObject);
            gameController.playerCollision();
            Debug.Log("Lives: " + gameController.lives);
        }
    }

    void shootProjectile() {
        GameObject x = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation) as GameObject;
        x.GetComponent<Rigidbody>().velocity = x.transform.forward * 40.0f;
        x.transform.Rotate(new Vector3(1, 0), 90);
        Destroy(x, 3.5f);
    }
}
