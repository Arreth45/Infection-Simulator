using UnityEngine;

public class person : MonoBehaviour
{
    public bool isInfected, isAlive, isDead;
    private float humanRunspeed = 0.1f;
    private float zombieRunspeed = 0.01f;
    public int infected;
    private float zombieTime = 20;
    private float zombieTimer = 0;
    private GameObject target;
    public GameObject manager;

    private GameObject[] zombies, humans;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("_manager");
        manager.GetComponent<generator>().alivePeople++;
        gameObject.tag = "Human";
        isAlive = true;
        
        
        infected = Random.Range(1, 7);
        if (infected >= 3)
        {
            isAlive = false;
            isInfected = true;
            manager.GetComponent<generator>().infectedPeople++;
            manager.GetComponent<generator>().alivePeople--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            zombies = GameObject.FindGameObjectsWithTag("Zombie");
            foreach (GameObject zombie in zombies)
            {
                //code to run from zombies
                //Kevin is working on this
            }
        }

        if (isInfected)
        {
            humans = GameObject.FindGameObjectsWithTag("Human");
            GetComponent<SpriteRenderer>().color = Color.green;
            zombieTimer += Time.deltaTime;

            if (zombieTimer > zombieTime)
            {
                manager.GetComponent<generator>().deadPeople++;
                isInfected = false;
                isDead = true;
            }

            //chase humans 
            //Kevin is working on this
        }

        if (isDead)
        {
            manager.GetComponent<generator>().deadPeople++;
            manager.GetComponent<generator>().infectedPeople--;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Human")
        {
            if (collision.gameObject.tag == "Zombie")
            {
                manager.GetComponent<generator>().alivePeople--;
                manager.GetComponent<generator>().infectedPeople++;
                Debug.Log("Mess with the best, Die like the rest");
                gameObject.tag = "Zombie";
                isAlive = false;
                isInfected = true;
            }
        }
    }
}