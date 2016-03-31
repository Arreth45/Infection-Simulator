using UnityEngine;

public class generator : MonoBehaviour
{
    public double maxPeople = 10;
    private double currentPeople;
    private double alivePeople;
    private double infectedPeople;
    private double deadPeople;
    public GameObject Person;

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
        if (currentPeople < maxPeople)
        {
            Instantiate(Person, new Vector2(Random.Range(0, 5), Random.Range(0, -5)), Quaternion.identity);
            currentPeople++;
        }
    }
}
