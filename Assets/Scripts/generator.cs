using UnityEngine;

public class generator : MonoBehaviour
{
    public double maxPeople = 20;
    public double currentPeople;
    public double alivePeople;
    public double infectedPeople;
    public double deadPeople;
    public GameObject Person;
    
    // Use this for initialization
    void Start()
    {      
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
            Instantiate(Person, new Vector2(Random.Range(0, 11), Random.Range(0, -11)), Quaternion.identity);
            currentPeople++;
        }
    }
}
