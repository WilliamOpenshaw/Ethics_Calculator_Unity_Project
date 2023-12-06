using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UCharts;
using System;
using System.Linq;

public class GS2UnityDemoScript : MonoBehaviour
{
    public CBCcontroller cbcScript;
    public int[][] onlineTotalChoiceTallies;

    public int[][] allVoteScoresSorted;


    public int[][] topChoiceAndVotes; // top choices 1 - 5 and each one has 3 spots, 0-school 1-choiceNumber 2-voteScore

    public int[][] bottomChoiceAndVotes; // bottom choices 1 - 5 and each one has 3 spots, 0-school 1-choiceNumber 2-voteScore    

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
        onlineTotalChoiceTallies = new int[5][];
        onlineTotalChoiceTallies[0] = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        onlineTotalChoiceTallies[1] = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        onlineTotalChoiceTallies[2] = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        onlineTotalChoiceTallies[3] = new int[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        onlineTotalChoiceTallies[4] = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        topChoiceAndVotes = new int[5][];
        topChoiceAndVotes[0] = new int[3] { 0, 0, 0 };
        topChoiceAndVotes[1] = new int[3] { 0, 0, 0 };
        topChoiceAndVotes[2] = new int[3] { 0, 0, 0 };
        topChoiceAndVotes[3] = new int[3] { 0, 0, 0 };
        topChoiceAndVotes[4] = new int[3] { 0, 0, 0 };

        bottomChoiceAndVotes = new int[5][];
        bottomChoiceAndVotes[0] = new int[3] { 0, 0, 0 }; // 0-ethicalSchool 1-choiceNumber 2-voteScore
        bottomChoiceAndVotes[1] = new int[3] { 0, 0, 0 };
        bottomChoiceAndVotes[2] = new int[3] { 0, 0, 0 };
        bottomChoiceAndVotes[3] = new int[3] { 0, 0, 0 };
        bottomChoiceAndVotes[4] = new int[3] { 0, 0, 0 };

        allVoteScoresSorted = new int[55][];

        for (int i = 0; i <= 54; i++)
        {
            allVoteScoresSorted[i] = new int[3] { 0, 0, 0 };
        }

        timeTextA.text = "x";
        rTextA.text = "x";
        uTextA.text = "x";
        veTextA.text = "x";
        kaTextA.text = "x";
        nlTextA.text = "x";

        timeTextB.text = "x";
        rTextB.text = "x";
        uTextB.text = "x";
        veTextB.text = "x";
        kaTextB.text = "x";
        nlTextB.text = "x";

        currentResultNumber = 0;
        enteredName = "empty";

        googleSheetDataResultsForName = new string[1000][];

        for (int i = 0; i < 1000; i++)
        {
            googleSheetDataResultsForName[i] = new string[10];
        }

        radarA = GameObject.Find("RadarChart A");
        radarB = GameObject.Find("RadarChart B");

        resultANumber = 0;
        resultBNumber = 0;

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
        // 0-Uti. 1-Raw. 2-Vir.Eth. 3-NeoLib 4-Kant // Choices 8-17 each // jagged array that holds tally of how many times each choice is chosen
        AddUpChoiceTallies();
        PlaceAllScoresInArrayAndSort();
        SetTopAndBottomChoicesDisplayText();
    }

    public void AddUpChoiceTallies()
    {
        for (int i = 1; i < 1000; i++)
        {
            if (int.TryParse(txtSheet.GetRowData(i, "u0"), out _))
            {
                onlineTotalChoiceTallies[0][0] += int.Parse(txtSheet.GetRowData(i, "u0"));
                onlineTotalChoiceTallies[0][1] += int.Parse(txtSheet.GetRowData(i, "u1"));
                onlineTotalChoiceTallies[0][2] += int.Parse(txtSheet.GetRowData(i, "u2"));
                onlineTotalChoiceTallies[0][3] += int.Parse(txtSheet.GetRowData(i, "u3"));
                onlineTotalChoiceTallies[0][4] += int.Parse(txtSheet.GetRowData(i, "u4"));
                onlineTotalChoiceTallies[0][5] += int.Parse(txtSheet.GetRowData(i, "u5"));
                onlineTotalChoiceTallies[0][6] += int.Parse(txtSheet.GetRowData(i, "u6"));
                onlineTotalChoiceTallies[0][7] += int.Parse(txtSheet.GetRowData(i, "u7"));
                onlineTotalChoiceTallies[0][8] += int.Parse(txtSheet.GetRowData(i, "u8"));

                onlineTotalChoiceTallies[1][0] += int.Parse(txtSheet.GetRowData(i, "r0"));
                onlineTotalChoiceTallies[1][1] += int.Parse(txtSheet.GetRowData(i, "r1"));
                onlineTotalChoiceTallies[1][2] += int.Parse(txtSheet.GetRowData(i, "r2"));
                onlineTotalChoiceTallies[1][3] += int.Parse(txtSheet.GetRowData(i, "r3"));
                onlineTotalChoiceTallies[1][4] += int.Parse(txtSheet.GetRowData(i, "r4"));
                onlineTotalChoiceTallies[1][5] += int.Parse(txtSheet.GetRowData(i, "r5"));
                onlineTotalChoiceTallies[1][6] += int.Parse(txtSheet.GetRowData(i, "r6"));
                onlineTotalChoiceTallies[1][7] += int.Parse(txtSheet.GetRowData(i, "r7"));
                onlineTotalChoiceTallies[1][8] += int.Parse(txtSheet.GetRowData(i, "r8"));
                onlineTotalChoiceTallies[1][9] += int.Parse(txtSheet.GetRowData(i, "r9"));

                onlineTotalChoiceTallies[2][0] += int.Parse(txtSheet.GetRowData(i, "ve0"));
                onlineTotalChoiceTallies[2][1] += int.Parse(txtSheet.GetRowData(i, "ve1"));
                onlineTotalChoiceTallies[2][2] += int.Parse(txtSheet.GetRowData(i, "ve2"));
                onlineTotalChoiceTallies[2][3] += int.Parse(txtSheet.GetRowData(i, "ve3"));
                onlineTotalChoiceTallies[2][4] += int.Parse(txtSheet.GetRowData(i, "ve4"));
                onlineTotalChoiceTallies[2][5] += int.Parse(txtSheet.GetRowData(i, "ve5"));
                onlineTotalChoiceTallies[2][6] += int.Parse(txtSheet.GetRowData(i, "ve6"));
                onlineTotalChoiceTallies[2][7] += int.Parse(txtSheet.GetRowData(i, "ve7"));
                onlineTotalChoiceTallies[2][8] += int.Parse(txtSheet.GetRowData(i, "ve8"));

                onlineTotalChoiceTallies[3][0] += int.Parse(txtSheet.GetRowData(i, "nl0"));
                onlineTotalChoiceTallies[3][1] += int.Parse(txtSheet.GetRowData(i, "nl1"));
                onlineTotalChoiceTallies[3][2] += int.Parse(txtSheet.GetRowData(i, "nl2"));
                onlineTotalChoiceTallies[3][3] += int.Parse(txtSheet.GetRowData(i, "nl3"));
                onlineTotalChoiceTallies[3][4] += int.Parse(txtSheet.GetRowData(i, "nl4"));
                onlineTotalChoiceTallies[3][5] += int.Parse(txtSheet.GetRowData(i, "nl5"));
                onlineTotalChoiceTallies[3][6] += int.Parse(txtSheet.GetRowData(i, "nl6"));
                onlineTotalChoiceTallies[3][7] += int.Parse(txtSheet.GetRowData(i, "nl7"));
                onlineTotalChoiceTallies[3][8] += int.Parse(txtSheet.GetRowData(i, "nl8"));
                onlineTotalChoiceTallies[3][9] += int.Parse(txtSheet.GetRowData(i, "nl9"));
                onlineTotalChoiceTallies[3][10] += int.Parse(txtSheet.GetRowData(i, "nl10"));
                onlineTotalChoiceTallies[3][11] += int.Parse(txtSheet.GetRowData(i, "nl11"));
                onlineTotalChoiceTallies[3][12] += int.Parse(txtSheet.GetRowData(i, "nl12"));
                onlineTotalChoiceTallies[3][13] += int.Parse(txtSheet.GetRowData(i, "nl13"));
                onlineTotalChoiceTallies[3][14] += int.Parse(txtSheet.GetRowData(i, "nl14"));
                onlineTotalChoiceTallies[3][15] += int.Parse(txtSheet.GetRowData(i, "nl15"));
                onlineTotalChoiceTallies[3][16] += int.Parse(txtSheet.GetRowData(i, "nl16"));
                onlineTotalChoiceTallies[3][17] += int.Parse(txtSheet.GetRowData(i, "nl17"));

                onlineTotalChoiceTallies[4][0] += int.Parse(txtSheet.GetRowData(i, "k0"));
                onlineTotalChoiceTallies[4][1] += int.Parse(txtSheet.GetRowData(i, "k1"));
                onlineTotalChoiceTallies[4][2] += int.Parse(txtSheet.GetRowData(i, "k2"));
                onlineTotalChoiceTallies[4][3] += int.Parse(txtSheet.GetRowData(i, "k3"));
                onlineTotalChoiceTallies[4][4] += int.Parse(txtSheet.GetRowData(i, "k4"));
                onlineTotalChoiceTallies[4][5] += int.Parse(txtSheet.GetRowData(i, "k5"));
                onlineTotalChoiceTallies[4][6] += int.Parse(txtSheet.GetRowData(i, "k6"));
                onlineTotalChoiceTallies[4][7] += int.Parse(txtSheet.GetRowData(i, "k7"));
                onlineTotalChoiceTallies[4][8] += int.Parse(txtSheet.GetRowData(i, "k8"));
            }
        }
    }

    public void PlaceAllScoresInArrayAndSort() //one sorted and one not sorted
    {
        for (int i = 0; i <= 8; i++)
        {
            allVoteScoresSorted[i][2] = onlineTotalChoiceTallies[0][i];
            allVoteScoresSorted[i][1] = i;
            allVoteScoresSorted[i][0] = 0;
        }

        for (int i = 9; i <= 18; i++)
        {
            allVoteScoresSorted[i][2] = onlineTotalChoiceTallies[1][i - 9];
            allVoteScoresSorted[i][1] = i - 9;
            allVoteScoresSorted[i][0] = 1;
        }

        for (int i = 19; i <= 27; i++)
        {
            allVoteScoresSorted[i][2] = onlineTotalChoiceTallies[2][i - 19];
            allVoteScoresSorted[i][1] = i - 19;
            allVoteScoresSorted[i][0] = 2;
        }

        for (int i = 28; i <= 45; i++)
        {
            allVoteScoresSorted[i][2] = onlineTotalChoiceTallies[3][i - 28];
            allVoteScoresSorted[i][1] = i - 28;
            allVoteScoresSorted[i][0] = 3;
        }

        for (int i = 46; i <= 54; i++)
        {
            allVoteScoresSorted[i][2] = onlineTotalChoiceTallies[4][i - 46];
            allVoteScoresSorted[i][1] = i - 46;
            allVoteScoresSorted[i][0] = 4;
        }

        var columnIdx = 2;
        Array.Sort(allVoteScoresSorted, (x, y) => x[columnIdx].CompareTo(y[columnIdx]));

        // Check sort array output
        /*
        for (int i = 0; i <= 54; i++)
        {
            Debug.Log("Choice Place " + i.ToString() + " is school " + allVoteScoresSorted[i][0].ToString() + ",    choice " + allVoteScoresSorted[i][1].ToString() + ",  score " + allVoteScoresSorted[i][2].ToString());
        }
        */
    }

    public void SetTopAndBottomChoicesDisplayText()
    {

        switch (allVoteScoresSorted[54][0])
        {
            case 0:
                topChoice1.text = cbcScript.utilitarianChoices[allVoteScoresSorted[54][1]] + " (Utilitarian) " + allVoteScoresSorted[54][2].ToString() + "↑";
                break;
            case 1:
                topChoice1.text = cbcScript.rawlsianChoices[allVoteScoresSorted[54][1]] + " (Rawlsian) " + allVoteScoresSorted[54][2].ToString() + "↑";
                break;
            case 2:
                topChoice1.text = cbcScript.virtueEthicsChoices[allVoteScoresSorted[54][1]] + " (Virtue Ethics) " + allVoteScoresSorted[54][2].ToString() + "↑";
                break;
            case 3:
                topChoice1.text = cbcScript.neoliberalChoices[allVoteScoresSorted[54][1]] + " (Neoliberal) " + allVoteScoresSorted[54][2].ToString() + "↑";
                break;
            case 4:
                topChoice1.text = cbcScript.kantianChoices[allVoteScoresSorted[54][1]] + " (Kantian) " + allVoteScoresSorted[54][2].ToString() + "↑";
                break;
        }

        switch (allVoteScoresSorted[53][0])
        {
            case 0:
                topChoice2.text = cbcScript.utilitarianChoices[allVoteScoresSorted[53][1]] + " (Utilitarian) " + allVoteScoresSorted[53][2].ToString() + "↑";
                break;
            case 1:
                topChoice2.text = cbcScript.rawlsianChoices[allVoteScoresSorted[53][1]] + " (Rawlsian) " + allVoteScoresSorted[53][2].ToString() + "↑";
                break;
            case 2:
                topChoice2.text = cbcScript.virtueEthicsChoices[allVoteScoresSorted[53][1]] + " (Virtue Ethics) " + allVoteScoresSorted[53][2].ToString() + "↑";
                break;
            case 3:
                topChoice2.text = cbcScript.neoliberalChoices[allVoteScoresSorted[53][1]] + " (Neoliberal) " + allVoteScoresSorted[53][2].ToString() + "↑";
                break;
            case 4:
                topChoice2.text = cbcScript.kantianChoices[allVoteScoresSorted[53][1]] + " (Kantian) " + allVoteScoresSorted[53][2].ToString() + "↑";
                break;
        }

        switch (allVoteScoresSorted[52][0])
        {
            case 0:
                topChoice3.text = cbcScript.utilitarianChoices[allVoteScoresSorted[52][1]] + " (Utilitarian) " + allVoteScoresSorted[52][2].ToString() + "↑";
                break;
            case 1:
                topChoice3.text = cbcScript.rawlsianChoices[allVoteScoresSorted[52][1]] + " (Rawlsian) " + allVoteScoresSorted[52][2].ToString() + "↑";
                break;
            case 2:
                topChoice3.text = cbcScript.virtueEthicsChoices[allVoteScoresSorted[52][1]] + " (Virtue Ethics) " + allVoteScoresSorted[52][2].ToString() + "↑";
                break;
            case 3:
                topChoice3.text = cbcScript.neoliberalChoices[allVoteScoresSorted[52][1]] + " (Neoliberal) " + allVoteScoresSorted[52][2].ToString() + "↑";
                break;
            case 4:
                topChoice3.text = cbcScript.kantianChoices[allVoteScoresSorted[52][1]] + " (Kantian) " + allVoteScoresSorted[52][2].ToString() + "↑";
                break;
        }

        switch (allVoteScoresSorted[51][0])
        {
            case 0:
                topChoice4.text = cbcScript.utilitarianChoices[allVoteScoresSorted[51][1]] + " (Utilitarian) " + allVoteScoresSorted[51][2].ToString() + "↑";
                break;
            case 1:
                topChoice4.text = cbcScript.rawlsianChoices[allVoteScoresSorted[51][1]] + " (Rawlsian) " + allVoteScoresSorted[51][2].ToString() + "↑";
                break;
            case 2:
                topChoice4.text = cbcScript.virtueEthicsChoices[allVoteScoresSorted[51][1]] + " (Virtue Ethics) " + allVoteScoresSorted[51][2].ToString() + "↑";
                break;
            case 3:
                topChoice4.text = cbcScript.neoliberalChoices[allVoteScoresSorted[51][1]] + " (Neoliberal) " + allVoteScoresSorted[51][2].ToString() + "↑";
                break;
            case 4:
                topChoice4.text = cbcScript.kantianChoices[allVoteScoresSorted[51][1]] + " (Kantian) " + allVoteScoresSorted[51][2].ToString() + "↑";
                break;
        }

        switch (allVoteScoresSorted[50][0])
        {
            case 0:
                topChoice5.text = cbcScript.utilitarianChoices[allVoteScoresSorted[50][1]] + " (Utilitarian) " + allVoteScoresSorted[50][2].ToString() + "↑";
                break;
            case 1:
                topChoice5.text = cbcScript.rawlsianChoices[allVoteScoresSorted[50][1]] + " (Rawlsian) " + allVoteScoresSorted[50][2].ToString() + "↑";
                break;
            case 2:
                topChoice5.text = cbcScript.virtueEthicsChoices[allVoteScoresSorted[50][1]] + " (Virtue Ethics) " + allVoteScoresSorted[50][2].ToString() + "↑";
                break;
            case 3:
                topChoice5.text = cbcScript.neoliberalChoices[allVoteScoresSorted[50][1]] + " (Neoliberal) " + allVoteScoresSorted[50][2].ToString() + "↑";
                break;
            case 4:
                topChoice5.text = cbcScript.kantianChoices[allVoteScoresSorted[50][1]] + " (Kantian) " + allVoteScoresSorted[50][2].ToString() + "↑";
                break;
        }

        // BOTTOM 5

        switch (allVoteScoresSorted[0][0])
        {
            case 0:
                bottomChoice5.text = cbcScript.utilitarianChoices[allVoteScoresSorted[0][1]] + " (Utilitarian) " + allVoteScoresSorted[0][2].ToString() + "↑";
                break;
            case 1:
                bottomChoice5.text = cbcScript.rawlsianChoices[allVoteScoresSorted[0][1]] + " (Rawlsian) " + allVoteScoresSorted[0][2].ToString() + "↑";
                break;
            case 2:
                bottomChoice5.text = cbcScript.virtueEthicsChoices[allVoteScoresSorted[0][1]] + " (Virtue Ethics) " + allVoteScoresSorted[0][2].ToString() + "↑";
                break;
            case 3:
                bottomChoice5.text = cbcScript.neoliberalChoices[allVoteScoresSorted[0][1]] + " (Neoliberal) " + allVoteScoresSorted[0][2].ToString() + "↑";
                break;
            case 4:
                bottomChoice5.text = cbcScript.kantianChoices[allVoteScoresSorted[0][1]] + " (Kantian) " + allVoteScoresSorted[0][2].ToString() + "↑";
                break;
        }

        switch (allVoteScoresSorted[1][0])
        {
            case 0:
                bottomChoice4.text = cbcScript.utilitarianChoices[allVoteScoresSorted[1][1]] + " (Utilitarian) " + allVoteScoresSorted[1][2].ToString() + "↑";
                break;
            case 1:
                bottomChoice4.text = cbcScript.rawlsianChoices[allVoteScoresSorted[1][1]] + " (Rawlsian) " + allVoteScoresSorted[1][2].ToString() + "↑";
                break;
            case 2:
                bottomChoice4.text = cbcScript.virtueEthicsChoices[allVoteScoresSorted[1][1]] + " (Virtue Ethics) " + allVoteScoresSorted[1][2].ToString() + "↑";
                break;
            case 3:
                bottomChoice4.text = cbcScript.neoliberalChoices[allVoteScoresSorted[1][1]] + " (Neoliberal) " + allVoteScoresSorted[1][2].ToString() + "↑";
                break;
            case 4:
                bottomChoice4.text = cbcScript.kantianChoices[allVoteScoresSorted[1][1]] + " (Kantian) " + allVoteScoresSorted[1][2].ToString() + "↑";
                break;
        }

        switch (allVoteScoresSorted[2][0])
        {
            case 0:
                bottomChoice3.text = cbcScript.utilitarianChoices[allVoteScoresSorted[2][1]] + " (Utilitarian) " + allVoteScoresSorted[2][2].ToString() + "↑";
                break;
            case 1:
                bottomChoice3.text = cbcScript.rawlsianChoices[allVoteScoresSorted[2][1]] + " (Rawlsian) " + allVoteScoresSorted[2][2].ToString() + "↑";
                break;
            case 2:
                bottomChoice3.text = cbcScript.virtueEthicsChoices[allVoteScoresSorted[2][1]] + " (Virtue Ethics) " + allVoteScoresSorted[2][2].ToString() + "↑";
                break;
            case 3:
                bottomChoice3.text = cbcScript.neoliberalChoices[allVoteScoresSorted[2][1]] + " (Neoliberal) " + allVoteScoresSorted[2][2].ToString() + "↑";
                break;
            case 4:
                bottomChoice3.text = cbcScript.kantianChoices[allVoteScoresSorted[2][1]] + " (Kantian) " + allVoteScoresSorted[2][2].ToString() + "↑";
                break;
        }

        switch (allVoteScoresSorted[3][0])
        {
            case 0:
                bottomChoice2.text = cbcScript.utilitarianChoices[allVoteScoresSorted[3][1]] + " (Utilitarian) " + allVoteScoresSorted[3][2].ToString() + "↑";
                break;
            case 1:
                bottomChoice2.text = cbcScript.rawlsianChoices[allVoteScoresSorted[3][1]] + " (Rawlsian) " + allVoteScoresSorted[3][2].ToString() + "↑";
                break;
            case 2:
                bottomChoice2.text = cbcScript.virtueEthicsChoices[allVoteScoresSorted[3][1]] + " (Virtue Ethics) " + allVoteScoresSorted[3][2].ToString() + "↑";
                break;
            case 3:
                bottomChoice2.text = cbcScript.neoliberalChoices[allVoteScoresSorted[3][1]] + " (Neoliberal) " + allVoteScoresSorted[3][2].ToString() + "↑";
                break;
            case 4:
                bottomChoice2.text = cbcScript.kantianChoices[allVoteScoresSorted[3][1]] + " (Kantian) " + allVoteScoresSorted[3][2].ToString() + "↑";
                break;
        }

        switch (allVoteScoresSorted[4][0])
        {
            case 0:
                bottomChoice1.text = cbcScript.utilitarianChoices[allVoteScoresSorted[4][1]] + " (Utilitarian) " + allVoteScoresSorted[4][2].ToString() + "↑";
                break;
            case 1:
                bottomChoice1.text = cbcScript.rawlsianChoices[allVoteScoresSorted[4][1]] + " (Rawlsian) " + allVoteScoresSorted[4][2].ToString() + "↑";
                break;
            case 2:
                bottomChoice1.text = cbcScript.virtueEthicsChoices[allVoteScoresSorted[4][1]] + " (Virtue Ethics) " + allVoteScoresSorted[4][2].ToString() + "↑";
                break;
            case 3:
                bottomChoice1.text = cbcScript.neoliberalChoices[allVoteScoresSorted[4][1]] + " (Neoliberal) " + allVoteScoresSorted[4][2].ToString() + "↑";
                break;
            case 4:
                bottomChoice1.text = cbcScript.kantianChoices[allVoteScoresSorted[4][1]] + " (Kantian) " + allVoteScoresSorted[4][2].ToString() + "↑";
                break;
        }
    }

    public void OpenChoiceSitePage(int rank)
    {
        switch (allVoteScoresSorted[rank][0])
        {
            case 0:
                Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/utilitarianism/utilitarian-choices/"
                + (allVoteScoresSorted[rank][1] + 1).ToString() +
                "-utilitarian-choice");
                break;
            case 1:
                Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/rawlsian-ethics/rawlsian-choices/"
                + (allVoteScoresSorted[rank][1] + 1).ToString() +
                "-rawlsian-choice");
                break;
            case 2:
                Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/virtue-ethics/virtue-ethics-choices/"
                + (allVoteScoresSorted[rank][1] + 1).ToString() +
                "virtue-ethics-choice");
                break;
            case 3:
                Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/neoliberal-ethics/neoliberal-choices/"
                + (allVoteScoresSorted[rank][1] + 1).ToString() +
                "-neoliberal-choice");
                break;
            case 4:
                Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/kantian-ethics/kantian-choices/"
                + (allVoteScoresSorted[rank][1] + 1).ToString() +
                "-kantian-choice");
                break;
        }
    }

    public void searchNameResults(string typedName)
    {
        radarB.SetActive(true);
        radarA.SetActive(true);

        resultANumber = 0;
        resultBNumber = 1;
        ClearResultsAandB();

        timeTextA.text = "x";
        rTextA.text = "x";
        uTextA.text = "x";
        veTextA.text = "x";
        kaTextA.text = "x";
        nlTextA.text = "x";

        timeTextB.text = "x";
        rTextB.text = "x";
        uTextB.text = "x";
        veTextB.text = "x";
        kaTextB.text = "x";
        nlTextB.text = "x";

        resultNumberTextUILabelA.text = "x";
        resultNumberTextUILabelB.text = "x";

        resultsA = new string[] { "", "", "", "", "", "", "", "", "", "" };
        resultsB = new string[] { "", "", "", "", "", "", "", "", "", "" };

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
            if (txtSheet.GetRowData(i.ToString(), "Timestamp") == "")
            {
                break;
            }
        }
        numberOfTotalResultsText.text = "There are " + currentResultNumber + " results for this name.";

        ChangeResultsA(resultANumber);
        ChangeResultsB(resultBNumber);
        radarB.SetActive(false);
        radarA.SetActive(false);
        radarB.SetActive(true);
        radarA.SetActive(true);
        StartCoroutine(CalculateAndDisplayHypotenuseLength());
    }
    public void SelectionAIncrease()
    {
        if (resultANumber >= currentResultNumber - 1)
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
        if (resultANumber <= 0)
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
        if (resultBNumber <= 0)
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
        if (int.TryParse(resultsA[3], out _))
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

        timeTextA.text = resultsA[0];
        rTextA.text = resultsA[3];
        uTextA.text = resultsA[4];
        veTextA.text = resultsA[5];
        kaTextA.text = resultsA[7];
        nlTextA.text = resultsA[6];

        resultNumberTextUILabelA.text = (resultNumberA).ToString();
        radarB.SetActive(false);
        radarA.SetActive(false);
        radarB.SetActive(true);
        radarA.SetActive(true);
        StartCoroutine(CalculateAndDisplayHypotenuseLength());
    }

    public void ChangeResultsB(int resultNumberB)
    {
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

            resultsB[3].ToString() + " " +
            resultsB[4].ToString() + " " +
            resultsB[5].ToString() + " " +
            resultsB[6].ToString() + " " +
            resultsB[7].ToString()

        );
        if (int.TryParse(resultsB[3], out tryParseResultB))
        {
            highestEthicsSchoolPointsB = Mathf.Max(int.Parse(resultsB[3]),
                                                     int.Parse(resultsB[4]),
                                                     int.Parse(resultsB[5]),
                                                     int.Parse(resultsB[6]),
                                                     int.Parse(resultsB[7]));
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

        timeTextB.text = resultsB[0];
        rTextB.text = resultsB[3];
        uTextB.text = resultsB[4];
        veTextB.text = resultsB[5];
        kaTextB.text = resultsB[7];
        nlTextB.text = resultsB[6];

        resultNumberTextUILabelB.text = (resultNumberB).ToString();
        radarB.SetActive(false);
        radarA.SetActive(false);
        radarB.SetActive(true);
        radarA.SetActive(true);
        StartCoroutine(CalculateAndDisplayHypotenuseLength());
    }
    public IEnumerator CalculateAndDisplayHypotenuseLength()
    {
        yield return new WaitForSeconds(0.5f);
        xDifference = Mathf.Abs(CentroidA.GetComponent<RectTransform>().anchoredPosition.x - CentroidB.GetComponent<RectTransform>().anchoredPosition.x);
        yDifference = Mathf.Abs(CentroidA.GetComponent<RectTransform>().anchoredPosition.y - CentroidB.GetComponent<RectTransform>().anchoredPosition.y);
        x2_plus_y2 = Mathf.Pow(xDifference, 2) + Mathf.Pow(yDifference, 2);
        hypotenuseLength = Mathf.Sqrt(x2_plus_y2);
        pointsOfDifference.text = hypotenuseLength.ToString("0.0") + " Points of Difference";
    }
    public void ClearResultsAandB()
    {
        for (int i = 0; i < googleSheetDataResultsForName.Length; i++)
        {
            googleSheetDataResultsForName[i] = new string[10] { "", "", "", "", "", "", "", "", "", "" };
        }
    }

}
