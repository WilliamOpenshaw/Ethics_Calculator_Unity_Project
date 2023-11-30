using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UCharts;
using System;

public class GS2UnityDemoScript : MonoBehaviour
{
    public int[][] onlineTotalChoiceTallies;
    
    public TextMeshProUGUI topChoice1;
    public TextMeshProUGUI topChoice2;
    public TextMeshProUGUI topChoice3;
    public TextMeshProUGUI topChoice4;
    public TextMeshProUGUI topChoice5;

    public TextMeshProUGUI bottomChoice1;
    public TextMeshProUGUI bottomChoice2;
    public TextMeshProUGUI bottomChoice3;
    public TextMeshProUGUI bottomChoice4;
    public TextMeshProUGUI bottomChoice5;
    
    public int tryParseResultA;
    public int tryParseResultB;
    public TextMeshProUGUI pointsOfDifference;
    public float xDifference;
    public float yDifference;

    public float x2_plus_y2;

    public float hypotenuseLength;

    public GameObject CentroidA;
    public GameObject CentroidB;
    GoogleSheetsDB googleSheetsDB;
    public GoogleSheet txtSheet;    

    public TextMeshProUGUI numberOfTotalResultsText;

    public TextMeshProUGUI resultNumberTextUILabelA;
    public TextMeshProUGUI timeTextA;
    public TextMeshProUGUI rTextA;
    public TextMeshProUGUI uTextA;
    public TextMeshProUGUI veTextA;
    public TextMeshProUGUI kaTextA;
    public TextMeshProUGUI nlTextA;

    public TextMeshProUGUI resultNumberTextUILabelB;

    public TextMeshProUGUI timeTextB;
    public TextMeshProUGUI rTextB;
    public TextMeshProUGUI uTextB;
    public TextMeshProUGUI veTextB;
    public TextMeshProUGUI kaTextB;
    public TextMeshProUGUI nlTextB;


    public string[][] googleSheetDataResultsForName;

    public string[] resultsA;
    public string[] resultsB;

    public int numberOfRows;

    public string enteredName;

    public int currentResultNumber;

    public GameObject radarA;
    public GameObject radarB;

    public RadarChart radarChartAscript;

    public RadarChart radarChartBscript;

    public int highestEthicsSchoolPointsA;
    public int highestEthicsSchoolPointsB;

    public int resultANumber;

    public int resultBNumber;

    public string viewStringtest;

    public int numberOfLoopsRun;

    public void Start()
    {
        onlineTotalChoiceTallies[0] = new int[9]{0,0,0,0,0,0,0,0,0};
        onlineTotalChoiceTallies[1] = new int[10]{0,0,0,0,0,0,0,0,0,0};
        onlineTotalChoiceTallies[2] = new int[9]{0,0,0,0,0,0,0,0,0};
        onlineTotalChoiceTallies[3] = new int[18]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        onlineTotalChoiceTallies[4] = new int[9]{0,0,0,0,0,0,0,0,0};
        
        timeTextA.text = "x";
        rTextA.text =  "x";
        uTextA.text =  "x";
        veTextA.text =  "x";
        kaTextA.text =  "x";
        nlTextA.text =  "x";

         timeTextB.text = "x";
        rTextB.text =  "x";
        uTextB.text =  "x";
        veTextB.text =  "x";
        kaTextB.text =  "x";
        nlTextB.text =  "x";
        
        currentResultNumber = 0;
        enteredName = "empty";

        googleSheetDataResultsForName = new string[1000][];

        for (int i = 0; i < 1000; i++)
        {
            googleSheetDataResultsForName[i] = new string[10];
        }

        radarA = GameObject.Find("RadarChart A");
        radarB = GameObject.Find("RadarChart B");

        resultANumber = -1;
        resultBNumber = -1;

        resultsA = new string[10];
        resultsB = new string[10];
    }

    private void OnEnable()
    {
        googleSheetsDB = gameObject.GetComponent<GoogleSheetsDB>();
        googleSheetsDB.OnDownloadComplete += UpdateText;
    }

    private void OnDisable()
    {
        googleSheetsDB.OnDownloadComplete -= UpdateText;
    }

    public void UpdateText()
    {
        int txtSheetIndex = googleSheetsDB.sheetTabNames.IndexOf("Form Responses 1");

        txtSheet = googleSheetsDB.dataSheets[txtSheetIndex];

        TallyBestAndWorstChoices();        
    }

    public void TallyBestAndWorstChoices()
    {
        // 0-Uti. 1-Raw. 2-Vir.Eth. 3-NeoLib 4-Kant // Choices 1-16 each // jagged array that holds tally of how many times each choice is chosen
        CountUtilitarian();
        CountRawlsian();
        CountVirtueEthics();
        CountNeoliberal();
        CountKantian();
    }

    CountUtilitarian()
    {
        
    }
    
    public void searchNameResults(string typedName)
    {
        resultANumber = -1;
        resultBNumber = -1;
        ClearResultsAandB();

        timeTextA.text = "x";
        rTextA.text =  "x";
        uTextA.text =  "x";
        veTextA.text =  "x";
        kaTextA.text =  "x";
        nlTextA.text =  "x";

        timeTextB.text = "x";
        rTextB.text =  "x";
        uTextB.text =  "x";
        veTextB.text =  "x";
        kaTextB.text =  "x";
        nlTextB.text =  "x";
        
        resultNumberTextUILabelA.text = "x";
        resultNumberTextUILabelB.text = "x";

        resultsA = new string[] {"","","","","","","","","",""};
        resultsB = new string[] {"","","","","","","","","",""};
        
        radarA = GameObject.Find("RadarChart A");
        radarB = GameObject.Find("RadarChart B");

        enteredName = typedName;

        int txtSheetIndex = googleSheetsDB.sheetTabNames.IndexOf("Form Responses 1");

        txtSheet = googleSheetsDB.dataSheets[txtSheetIndex];

        currentResultNumber = 0;

        numberOfLoopsRun = 0;

        for (int i = 1; i < 1000; i++)
        {
            if (txtSheet.GetRowData(i.ToString(), "Name") == enteredName)
            {
                googleSheetDataResultsForName[currentResultNumber][0] = txtSheet.GetRowData(i, "Timestamp");
                googleSheetDataResultsForName[currentResultNumber][1] = txtSheet.GetRowData(i, "Name");
                googleSheetDataResultsForName[currentResultNumber][2] = txtSheet.GetRowData(i, "Group");
                googleSheetDataResultsForName[currentResultNumber][3] = txtSheet.GetRowData(i, "Rawlsian score");
                googleSheetDataResultsForName[currentResultNumber][4] = txtSheet.GetRowData(i, "Utilitarian score");
                googleSheetDataResultsForName[currentResultNumber][5] = txtSheet.GetRowData(i, "Virtue Ethics score");
                googleSheetDataResultsForName[currentResultNumber][6] = txtSheet.GetRowData(i, "Neoliberal score");
                googleSheetDataResultsForName[currentResultNumber][7] = txtSheet.GetRowData(i, "Kantian score");
                googleSheetDataResultsForName[currentResultNumber][8] = txtSheet.GetRowData(i, "Centroid X Coordinate");
                googleSheetDataResultsForName[currentResultNumber][9] = txtSheet.GetRowData(i, "Centroid Y Coordinate");

                currentResultNumber += 1;
            }
            numberOfLoopsRun += 1;
            if(txtSheet.GetRowData(i.ToString(), "Timestamp") == "")
            {
                break;
            }
            
        }
        numberOfTotalResultsText.text = "There are " + currentResultNumber + " results for this name.";        

        SelectionAIncrease();
        SelectionBIncrease();
        SelectionBIncrease();        
    }

    public void SelectionAIncrease()
    {
        if (resultANumber >= currentResultNumber -1)
        {
            resultANumber = 0;
            ChangeResultsA(resultANumber);
        }
        else
        {
            resultANumber += 1;
            ChangeResultsA(resultANumber);
        }
    }

    public void SelectionADecrease()
    {
        if (resultANumber <= 1)
        {
            resultANumber = currentResultNumber;
            ChangeResultsA(resultANumber);
        }
        else
        {
            resultANumber -= 1;
            ChangeResultsA(resultANumber);
        }
    }

    public void SelectionBIncrease()
    {
        if (resultBNumber >= currentResultNumber - 1)
        {
            resultBNumber = 0;
            ChangeResultsB(resultBNumber);
        }
        else 
        {
            resultBNumber += 1;
            ChangeResultsB(resultBNumber);
        }
    }

    public void SelectionBDecrease()
    {
        if (resultBNumber <= 1)
        {
            resultBNumber = currentResultNumber;
            ChangeResultsB(resultBNumber);
        }
        else 
        {
            resultBNumber -= 1;
            ChangeResultsB(resultBNumber);
        }
    }
    public void ChangeResultsA(int resultNumberA)
    {
        radarA = GameObject.Find("RadarChart A");
        radarB = GameObject.Find("RadarChart B");

        resultsA[0] = googleSheetDataResultsForName[resultNumberA][0];  //timestamp
        resultsA[1] = googleSheetDataResultsForName[resultNumberA][1];  //name
        resultsA[2] = googleSheetDataResultsForName[resultNumberA][2];  //group
        resultsA[3] = googleSheetDataResultsForName[resultNumberA][3];  //rawlsian score
        resultsA[4] = googleSheetDataResultsForName[resultNumberA][4];  //utilitarian score
        resultsA[5] = googleSheetDataResultsForName[resultNumberA][5];  //virtue ethics score
        resultsA[6] = googleSheetDataResultsForName[resultNumberA][6];  //neoliberal score
        resultsA[7] = googleSheetDataResultsForName[resultNumberA][7];  //kantian score
        resultsA[8] = googleSheetDataResultsForName[resultNumberA][8];  //centroid X
        resultsA[9] = googleSheetDataResultsForName[resultNumberA][9];  //centroid Y

        //viewStringtest = resultsA[3];

        Debug.Log(
            "A = " +            
            resultsA[3].ToString() + " " +
            resultsA[4].ToString() + " " +
            resultsA[5].ToString() + " " +
            resultsA[6].ToString() + " " +
            resultsA[7].ToString() 
        );
        if(int.TryParse(resultsA[3], out tryParseResultA))
        {
            highestEthicsSchoolPointsA = Mathf.Max(int.Parse(resultsA[3]),
                                                   int.Parse(resultsA[4]),
                                                   int.Parse(resultsA[5]),
                                                   int.Parse(resultsA[6]),
                                                   int.Parse(resultsA[7]));
        }
        else
        {
            highestEthicsSchoolPointsA = 0;
        }        

        radarChartAscript = GameObject.Find("RadarChart A").GetComponent<RadarChart>();

        radarChartAscript.m_Data = new List<float>
            {
                (float.Parse(resultsA[3]) / (float)(highestEthicsSchoolPointsA)),
                (float.Parse(resultsA[4]) / (float)(highestEthicsSchoolPointsA)),
                (float.Parse(resultsA[7]) / (float)(highestEthicsSchoolPointsA)),
                (float.Parse(resultsA[6]) / (float)(highestEthicsSchoolPointsA)),
                (float.Parse(resultsA[5]) / (float)(highestEthicsSchoolPointsA)),
                (float.Parse(resultsA[3]) / (float)(highestEthicsSchoolPointsA))      // added a arbitrary 6th value to list because otherwise radar chart doesn't show value for 5th axis VE
            };
        radarA.SetActive(false);
        radarA.SetActive(true);

        timeTextA.text = resultsA[0];
        rTextA.text = resultsA[3];
        uTextA.text = resultsA[4];
        veTextA.text = resultsA[5];
        kaTextA.text = resultsA[7];
        nlTextA.text = resultsA[6];

        resultNumberTextUILabelA.text = (resultNumberA + 1).ToString();
        
        StartCoroutine(CalculateAndDisplayHypotenuseLength());
    }

    public void ChangeResultsB(int resultNumberB)
    {
        radarA = GameObject.Find("RadarChart A");
        radarB = GameObject.Find("RadarChart B");

        resultsB[0] = googleSheetDataResultsForName[resultNumberB][0];  //timestamp
        resultsB[1] = googleSheetDataResultsForName[resultNumberB][1];  //name
        resultsB[2] = googleSheetDataResultsForName[resultNumberB][2];  //group
        resultsB[3] = googleSheetDataResultsForName[resultNumberB][3];  //rawlsian score
        resultsB[4] = googleSheetDataResultsForName[resultNumberB][4];  //utilitarian score
        resultsB[5] = googleSheetDataResultsForName[resultNumberB][5];  //virtue ethics score
        resultsB[6] = googleSheetDataResultsForName[resultNumberB][6];  //neoliberal score
        resultsB[7] = googleSheetDataResultsForName[resultNumberB][7];  //kantian score
        resultsB[8] = googleSheetDataResultsForName[resultNumberB][8];  //centroid X
        resultsB[9] = googleSheetDataResultsForName[resultNumberB][9];  //centroid Y

        Debug.Log(
            "B = " +
            
            resultsB[4].ToString() + " " +
            resultsB[5].ToString() + " " +
            resultsB[6].ToString() + " " +
            resultsB[7].ToString()
            
        );
        if(int.TryParse(resultsB[3], out tryParseResultB))
        {
            highestEthicsSchoolPointsB = Mathf.Max(      int.Parse(resultsB[3]),
                                                     int.Parse(resultsB[4]),
                                                     int.Parse(resultsB[5]),
                                                     int.Parse(resultsB[6]),
                                                     int.Parse(resultsB[7]) );
        }
        else
        {
            highestEthicsSchoolPointsB = 0;
        }        

        radarChartBscript = GameObject.Find("RadarChart B").GetComponent<RadarChart>();

        radarChartBscript.m_Data = new List<float>
            {
                (float.Parse(resultsB[3]) /(float)( highestEthicsSchoolPointsB)),
                (float.Parse(resultsB[4]) / (float)(highestEthicsSchoolPointsB)),
                (float.Parse(resultsB[7]) / (float)(highestEthicsSchoolPointsB)),
                (float.Parse(resultsB[6]) / (float)(highestEthicsSchoolPointsB)),
                (float.Parse(resultsB[5]) / (float)(highestEthicsSchoolPointsB)),
                (float.Parse(resultsB[3]) / (float)(highestEthicsSchoolPointsB))      // added a arbitrary 6th value to list because otherwise radar chart doesn't show value for 5th axis VE
            };
        radarB.SetActive(false);
        radarB.SetActive(true);

        timeTextB.text = resultsB[0];
        rTextB.text = resultsB[3];
        uTextB.text = resultsB[4];
        veTextB.text = resultsB[5];
        kaTextB.text = resultsB[7];
        nlTextB.text = resultsB[6];

        resultNumberTextUILabelB.text = (resultNumberB + 1).ToString();

        StartCoroutine(CalculateAndDisplayHypotenuseLength());
    }
    public IEnumerator CalculateAndDisplayHypotenuseLength()
    {
        yield return new WaitForSeconds(0.1f);
        xDifference = Mathf.Abs(CentroidA.GetComponent<RectTransform>().anchoredPosition.x - CentroidB.GetComponent<RectTransform>().anchoredPosition.x);
        yDifference = Mathf.Abs(CentroidA.GetComponent<RectTransform>().anchoredPosition.y - CentroidB.GetComponent<RectTransform>().anchoredPosition.y);
        x2_plus_y2 = Mathf.Pow(xDifference, 2) + Mathf.Pow(yDifference, 2);
        hypotenuseLength = Mathf.Sqrt(x2_plus_y2);        
        pointsOfDifference.text = hypotenuseLength.ToString("0.0") + " Points of Difference";
        //Debug.Log("Centroid A x coord = " + CentroidA.GetComponent<RectTransform>().anchoredPosition.x.ToString("F0"));
        //Debug.Log("Centroid A y coord = " + CentroidA.GetComponent<RectTransform>().anchoredPosition.y.ToString("F0"));
        //Debug.Log("Centroid B x coord = " + CentroidB.GetComponent<RectTransform>().anchoredPosition.x.ToString("F0"));
        //Debug.Log("Centroid B y coord = " + CentroidB.GetComponent<RectTransform>().anchoredPosition.y.ToString("F0"));
    }
    public void ClearResultsAandB()
    {
        for (int i = 0; i < googleSheetDataResultsForName.Length; i++)
        {
            googleSheetDataResultsForName[i] = new string[10] {"","","","","","","","","",""};
        }
    }

}
