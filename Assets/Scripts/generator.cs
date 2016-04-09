using UnityEngine;

public class generator : MonoBehaviour
{
    public double maxPeople = 50;
    public double currentPeople;
    public double alivePeople;
    public double infectedPeople;
    public double deadPeople;
    public GameObject Person;
    
    public GameObject[] humans,zombies;

    // Use this for initialization
    void Start()
    {
        //spawn max people
        AddPeople();
    }

    // Update is called once per frame
    void Update()
    {
        AddPeople();
    }
    void AddPeople()
    {
        humans = GameObject.FindGameObjectsWithTag("Human");
        zombies = GameObject.FindGameObjectsWithTag("Zombie");
        if (humans.Length + zombies.Length < maxPeople)
        {
            Instantiate(Person, new Vector2(Random.Range(0, 11), Random.Range(0, -11)), Quaternion.identity);
            currentPeople++;
            alivePeople++;
        }
    }
}
