using UnityEngine;

public class person : MonoBehaviour
{
    public bool isInfected, isAlive, isDead;
    private float humanRunspeed = 2;
    private float zombieRunspeed = 1;
    private int infected;
    private float zombieTime;
    private float zombieTimer = 0;
    private GameObject target;

    private GameObject[] zombies, humans;

    // Use this for initialization
    void Start()
    {
        gameObject.tag = "Human";
        isAlive = true;
        infected = Random.Range(1, 6);
        if (infected.Equals(1))
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
            zombies = GameObject.FindGameObjectsWithTag("Zombie");
            foreach (GameObject zombie in zombies)
            {
                //code to run from zombies
                gameObject.transform.Translate(-zombie.transform.position);
            }
        }

        if (isInfected)
        {
            humans = GameObject.FindGameObjectsWithTag("Human");
            GetComponent<SpriteRenderer>().color = Color.green;
            zombieTimer += Time.deltaTime * 0.01f;

            if (zombieTimer >= zombieTime)
            {
                isInfected = false;
                isDead = true;
            }

            if (target == null)
            {
                target = humans[Random.Range(0, humans.Length)];
            }
            gameObject.transform.Translate(target.transform.position);
        }

        if (isDead)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Human")
        {
            if (collision.gameObject.tag == "Zombie")
            {
                Debug.Log("Mess with the best, Die like the rest");
                gameObject.tag = "Zombie";
                isAlive = false;
                isInfected = true;
                zombieTime = Random.Range(10, 21);
            }
        }
    }
}
