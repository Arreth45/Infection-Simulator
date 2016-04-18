using UnityEngine;

public class generator : MonoBehaviour
{
    public double maxPeople = 20;
    public double currentPeople;
    public double alivePeople;
    public double infectedPeople;
    public double deadPeople;
    public GameObject Person;
    public int screenshotNumber = 0;
    
    // Update is called once per frame
    void Update()
    {
        AddPeople();
        //take screenshot
        //Application.CaptureScreenshot("Screen shot: {0}.png", screenshotNumber);
        screenshotNumber++;
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