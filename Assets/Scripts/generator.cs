using UnityEngine;
using UnityEngine.UI;

public class generator : MonoBehaviour
{
    public double maxPeople = 20;
    public double currentPeople;
    public double alivePeople;
    public double infectedPeople;
    public double deadPeople;
    public GameObject Person;
    public int screenshotNumber = 0;

    public Text alive, infected, dead;

    void start()
    {
        /*
        alive = GameObject.Find("aliveLabel").GetComponent<Text>();
        infected = GameObject.Find("zombieLabel").GetComponent<Text>();
        dead = GameObject.Find("deadLabel").GetComponent<Text>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        AddPeople();

        //take screenshot
        //Application.CaptureScreenshot("Screen shot: {0}.png", screenshotNumber);
        screenshotNumber++;

        //update labels for counting
        alive.text = "Alive" + alivePeople;
        infected.text = "Infected" + infectedPeople;
        dead.text = "Dead" + deadPeople;
    }
    void AddPeople()
    {
        if (currentPeople < maxPeople)
        {
            Instantiate(Person, new Vector2(Random.Range(0, 21), Random.Range(0, -11)), Quaternion.identity);
            currentPeople++;
        }
    }
}