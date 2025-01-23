using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    private Rigidbody targetRb;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb = GetComponent<Rigidbody>();

        //add force
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //add torque
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        //spawn at random position
        transform.position = (RandomSpawnPos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //On mouse click destroy target
    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
    }

    //On trigger enter destroy target
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    //Random force method
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    //Random Torque method
    float RandomTorque()
    {
       return Random.Range(-maxTorque, maxTorque);
    }

    //Random Spawn method
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
