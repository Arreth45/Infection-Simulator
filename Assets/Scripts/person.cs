using UnityEngine;

public class person : MonoBehaviour
{
    public bool isInfected, isAlive, isDead;
    private float humanRunspeed = 10;
    private float zombieRunspeed = 9;
    private int infected;
    private float zombieTime;
    private float zombieTimer = 0;
    private Transform target;

    private GameObject[] zombies;

    // Use this for initialization
    void Start()
    {
        isAlive = true;
        infected = Random.Range(1, 6);
        if (infected == 1)
        {
            isAlive = false;
            isInfected = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        zombies = GameObject.FindGameObjectsWithTag("Zombie");
        if (isAlive)
        {
            foreach (GameObject zombie in zombies)
            {
                transform.Translate(-zombie.transform.localPosition);
            }
        }

        if (isInfected)
        {
            gameObject.tag = "Zombie";
            target = GameObject.FindGameObjectWithTag("Person").transform;
            GetComponent<SpriteRenderer>().color = Color.green;
            //zombieTimer += Time.deltaTime;
            if (zombieTimer >= zombieTime)
            {
                isInfected = false;
                isDead = true;
            }
            transform.Translate(target.localPosition);
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
