using PizzaTime.Core;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class POSClockController : MonoBehaviour
{
    private Text text;
    private InGameClock clock;

    private void Awake()
    {
        clock = new InGameClock(60);
        clock.StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 30, 0, 0);
        text = GetComponent<Text>();
        text.text = clock.CurrentTime.ToString("hh:mm tt");        
    }

    private void Start()
    {
        clock.Start();
        StartCoroutine(StartClock());
    }

    IEnumerator StartClock()
    {
        while (true) 
        {
            text.text = clock.CurrentTime.ToString("hh:mm tt");
            yield return null;
        }        
    }

    private void Update()
    {
    }
}
