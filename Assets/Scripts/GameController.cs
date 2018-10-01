using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject damagedParticles;

    GameObject player;
    public int lives;

    // Use this for initialization
    void Start()
    {
        lives = 2;
        player = Instantiate(Resources.Load("Player")) as GameObject;
        InvokeRepeating("spawnAsteroid", 0.5f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnAsteroid()
    {
        Vector3 x;
        // Place asteroid in front of player at a far distance. (z axis of player object)
        x = player.transform.forward * Random.Range(60.0f, 100.0f) + player.transform.position;
        // Move up/down y axis of player object
        x += player.transform.up * Random.Range(-30.0f, 30.0f);
        // Move left/right on x axis of player object
        x += player.transform.right * Random.Range(-30.0f, 30.0f);
        GameObject a = Instantiate(Resources.Load("Asteroid" + Random.Range(1, 3))) as GameObject;
        a.transform.position = x;
        Destroy(a, 10.0f);
    }

    public void playerCollision()
    {
        lives--;
        var d = Instantiate(damagedParticles.GetComponent<ParticleSystem>(), player.transform.position, player.transform.rotation);
        Destroy(d, 3.0f);

        if (lives <= 0)
        {
            CancelInvoke("spawnAsteroid");
            Debug.Log("Game over!");

            GameObject[] astrs = GameObject.FindGameObjectsWithTag("Asteroid");
            destroyAll(astrs);
            //UnityEngine.SceneManagement.SceneManager.LoadScene("");  // Maybe load a different scene when game is over?
        }
    }

    void destroyAll(GameObject[] list) {
        foreach (GameObject a in list) {
            if (a != null) {
                Destroy(a);
            }
        }
    }
}
