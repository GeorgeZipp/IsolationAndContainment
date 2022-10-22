using System
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Address.cs;

public class Patient : MonoBehaviour
{
    System.Random rnd = new Random();
    public struct Disease
    {
        string name;
        double percentage;
        int effect;
        bool has;
    }
    public struct Intake
    {
        string name;
        int effect;
        bool has;
    }
    public int patientID;
    public int age;
    public List<Intake> intake;
    public List<Disease> disease;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialize()
    {
        readDisease();
        readIntake();
    }
    
    private void generatePatientData()
    {

    }
    private void readDisease()
    {
        string[] dInfo = System.IO.File.ReadAllLines(@"C:\Users\alien\dev\IsolationAndContainment\Assets\Scripts\DataLists\Disease.txt");
        disease = new List<Disease>();
        Disease temp = new Disease();
        for(int i = 0; i < dInfo.Length; i++)
        {
            string[] d = dInfo[i].Split(',');
            temp.name = d[0];
            temp.percentage = (double)d[1];
            temp.effect = (int)d[2];
            disease.Add(temp);
        }
    }
    private void readIntake()
    {
        string[] iOne = System.IO.File.ReadAllLines(@"C:\Users\alien\dev\IsolationAndContainment\Assets\Scripts\DataLists\IntakeOnePart.txt");
        string[] iTwo = System.IO.File.ReadAllLines(@"C:\Users\alien\dev\IsolationAndContainment\Assets\Scripts\DataLists\IntakeTwoPart.txt");
        int x = 0;
        intake = new List<Intake>();
        Intake temp = new Intake();
        for(x; x<iOne.Length; x++)
        {
            string[] one = iOne[x].Split(',');
            temp.name = one[0];
            temp.effect = (int)one[1];
            intake.Add(temp);
        }
        for(int i = 0; i < iTwo.Length; i++)
        {
            string[] two = iTwo[i].Split(',');
            temp.name = two[0];
            temp.effect = (int)two[1];
            intake.Add(temp);
        }
    }
    List<Disease> generateDiseases()
    {

    }
    List<Intake> generateIntakes(int startingPercentage)
    {
        List<Intake> tempIntakes = intake;
        List<Intake> returnIntakes = new List<Intake>();
        int starting = startingPercentage;
        int decrement = starting / intake.Count;
        int totalSymptoms = 0;
        for(int i = 0; i < intake.Count; i++)
        {
            if (rnd.Next(100) < starting)
                totalSymptoms++;
            starting = starting - decrement;
        }
        for(int i = 0; i < totalSymptoms; i++)
        {
            int val = rnd.Next(tempIntakes.Count);
            returnIntakes.Add(tempIntakes[val]);
            tempIntakes.RemoveAt(val);
        }
        return returnIntakes;
    }
}
