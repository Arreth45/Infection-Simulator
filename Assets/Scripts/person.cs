using UnityEngine;

public class person : MonoBehaviour
{
    public bool isInfected, isAlive, isDead;
    private float humanRunspeed = 0.2f;
    private float zombieRunspeed = 0.1f;
    public int infected;
    private float zombieTime = 20;
    private float zombieTimer = 0;
    private float x, y;
    private Vector3 point;
    public GameObject target;
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
        //Code for Human Person
        if (isAlive)
        {
            //code to run from zombies
            float step = humanRunspeed;
            x = Random.Range(0, 20);
            y = Random.Range(0, 20);
            point = new Vector3(x, y, 0);
            transform.position = Vector3.MoveTowards(transform.position, point, step);
        }

        // Code for Zombie Person
        if (isInfected)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            humans = GameObject.FindGameObjectsWithTag("Human");
            zombieTimer += Time.deltaTime;

            if (zombieTimer > zombieTime)
            {
                manager.GetComponent<generator>().deadPeople++;
                isInfected = false;
                isDead = true;
            }

            // if no target get a target
            if (target == null)
            {
                target = humans[Random.Range(0, humans.Length)];
            }

            //chase humans 
            float step = zombieRunspeed;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }

        //code to update counters in generator
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