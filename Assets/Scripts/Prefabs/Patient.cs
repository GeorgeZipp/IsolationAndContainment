using System
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Address.cs;
using Intake.cs;
using Disease.cs;

public class Patient : MonoBehaviour
{
    System.Random rnd = new Random();
    
    
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
        intake = generateIntakes(90);
        disease = generateDisease();
        age = rnd.Next(100);
        patientID = rnd.Next(1000000000, 9999999999);
    }
}
