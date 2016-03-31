using UnityEngine;

public class person : MonoBehaviour
{
    public bool isInfected, isAlive, isDead;
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

        }

        if (isInfected)
        {
            GetComponent<SpriteRenderer>().color = Color.green;         
            gameObject.tag = "Zombie";
            zombieTimer += Time.deltaTime;
            if (zombieTimer >= zombieTime)
            {
                isInfected = false;
                isDead = true;
            }
            
            //code to chase alive people
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
                zombieTime = Random.Range(10, 21);
            }
        }

    }
}
