using UnityEngine;

public class person : MonoBehaviour
{
    private bool isInfected, isAlive, isDead;
    private float runspeed;
    private int infected;
    private float maxPeople;
    private float zombieTime;
    private float zombieTimer;

    // Use this for initialization
    void Start()
    {
        isAlive = true;
        infected = Random.Range(1, 11);
        if (infected == 1)
        {
            isAlive = false;
            isInfected = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            //code to run from "zombies"
            // collison with zombie 

        }

        if (isInfected)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            //code to chase alive people

            gameObject.tag = "Zombie";

            zombieTime = Random.Range(10, 21);
            zombieTimer = +Time.deltaTime * 100;
            if (zombieTimer >= zombieTime)
            {
                isInfected = false;
                isDead = true;
            }
        }

        if (isDead)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Person")
        {
            if (collision.gameObject.tag == "Zombie")
            {
                isAlive = false;
                isInfected = true;
            }
        }

    }
}
