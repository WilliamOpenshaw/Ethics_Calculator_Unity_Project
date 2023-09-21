using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifHit : MonoBehaviour
{
    public GameObject DayXblock;
    public GameObject DayYblock;
    public GameObject DayZblock;
    public CBCcontroller surveyScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject == DayXblock && other.tag == "ball")
        {
            surveyScript.ChooseDayX();
        }
        else if(gameObject == DayYblock && other.tag == "ball")
        {
            surveyScript.ChooseDayY();
        }
        else if(gameObject == DayZblock && other.tag == "ball")
        {
            surveyScript.ChooseDayZ();
        }
    }
}
