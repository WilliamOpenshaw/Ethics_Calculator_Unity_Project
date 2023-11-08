//0.1.8

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UCharts;
using System;
using Random = UnityEngine.Random;

public class CBCcontroller : MonoBehaviour
{
    public GameObject[] verticeIndicatorsCBC;
    public DataSender dataSenderScript;
    public TextMeshProUGUI dayXmorningText;
    public TextMeshProUGUI dayXafternoonText;
    public TextMeshProUGUI dayXeveningText;
    public TextMeshProUGUI dayYmorningText;
    public TextMeshProUGUI dayYafternoonText;
    public TextMeshProUGUI dayYeveningText;
    public TextMeshProUGUI dayZmorningText;
    public TextMeshProUGUI dayZafternoonText;
    public TextMeshProUGUI dayZeveningText;

    public TextMeshProUGUI utilitarianNumberDisplay;
    public TextMeshProUGUI neoliberalNumberDisplay;
    public TextMeshProUGUI kantianNumberDisplay;
    public TextMeshProUGUI virtueethicsNumberDisplay;
    public TextMeshProUGUI rawlsianNumberDisplay;

    public int dayXmorningCurrentEthicsSchool;
    public int dayXafternoonCurrentEthicsSchool;
    public int dayXeveningCurrentEthicsSchool;
    public int dayYmorningCurrentEthicsSchool;
    public int dayYafternoonCurrentEthicsSchool;
    public int dayYeveningCurrentEthicsSchool;
    public int dayZmorningCurrentEthicsSchool;
    public int dayZafternoonCurrentEthicsSchool;
    public int dayZeveningCurrentEthicsSchool;

    public int dayXmorningCurrentChoiceNumber;
    public int dayXafternoonCurrentChoiceNumber;
    public int dayXeveningCurrentChoiceNumber;
    public int dayYmorningCurrentChoiceNumber;
    public int dayYafternoonCurrentChoiceNumber;
    public int dayYeveningCurrentChoiceNumber;
    public int dayZmorningCurrentChoiceNumber;
    public int dayZafternoonCurrentChoiceNumber;
    public int dayZeveningCurrentChoiceNumber;

    public int currentChoiceNumber;

    public string[] utilitarianChoices;
    public string[] rawlsianChoices;
    public string[] neoliberalChoices;
    public string[] virtueEthicsChoices;
    public string[] kantianChoices;

    public int utilitarianPoints;
    public int rawlsianPoints;
    public int neoliberalPoints;
    public int virtueEthicsPoints;
    public int kantianPoints;

    public int currentEthicsSchoolNumber;

    public string currentEthicsChoiceTextString;

    public int currentRoundNumber;

    public string userName;
    public string userGroup;
    public TextMeshProUGUI userNameTextDisplay;
    public TextMeshProUGUI userGroupTextDisplay;
    public TextMeshProUGUI weekNumberTextDisplay;
    public GameObject endScreen;
    public GameObject cbcCards;
    public Slider sliderRtoVE;
    public Slider sliderUtoR;
    public Slider sliderKtoU;
    public Slider sliderVEtoNL;
    public Slider sliderNLtoK;
    public Slider sliderUtoVE;
    public Slider sliderVEtoK;
    public Slider sliderKtoR;
    public Slider sliderRtoNL;
    public Slider sliderNLtoU;

    public Slider sliderRtoVE2;
    public Slider sliderUtoR2;
    public Slider sliderKtoU2;
    public Slider sliderVEtoNL2;
    public Slider sliderNLtoK2;
    public Slider sliderUtoVE2;
    public Slider sliderVEtoK2;
    public Slider sliderKtoR2;
    public Slider sliderRtoNL2;
    public Slider sliderNLtoU2;

    public Slider sliderRtoVE3;
    public Slider sliderUtoR3;
    public Slider sliderKtoU3;
    public Slider sliderVEtoNL3;
    public Slider sliderNLtoK3;
    public Slider sliderUtoVE3;
    public Slider sliderVEtoK3;
    public Slider sliderKtoR3;
    public Slider sliderRtoNL3;
    public Slider sliderNLtoU3;

    public Slider sliderRtoVE4;
    public Slider sliderUtoR4;
    public Slider sliderKtoU4;
    public Slider sliderVEtoNL4;
    public Slider sliderNLtoK4;
    public Slider sliderUtoVE4;
    public Slider sliderVEtoK4;
    public Slider sliderKtoR4;
    public Slider sliderRtoNL4;
    public Slider sliderNLtoU4;
    public GameObject statPanel;
    public int lowestEthicsSchoolScore;
    public TextMeshProUGUI rawlsianPercentage;
    public TextMeshProUGUI utilitarianPercentage;
    public TextMeshProUGUI virtueEthicsPercentage;
    public TextMeshProUGUI neoliberalPercentage;
    public TextMeshProUGUI kantianPercentage;

    public TextMeshProUGUI rawlsianPercentage2;
    public TextMeshProUGUI utilitarianPercentage2;
    public TextMeshProUGUI virtueEthicsPercentage2;
    public TextMeshProUGUI neoliberalPercentage2;
    public TextMeshProUGUI kantianPercentage2;

    public TextMeshProUGUI rawlsianPercentage3;
    public TextMeshProUGUI utilitarianPercentage3;
    public TextMeshProUGUI virtueEthicsPercentage3;
    public TextMeshProUGUI neoliberalPercentage3;
    public TextMeshProUGUI kantianPercentage3;

    public TextMeshProUGUI rawlsianPercentage4;
    public TextMeshProUGUI utilitarianPercentage4;
    public TextMeshProUGUI virtueEthicsPercentage4;
    public TextMeshProUGUI neoliberalPercentage4;
    public TextMeshProUGUI kantianPercentage4;

    public TextMeshProUGUI rawlsianPercentage5;
    public TextMeshProUGUI utilitarianPercentage5;
    public TextMeshProUGUI virtueEthicsPercentage5;
    public TextMeshProUGUI neoliberalPercentage5;
    public TextMeshProUGUI kantianPercentage5;

    public TextMeshProUGUI rawlsianPercentage6;
    public TextMeshProUGUI utilitarianPercentage6;
    public TextMeshProUGUI virtueEthicsPercentage6;
    public TextMeshProUGUI neoliberalPercentage6;
    public TextMeshProUGUI kantianPercentage6;

    public TextMeshProUGUI R_VE_Percentage;
    public TextMeshProUGUI R_NL_Percentage;
    public TextMeshProUGUI U_R_Percentage;
    public TextMeshProUGUI U_VE_Percentage;
    public TextMeshProUGUI K_U_Percentage;
    public TextMeshProUGUI K_R_Percentage;
    public TextMeshProUGUI VE_NL_Percentage;
    public TextMeshProUGUI VE_K_Percentage;
    public TextMeshProUGUI NL_K_Percentage;
    public TextMeshProUGUI NL_U_Percentage;
    public TextMeshProUGUI VE_R_Percentage;
    public TextMeshProUGUI NL_R_Percentage;
    public TextMeshProUGUI R_U_Percentage;
    public TextMeshProUGUI VE_U_Percentage;
    public TextMeshProUGUI U_K_Percentage;
    public TextMeshProUGUI R_K_Percentage;
    public TextMeshProUGUI NL_VE_Percentage;
    public TextMeshProUGUI K_VE_Percentage;
    public TextMeshProUGUI K_NL_Percentage;
    public TextMeshProUGUI U_NL_Percentage;

    public TextMeshProUGUI numberOfWeeksAtEndTextDisplay;
    public int totalEthicsSchoolPoints;
    public RadarChart radarScript;
    public GameObject radarChartObject;
    public GameObject radarRawlsianLabel;
    public GameObject radarUtilitarianLabel;
    public GameObject radarKantianLabel;
    public GameObject radarNeoliberalLabel;
    public GameObject radarVirtueEthicsLabel;
    public int highestEthicsSchoolPoints;

    public TextMeshProUGUI resultReferenceDisplayText;
    public int resultNumber;
    public string[] resultStrings;
    public string[] resultTimes;

    public int[] rolledChoices;

    public bool choiceRolledRecently;

    public int rolledChoicePlaceSaver;

    public int runsOfDoWhileChoiceRollLoop;

    public TextMeshProUGUI loadingText;

    public GameObject grayLoadingBackground;
    public float centroidCoordinateX;
    public float centroidCoordinateY;
    public GameObject centroidPoint;

    void Start()
    {
        utilitarianChoices = new string[7];
        rawlsianChoices = new string[7];
        neoliberalChoices = new string[12];
        virtueEthicsChoices = new string[6];
        kantianChoices = new string[6];

        rolledChoices = new int[34];

        choiceRolledRecently = false;

        rolledChoicePlaceSaver = 0;

        runsOfDoWhileChoiceRollLoop = 0;

        utilitarianPoints = 0;
        rawlsianPoints = 0;
        neoliberalPoints = 0;
        virtueEthicsPoints = 0;
        kantianPoints = 0;

        currentRoundNumber = 1;

        SetUpStrings();

        AssignText();
        statPanel.SetActive(false);

        resultNumber = 0;
        resultStrings = new string[10];
        resultTimes = new string[10];

        grayLoadingBackground.SetActive(false);

        verticeIndicatorsCBC = new GameObject[5];
        
    }
    public void SetName(string enteredName)
    {
        userName = enteredName;
        userNameTextDisplay.text = userName;
    }
    public void SetGroup(string enteredGroup)
    {
        userGroup = enteredGroup;
        userGroupTextDisplay.text = userGroup;
    }
    public void AssignText()
    {
        AssignEthicsArrayandChoice();
        dayXmorningText.text = currentEthicsChoiceTextString;
        dayXmorningCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayXmorningCurrentChoiceNumber = currentChoiceNumber;

        AssignEthicsArrayandChoice();
        dayXafternoonText.text = currentEthicsChoiceTextString;
        dayXafternoonCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayXafternoonCurrentChoiceNumber = currentChoiceNumber;

        AssignEthicsArrayandChoice();
        dayXeveningText.text = currentEthicsChoiceTextString;
        dayXeveningCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayXeveningCurrentChoiceNumber = currentChoiceNumber;

        AssignEthicsArrayandChoice();
        dayYmorningText.text = currentEthicsChoiceTextString;
        dayYmorningCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayYmorningCurrentChoiceNumber = currentChoiceNumber;

        AssignEthicsArrayandChoice();
        dayYafternoonText.text = currentEthicsChoiceTextString;
        dayYafternoonCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayYafternoonCurrentChoiceNumber = currentChoiceNumber;

        AssignEthicsArrayandChoice();
        dayYeveningText.text = currentEthicsChoiceTextString;
        dayYeveningCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayYeveningCurrentChoiceNumber = currentChoiceNumber;

        AssignEthicsArrayandChoice();
        dayZmorningText.text = currentEthicsChoiceTextString;
        dayZmorningCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayZmorningCurrentChoiceNumber = currentChoiceNumber;

        AssignEthicsArrayandChoice();
        dayZafternoonText.text = currentEthicsChoiceTextString;
        dayZafternoonCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayZafternoonCurrentChoiceNumber = currentChoiceNumber;

        AssignEthicsArrayandChoice();
        dayZeveningText.text = currentEthicsChoiceTextString;
        dayZeveningCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayZeveningCurrentChoiceNumber = currentChoiceNumber;

        EndScreenCheck();
        RefreshPointDisplay();
    }
    public void RefreshPointDisplay()
    {
        utilitarianNumberDisplay.text = utilitarianPoints.ToString();
        rawlsianNumberDisplay.text = rawlsianPoints.ToString();
        neoliberalNumberDisplay.text = neoliberalPoints.ToString();
        virtueethicsNumberDisplay.text = virtueEthicsPoints.ToString();
        kantianNumberDisplay.text = kantianPoints.ToString();
        weekNumberTextDisplay.text = currentRoundNumber.ToString();
    }
    public void ChooseDayX()
    {
        StartCoroutine(ChoiceTransitionWait());

        PlusPoints(dayXmorningCurrentEthicsSchool, dayXmorningCurrentChoiceNumber);
        PlusPoints(dayXafternoonCurrentEthicsSchool, dayXafternoonCurrentChoiceNumber);
        PlusPoints(dayXeveningCurrentEthicsSchool, dayXeveningCurrentChoiceNumber);

        MinusPoints(dayYmorningCurrentEthicsSchool, dayYmorningCurrentChoiceNumber);
        MinusPoints(dayYafternoonCurrentEthicsSchool, dayYafternoonCurrentChoiceNumber);
        MinusPoints(dayYeveningCurrentEthicsSchool, dayYeveningCurrentChoiceNumber);
        MinusPoints(dayZmorningCurrentEthicsSchool, dayZmorningCurrentChoiceNumber);
        MinusPoints(dayZafternoonCurrentEthicsSchool, dayZafternoonCurrentChoiceNumber);
        MinusPoints(dayZeveningCurrentEthicsSchool, dayZeveningCurrentChoiceNumber);
        currentRoundNumber += 1;
        AssignText();
    }
    public void ChooseDayY()
    {
        StartCoroutine(ChoiceTransitionWait());

        MinusPoints(dayXmorningCurrentEthicsSchool, dayXmorningCurrentChoiceNumber);
        MinusPoints(dayXafternoonCurrentEthicsSchool, dayXafternoonCurrentChoiceNumber);
        MinusPoints(dayXeveningCurrentEthicsSchool, dayXeveningCurrentChoiceNumber);

        PlusPoints(dayYmorningCurrentEthicsSchool, dayYmorningCurrentChoiceNumber);
        PlusPoints(dayYafternoonCurrentEthicsSchool, dayYafternoonCurrentChoiceNumber);
        PlusPoints(dayYeveningCurrentEthicsSchool, dayYeveningCurrentChoiceNumber);

        MinusPoints(dayZmorningCurrentEthicsSchool, dayZmorningCurrentChoiceNumber);
        MinusPoints(dayZafternoonCurrentEthicsSchool, dayZafternoonCurrentChoiceNumber);
        MinusPoints(dayZeveningCurrentEthicsSchool, dayZeveningCurrentChoiceNumber);
        currentRoundNumber += 1;
        AssignText();
    }
    public void ChooseDayZ()
    {
        StartCoroutine(ChoiceTransitionWait());

        MinusPoints(dayXmorningCurrentEthicsSchool, dayXmorningCurrentChoiceNumber);
        MinusPoints(dayXafternoonCurrentEthicsSchool, dayXafternoonCurrentChoiceNumber);
        MinusPoints(dayXeveningCurrentEthicsSchool, dayXeveningCurrentChoiceNumber);
        MinusPoints(dayYmorningCurrentEthicsSchool, dayYmorningCurrentChoiceNumber);
        MinusPoints(dayYafternoonCurrentEthicsSchool, dayYafternoonCurrentChoiceNumber);
        MinusPoints(dayYeveningCurrentEthicsSchool, dayYeveningCurrentChoiceNumber);

        PlusPoints(dayZmorningCurrentEthicsSchool, dayZmorningCurrentChoiceNumber);
        PlusPoints(dayZafternoonCurrentEthicsSchool, dayZafternoonCurrentChoiceNumber);
        PlusPoints(dayZeveningCurrentEthicsSchool, dayZeveningCurrentChoiceNumber);
        currentRoundNumber += 1;
        AssignText();
    }

    public IEnumerator ChoiceTransitionWait()
    {
        loadingText.text = "Loading";
        yield return new WaitForSeconds(0.05f);
        loadingText.text = "Loading.";
        yield return new WaitForSeconds(0.05f);
        loadingText.text = "Loading..";
        yield return new WaitForSeconds(0.05f);
        loadingText.text = "Loading...";
        yield return new WaitForSeconds(0.05f);
        loadingText.text = "Loading";

        yield return new WaitForSeconds(0.05f);
        grayLoadingBackground.SetActive(false);
    }
    public void AssignEthicsArrayandChoice()
    {
        do
        {
            choiceRolledRecently = false;
            currentEthicsSchoolNumber = Random.Range(0, 5);
            switch (currentEthicsSchoolNumber)
            {
                case 0:
                    currentChoiceNumber = Random.Range(0, 7);
                    currentEthicsChoiceTextString = utilitarianChoices[currentChoiceNumber];
                    break;
                case 1:
                    currentChoiceNumber = Random.Range(0, 6);
                    currentEthicsChoiceTextString = rawlsianChoices[currentChoiceNumber];
                    break;
                case 2:
                    currentChoiceNumber = Random.Range(0, 6);
                    currentEthicsChoiceTextString = virtueEthicsChoices[currentChoiceNumber];
                    break;
                case 3:
                    currentChoiceNumber = Random.Range(0, 12);
                    currentEthicsChoiceTextString = neoliberalChoices[currentChoiceNumber];
                    break;
                case 4:
                    currentChoiceNumber = Random.Range(0, 6);
                    currentEthicsChoiceTextString = kantianChoices[currentChoiceNumber];
                    break;
            }

            for (int i = 0; i < rolledChoices.Length; i += 2)
            {
                if (rolledChoices[i] == currentEthicsSchoolNumber
                    &&
                    rolledChoices[i + 1] == currentChoiceNumber)
                {
                    choiceRolledRecently = true;
                }
            }

            runsOfDoWhileChoiceRollLoop += 1;

        } while (choiceRolledRecently == true);

        choiceRolledRecently = false;

        rolledChoices[rolledChoicePlaceSaver] = currentEthicsSchoolNumber;
        rolledChoices[rolledChoicePlaceSaver + 1] = currentChoiceNumber;

        rolledChoicePlaceSaver += 2;

        if (rolledChoicePlaceSaver >= rolledChoices.Length - 2)
        {
            rolledChoicePlaceSaver = 0;
        }
    }
    public void PlusPoints(int schoolToPlusPointsTo, int chosenChoiceNumber)
    {
        switch (schoolToPlusPointsTo)
        {
            case 0:
                switch (chosenChoiceNumber)
                {
                    case 0:
                        utilitarianPoints += 3;
                        break;
                    case 1:
                        utilitarianPoints += 4;
                        break;
                    case 2:
                        utilitarianPoints += 3;
                        break;
                    case 3:
                        utilitarianPoints += 3;
                        break;
                    case 4:
                        utilitarianPoints += 5;
                        break;
                    case 5:
                        utilitarianPoints += 2;
                        break;
                    case 6:
                        utilitarianPoints +=4;
                        break;
                }
                break;
            case 1:
                switch (chosenChoiceNumber)
                {
                    case 0:
                        rawlsianPoints += 1;
                        break;
                    case 1:
                        rawlsianPoints += 4;
                        break;
                    case 2:
                        rawlsianPoints += 3;
                        break;
                    case 3:
                        rawlsianPoints += 2;
                        break;
                    case 4:
                        rawlsianPoints += 5;
                        break;
                    case 5:
                        rawlsianPoints += 3;
                        break;
                    case 6:
                        rawlsianPoints += 3;
                        break;
                }
                break;
            case 2:
                switch (chosenChoiceNumber)
                {
                    case 0:
                        neoliberalPoints += 3;
                        break;
                    case 1:
                        neoliberalPoints += 4;
                        break;
                    case 2:
                        neoliberalPoints += 4;
                        break;
                    case 3:
                        neoliberalPoints += 3;
                        break;
                    case 4:
                        neoliberalPoints += 2;
                        break;
                    case 11:
                        neoliberalPoints += 4;
                        break;
                    case 5:
                        neoliberalPoints += 5;
                        break;
                    case 6:
                        neoliberalPoints += 4;
                        break;
                    case 7:
                        neoliberalPoints += 5;
                        break;
                    case 8:
                        neoliberalPoints += 4;
                        break;
                    case 9:
                        neoliberalPoints += 3;
                        break;
                    case 10:
                        neoliberalPoints += 4;
                        break;
                }
                break;
            case 3:
                switch (chosenChoiceNumber)
                {
                    case 0:
                        virtueEthicsPoints += 4;
                        break;
                    case 1:
                        virtueEthicsPoints += 5;
                        break;
                    case 2:
                        virtueEthicsPoints += 5;
                        break;
                    case 3:
                        virtueEthicsPoints += 4;
                        break;
                    case 4:
                        virtueEthicsPoints += 3;
                        break;
                    case 5:
                        virtueEthicsPoints += 5;
                        break;
                }
                break;
            case 4:
                switch (chosenChoiceNumber)
                {
                    case 0:
                        kantianPoints += 5;
                        break;
                    case 1:
                        kantianPoints += 1;
                        break;
                    case 2:
                        kantianPoints += 2;
                        break;
                    case 3:
                        kantianPoints += 4;
                        break;
                    case 4:
                        kantianPoints += 3;
                        break;
                    case 5:
                        kantianPoints += 3;
                        break;
                }
                break;
        }
    }
    public void MinusPoints(int schoolToMinusPointsFrom, int unChosenChoiceNumber)
    {
        switch (schoolToMinusPointsFrom)
        {
            case 0:
                switch (unChosenChoiceNumber)
                {
                    case 0:
                        utilitarianPoints -= 3;
                        break;
                    case 1:
                        utilitarianPoints -= 4;
                        break;
                    case 2:
                        utilitarianPoints -= 3;
                        break;
                    case 3:
                        utilitarianPoints -= 3;
                        break;
                    case 4:
                        utilitarianPoints -= 5;
                        break;
                    case 5:
                        utilitarianPoints -= 2;
                        break;
                    case 6:
                        utilitarianPoints -=4;
                        break;
                }
                break;
            case 1:
                switch (unChosenChoiceNumber)
                {
                    case 0:
                        rawlsianPoints -= 1;
                        break;
                    case 1:
                        rawlsianPoints -= 4;
                        break;
                    case 2:
                        rawlsianPoints -= 3;
                        break;
                    case 3:
                        rawlsianPoints -= 2;
                        break;
                    case 4:
                        rawlsianPoints -= 5;
                        break;
                    case 5:
                        rawlsianPoints -= 3;
                        break;
                    case 6:
                        rawlsianPoints -= 3;
                        break;

                }
                break;
            case 2:
                switch (unChosenChoiceNumber)
                {
                    case 0:
                        neoliberalPoints -= 3;
                        break;
                    case 1:
                        neoliberalPoints -= 4;
                        break;
                    case 2:
                        neoliberalPoints -= 4;
                        break;
                    case 3:
                        neoliberalPoints -= 3;
                        break;
                    case 4:
                        neoliberalPoints -= 2;
                        break;
                    case 11:
                        neoliberalPoints -= 4;
                        break;
                    case 5:
                        neoliberalPoints -= 5;
                        break;
                    case 6:
                        neoliberalPoints -= 4;
                        break;
                    case 7:
                        neoliberalPoints -= 5;
                        break;
                    case 8:
                        neoliberalPoints -= 4;
                        break;
                    case 9:
                        neoliberalPoints -= 3;
                        break;
                    case 10:
                        neoliberalPoints -= 4;
                        break;
                }
                break;
            case 3:
                switch (unChosenChoiceNumber)
                {
                    case 0:
                        virtueEthicsPoints -= 4;
                        break;
                    case 1:
                        virtueEthicsPoints -= 5;
                        break;
                    case 2:
                        virtueEthicsPoints -= 5;
                        break;
                    case 3:
                        virtueEthicsPoints -= 4;
                        break;
                    case 4:
                        virtueEthicsPoints -= 3;
                        break;
                    case 5:
                        virtueEthicsPoints -= 5;
                        break;
                }
                break;
            case 4:
                switch (unChosenChoiceNumber)
                {
                    case 0:
                        kantianPoints -= 5;
                        break;
                    case 1:
                        kantianPoints -= 1;
                        break;
                    case 2:
                        kantianPoints -= 2;
                        break;
                    case 3:
                        kantianPoints -= 4;
                        break;
                    case 4:
                        kantianPoints -= 3;
                        break;
                    case 5:
                        kantianPoints -= 3;
                        break;
                }
                break;
        }
    }
    public void EndScreenCheck()
    {
        if (currentRoundNumber > 10)
        {
            cbcCards.SetActive(false);
            endScreen.SetActive(true);
            statPanel.SetActive(true);

            lowestEthicsSchoolScore = Mathf.Min(utilitarianPoints,
                                                rawlsianPoints,
                                                neoliberalPoints,
                                                virtueEthicsPoints,
                                                kantianPoints);

            utilitarianPoints += Mathf.Abs(lowestEthicsSchoolScore) + 2;
            rawlsianPoints += Mathf.Abs(lowestEthicsSchoolScore) + 2;
            neoliberalPoints += Mathf.Abs(lowestEthicsSchoolScore) + 2;
            virtueEthicsPoints += Mathf.Abs(lowestEthicsSchoolScore) + 2;
            kantianPoints += Mathf.Abs(lowestEthicsSchoolScore) + 2;

            sliderRtoVE.value = Mathf.InverseLerp(0, (rawlsianPoints + virtueEthicsPoints), virtueEthicsPoints);
            sliderUtoR.value = Mathf.InverseLerp(0, (utilitarianPoints + rawlsianPoints), rawlsianPoints);
            sliderKtoU.value = Mathf.InverseLerp(0, (kantianPoints + utilitarianPoints), utilitarianPoints);
            sliderVEtoNL.value = Mathf.InverseLerp(0, (virtueEthicsPoints + neoliberalPoints), neoliberalPoints);
            sliderNLtoK.value = Mathf.InverseLerp(0, (neoliberalPoints + kantianPoints), kantianPoints);

            sliderUtoVE.value = Mathf.InverseLerp(0, (utilitarianPoints + virtueEthicsPoints), virtueEthicsPoints);
            sliderVEtoK.value = Mathf.InverseLerp(0, (virtueEthicsPoints + kantianPoints), kantianPoints);
            sliderKtoR.value = Mathf.InverseLerp(0, (kantianPoints + rawlsianPoints), rawlsianPoints);
            sliderRtoNL.value = Mathf.InverseLerp(0, (rawlsianPoints + neoliberalPoints), neoliberalPoints);
            sliderNLtoU.value = Mathf.InverseLerp(0, (neoliberalPoints + utilitarianPoints), utilitarianPoints);

            sliderRtoVE2.value = Mathf.InverseLerp(0, (rawlsianPoints + virtueEthicsPoints), virtueEthicsPoints);
            sliderUtoR2.value = Mathf.InverseLerp(0, (utilitarianPoints + rawlsianPoints), rawlsianPoints);
            sliderKtoU2.value = Mathf.InverseLerp(0, (kantianPoints + utilitarianPoints), utilitarianPoints);
            sliderVEtoNL2.value = Mathf.InverseLerp(0, (virtueEthicsPoints + neoliberalPoints), neoliberalPoints);
            sliderNLtoK2.value = Mathf.InverseLerp(0, (neoliberalPoints + kantianPoints), kantianPoints);

            sliderUtoVE2.value = Mathf.InverseLerp(0, (utilitarianPoints + virtueEthicsPoints), virtueEthicsPoints);
            sliderVEtoK2.value = Mathf.InverseLerp(0, (virtueEthicsPoints + kantianPoints), kantianPoints);
            sliderKtoR2.value = Mathf.InverseLerp(0, (kantianPoints + rawlsianPoints), rawlsianPoints);
            sliderRtoNL2.value = Mathf.InverseLerp(0, (rawlsianPoints + neoliberalPoints), neoliberalPoints);
            sliderNLtoU2.value = Mathf.InverseLerp(0, (neoliberalPoints + utilitarianPoints), utilitarianPoints);

            sliderRtoVE3.value = Mathf.InverseLerp(0, (rawlsianPoints + virtueEthicsPoints), virtueEthicsPoints);
            sliderUtoR3.value = Mathf.InverseLerp(0, (utilitarianPoints + rawlsianPoints), rawlsianPoints);
            sliderKtoU3.value = Mathf.InverseLerp(0, (kantianPoints + utilitarianPoints), utilitarianPoints);
            sliderVEtoNL3.value = Mathf.InverseLerp(0, (virtueEthicsPoints + neoliberalPoints), neoliberalPoints);
            sliderNLtoK3.value = Mathf.InverseLerp(0, (neoliberalPoints + kantianPoints), kantianPoints);

            sliderUtoVE3.value = Mathf.InverseLerp(0, (utilitarianPoints + virtueEthicsPoints), virtueEthicsPoints);
            sliderVEtoK3.value = Mathf.InverseLerp(0, (virtueEthicsPoints + kantianPoints), kantianPoints);
            sliderKtoR3.value = Mathf.InverseLerp(0, (kantianPoints + rawlsianPoints), rawlsianPoints);
            sliderRtoNL3.value = Mathf.InverseLerp(0, (rawlsianPoints + neoliberalPoints), neoliberalPoints);
            sliderNLtoU3.value = Mathf.InverseLerp(0, (neoliberalPoints + utilitarianPoints), utilitarianPoints);

            sliderRtoVE4.value = Mathf.InverseLerp(0, (rawlsianPoints + virtueEthicsPoints), virtueEthicsPoints);
            sliderUtoR4.value = Mathf.InverseLerp(0, (utilitarianPoints + rawlsianPoints), rawlsianPoints);
            sliderKtoU4.value = Mathf.InverseLerp(0, (kantianPoints + utilitarianPoints), utilitarianPoints);
            sliderVEtoNL4.value = Mathf.InverseLerp(0, (virtueEthicsPoints + neoliberalPoints), neoliberalPoints);
            sliderNLtoK4.value = Mathf.InverseLerp(0, (neoliberalPoints + kantianPoints), kantianPoints);

            sliderUtoVE4.value = Mathf.InverseLerp(0, (utilitarianPoints + virtueEthicsPoints), virtueEthicsPoints);
            sliderVEtoK4.value = Mathf.InverseLerp(0, (virtueEthicsPoints + kantianPoints), kantianPoints);
            sliderKtoR4.value = Mathf.InverseLerp(0, (kantianPoints + rawlsianPoints), rawlsianPoints);
            sliderRtoNL4.value = Mathf.InverseLerp(0, (rawlsianPoints + neoliberalPoints), neoliberalPoints);
            sliderNLtoU4.value = Mathf.InverseLerp(0, (neoliberalPoints + utilitarianPoints), utilitarianPoints);

            R_VE_Percentage.text = (Mathf.InverseLerp(0, (rawlsianPoints + virtueEthicsPoints), rawlsianPoints) * 100).ToString("F0") + "%";
            R_NL_Percentage.text = (Mathf.InverseLerp(0, (rawlsianPoints + neoliberalPoints), rawlsianPoints) * 100).ToString("F0") + "%";
            U_R_Percentage.text = (Mathf.InverseLerp(0, (utilitarianPoints + rawlsianPoints), utilitarianPoints) * 100).ToString("F0") + "%";
            U_VE_Percentage.text = (Mathf.InverseLerp(0, (virtueEthicsPoints + utilitarianPoints), utilitarianPoints) * 100).ToString("F0") + "%";
            K_U_Percentage.text = (Mathf.InverseLerp(0, (kantianPoints + utilitarianPoints), kantianPoints) * 100).ToString("F0") + "%";
            K_R_Percentage.text = (Mathf.InverseLerp(0, (kantianPoints + rawlsianPoints), kantianPoints) * 100).ToString("F0") + "%";
            VE_NL_Percentage.text = (Mathf.InverseLerp(0, (neoliberalPoints + virtueEthicsPoints), virtueEthicsPoints) * 100).ToString("F0") + "%";
            VE_K_Percentage.text = (Mathf.InverseLerp(0, (kantianPoints + virtueEthicsPoints), virtueEthicsPoints) * 100).ToString("F0") + "%";
            NL_K_Percentage.text = (Mathf.InverseLerp(0, (neoliberalPoints + kantianPoints), neoliberalPoints) * 100).ToString("F0") + "%";
            NL_U_Percentage.text = (Mathf.InverseLerp(0, (neoliberalPoints + utilitarianPoints), neoliberalPoints) * 100).ToString("F0") + "%";
            VE_R_Percentage.text = (Mathf.InverseLerp(0, (rawlsianPoints + virtueEthicsPoints), virtueEthicsPoints) * 100).ToString("F0") + "%";
            NL_R_Percentage.text = (Mathf.InverseLerp(0, (neoliberalPoints + rawlsianPoints), neoliberalPoints) * 100).ToString("F0") + "%";
            R_U_Percentage.text = (Mathf.InverseLerp(0, (rawlsianPoints + utilitarianPoints), rawlsianPoints) * 100).ToString("F0") + "%";
            VE_U_Percentage.text = (Mathf.InverseLerp(0, (virtueEthicsPoints + utilitarianPoints), virtueEthicsPoints) * 100).ToString("F0") + "%";
            U_K_Percentage.text = (Mathf.InverseLerp(0, (kantianPoints + utilitarianPoints), utilitarianPoints) * 100).ToString("F0") + "%";
            R_K_Percentage.text = (Mathf.InverseLerp(0, (rawlsianPoints + kantianPoints), rawlsianPoints) * 100).ToString("F0") + "%";
            NL_VE_Percentage.text = (Mathf.InverseLerp(0, (neoliberalPoints + virtueEthicsPoints), neoliberalPoints) * 100).ToString("F0") + "%";
            K_VE_Percentage.text = (Mathf.InverseLerp(0, (kantianPoints + virtueEthicsPoints), kantianPoints) * 100).ToString("F0") + "%";
            K_NL_Percentage.text = (Mathf.InverseLerp(0, (neoliberalPoints + kantianPoints), kantianPoints) * 100).ToString("F0") + "%";
            U_NL_Percentage.text = (Mathf.InverseLerp(0, (neoliberalPoints + utilitarianPoints), utilitarianPoints) * 100).ToString("F0") + "%";

            totalEthicsSchoolPoints = utilitarianPoints +
                                                rawlsianPoints +
                                                neoliberalPoints +
                                                virtueEthicsPoints +
                                                kantianPoints;

            utilitarianPercentage.text = (((float)utilitarianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            rawlsianPercentage.text = (((float)rawlsianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            neoliberalPercentage.text = (((float)neoliberalPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            virtueEthicsPercentage.text = (((float)virtueEthicsPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            kantianPercentage.text = (((float)kantianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";

            utilitarianPercentage2.text = (((float)utilitarianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            rawlsianPercentage2.text = (((float)rawlsianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            neoliberalPercentage2.text = (((float)neoliberalPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            virtueEthicsPercentage2.text = (((float)virtueEthicsPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            kantianPercentage2.text = (((float)kantianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";

            utilitarianPercentage3.text = (((float)utilitarianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            rawlsianPercentage3.text = (((float)rawlsianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            neoliberalPercentage3.text = (((float)neoliberalPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            virtueEthicsPercentage3.text = (((float)virtueEthicsPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            kantianPercentage3.text = (((float)kantianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";

            utilitarianPercentage4.text = (((float)utilitarianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            rawlsianPercentage4.text = (((float)rawlsianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            neoliberalPercentage4.text = (((float)neoliberalPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            virtueEthicsPercentage4.text = (((float)virtueEthicsPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            kantianPercentage4.text = (((float)kantianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";

            utilitarianPercentage5.text = (((float)utilitarianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            rawlsianPercentage5.text = (((float)rawlsianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            neoliberalPercentage5.text = (((float)neoliberalPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            virtueEthicsPercentage5.text = (((float)virtueEthicsPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            kantianPercentage5.text = (((float)kantianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";

            utilitarianPercentage6.text = (((float)utilitarianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            rawlsianPercentage6.text = (((float)rawlsianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            neoliberalPercentage6.text = (((float)neoliberalPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            virtueEthicsPercentage6.text = (((float)virtueEthicsPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            kantianPercentage6.text = (((float)kantianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";

            numberOfWeeksAtEndTextDisplay.text = (currentRoundNumber - 1).ToString();

            highestEthicsSchoolPoints = Mathf.Max(utilitarianPoints,
                                                    rawlsianPoints,
                                                    neoliberalPoints,
                                                    virtueEthicsPoints,
                                                    kantianPoints);

            radarScript = GameObject.Find("RadarChart A").GetComponent<RadarChart>();

            radarScript.m_Data = new List<float>
            {
                ((float) rawlsianPoints      /(float) highestEthicsSchoolPoints),
                ((float)utilitarianPoints / (float)highestEthicsSchoolPoints),
                ((float)kantianPoints / (float)highestEthicsSchoolPoints),
                ((float)neoliberalPoints / (float)highestEthicsSchoolPoints),
                ((float)virtueEthicsPoints / (float)highestEthicsSchoolPoints),
                ((float)rawlsianPoints / (float)highestEthicsSchoolPoints)      // added a arbitrary 6th value to list because otherwise radar chart doesn't show value for 5th axis VE
            };

            resultNumber += 1;
            resultTimes[resultNumber] = DateTime.Now.ToString();
            resultStrings[resultNumber] = "Result " + (resultNumber).ToString() + " - " + resultTimes[resultNumber];
            resultReferenceDisplayText.text = resultStrings[resultNumber];

            SetRadarChartLabelColors();

            verticeIndicatorsCBC[0] = GameObject.Find("Vertice1");
            verticeIndicatorsCBC[1] = GameObject.Find("Vertice2");
            verticeIndicatorsCBC[2] = GameObject.Find("Vertice3");
            verticeIndicatorsCBC[3] = GameObject.Find("Vertice4");
            verticeIndicatorsCBC[4] = GameObject.Find("Vertice5");

            centroidCoordinateX =   (       verticeIndicatorsCBC[0].GetComponent<RectTransform>().anchoredPosition.x
                                        +   verticeIndicatorsCBC[1].GetComponent<RectTransform>().anchoredPosition.x
                                        +   verticeIndicatorsCBC[2].GetComponent<RectTransform>().anchoredPosition.x
                                        +   verticeIndicatorsCBC[3].GetComponent<RectTransform>().anchoredPosition.x
                                        +   verticeIndicatorsCBC[4].GetComponent<RectTransform>().anchoredPosition.x)/5f;

            centroidCoordinateY =   (       verticeIndicatorsCBC[0].GetComponent<RectTransform>().anchoredPosition.y
                                        +   verticeIndicatorsCBC[1].GetComponent<RectTransform>().anchoredPosition.y
                                        +   verticeIndicatorsCBC[2].GetComponent<RectTransform>().anchoredPosition.y
                                        +   verticeIndicatorsCBC[3].GetComponent<RectTransform>().anchoredPosition.y
                                        +   verticeIndicatorsCBC[4].GetComponent<RectTransform>().anchoredPosition.y)/5f;

            centroidPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(centroidCoordinateX, centroidCoordinateY);

            dataSenderScript.Send();
        }
    }
    public void SetRadarChartLabelColors()
    {
        radarChartObject = GameObject.Find("RadarChart A");

        radarRawlsianLabel = radarChartObject.transform.GetChild(7).gameObject;
        radarUtilitarianLabel = radarChartObject.transform.GetChild(8).gameObject;
        radarKantianLabel = radarChartObject.transform.GetChild(9).gameObject;
        radarNeoliberalLabel = radarChartObject.transform.GetChild(10).gameObject;
        radarVirtueEthicsLabel = radarChartObject.transform.GetChild(11).gameObject;

        radarRawlsianLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color32(146, 193, 114, 255);
        radarUtilitarianLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color32(208, 197, 253, 255);
        radarKantianLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color32(247,	235, 82, 255);
        radarNeoliberalLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color32(242, 143,	201, 255);
        radarVirtueEthicsLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color32(161, 213, 255, 255);

        radarRawlsianLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Rawlsian";
        radarUtilitarianLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Utilitarian";
        radarKantianLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Kantian";
        radarNeoliberalLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Neoliberal";
        radarVirtueEthicsLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Virtue Ethics";

        radarRawlsianLabel.gameObject.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        radarUtilitarianLabel.gameObject.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        radarKantianLabel.gameObject.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        radarNeoliberalLabel.gameObject.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        radarVirtueEthicsLabel.gameObject.GetComponent<Text>().color = new Color32(0, 0, 0, 255);

        radarUtilitarianLabel.gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleRight;
        radarUtilitarianLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleRight;

        radarVirtueEthicsLabel.gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        radarVirtueEthicsLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
    }
    public void RetakeTest()
    {
        rolledChoices = new int[34];

        choiceRolledRecently = false;

        rolledChoicePlaceSaver = 0;

        runsOfDoWhileChoiceRollLoop = 0;

        utilitarianPoints = 0;
        rawlsianPoints = 0;
        neoliberalPoints = 0;
        virtueEthicsPoints = 0;
        kantianPoints = 0;

        currentRoundNumber = 1;

        AssignText();
        statPanel.SetActive(false);

        resultNumber = 0;
        resultStrings = new string[10];
        resultTimes = new string[10];

        grayLoadingBackground.SetActive(false);
    }

    public void OpenSite()
    {
        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/legiblevalues/");
    }
    public void SetUpStrings()
    {
        //UTILITARIAN CHOICES
        //Brendan,Forest

        //Everyone wants equal happiness and help others.
        //(Utilitarianism)I help people to push the gold across and she give
        //me some gold and i help her and we are equal happiness.weight 3 //
        utilitarianChoices[0] = "You help an old person push gold across the street. You do it because they will be safe, give you gold, and you will both be happy.";

        //Utilitarianism means you do things that make you most happy.weight 4 //
        utilitarianChoices[2] = "You kill 1 person to save 5 people. Because 5 people have more value than 1 person.";

        //Even though he might still get hurt, you make sure there’s the least harm possible.weight 3//
        utilitarianChoices[1] = "You save a person by pushing him off his bike when he's about to be hit by a car.";

        //We should maximize happiness for ourselves and others.weight 3 //          
        utilitarianChoices[3] = "You go order a drink and instead of only buying for yourself, you also buy for 5 other people. Buying drinks for 5 people brings more happiness to them.";

        //Everyone has the same value, so the more people,
        //the more your actions are worth.weight 5// 
        //third test comment
        utilitarianChoices[4] = "You perform in front of 200 people instead of 100. 200 people's happiness combined is more important than 100.";

        //You do this because you want everyone to be happy.
        utilitarianChoices[5] = "You buy food and share it with people that want it.";
        //When everyone comes into the classroom then there is air conditioning because being Utilitarianism we want everyone to be happy.
        utilitarianChoices[6] = "Go out and have have dinner with neighbors and my family";
        //By:I can make my family happy and the neighbors happy too.(Fragment on Government Bentham 1776)
        //---------------------------------------------------------------------------------------------------------------------------------------

        //RAWLSIAN CHOICES
        //Choices 1, 2, 4, 5, and 7 of the Rawlsian Liberalism School
        //Fifi, Cooper, Chelsea, and Annie

        //Your motivation comes from a desire to follow the agreement
        //made by you and your friend based on the Rawlsian liberalism that choices create agreement.
        //weight 1
        rawlsianChoices[0] = "When your friend refuses to lend you her eraser, you respect her choice.";

        //Your motivation comes from the desire to follow the
        //agreements held by everyone around you based on Rawlsian Liberalism.
        //weight 4
        rawlsianChoices[1] = "Everyone agrees to not steal the diamond on the pedestal, so you don't steal it because you respect this agreement.";

        //Your motivation comes from that all the requirements should be
        //made without considering a specific club member individual’s perspective.
        //weight 3
        rawlsianChoices[2] = "You are a leader of a club, you decide to give each student an equal amount of supplies regardless of each individual.";

        //Your motivation comes from a desire to follow the
        //agreements of everyone based on Rawlsian Liberalism.
        //weight 2
        rawlsianChoices[3] = "In a room where people agree to speak only English, you only speak English because you respect this agreement.";

        //Your motivation comes from a desire to follow the law based on the
        //Rawlsian liberalism that law is an agreement and not murder is a requirement.
        //This is because requirements are not determined without determining your perspective.
        //weight 5
        rawlsianChoices[4] = "Someone is trying to murder you, but you decided not to beat back because you agree to the law to not kill people.";

        /*Your motivation comes from a desire to follow the agreed-upon rules, despite what you individually want. 
        Rawls states, “The veil of ignorance situates the representatives of free and equal citizens fairly 
        concerning one another. No party can press for agreement on principles that will arbitrarily favor 
        the particular citizen they represent, because no party knows the specific attributes of the citizen 
        they represent”(Wenar, “John Rawls”, SEP, 2008 rev. 2021). Since the agreement was from a perspective 
        with a supposed veil of ignorance (the camp directors/teachers, not the students) they agreed with the 
        students that everyone should have lights out. As students, we should follow these rules because it was
         agreed upon.
        //Weight 3
        */
        rawlsianChoices[5] = "When everyone agrees to have lights out by a certain time, you will comply";

        rawlsianChoices[6] = "After using equipment in the gym, I will wipe it down.";

        //-------------------------------------------------------------------------------------------------------------------------------------------
        /*//
        //test comment
       NEOLIBERAL CHOICES (Team 1)

       //FYI, from neoliberalChoices[10] and onward, even number choices will be neoliberalism team 2, odd number choices will be neoliberalism team 1.

       Publication #0005 Last Edit 0849z 21 SEP 23
        Choices 0, 1, 2, 3, 4 of the Neoliberalism/Liberalism school
        Eli, Alonzo, DarrenH
        */
        //You instinctively do this because you value your life more than other people, hence you chose to protect yourself first before serving others. You do this because you believe in neoliberalism/liberalism, which values an individual's rights and ownership over everyone else. weight 3//
        neoliberalChoices[0] = "You chose to run away from danger instead of putting yourself in it.";

        //You do this because you believe that receiving an education overseas would be more beneficial to your career. Your motivation comes from a desire to follow neoliberalism/liberalism, based on what you yourself, as an individual, believe in, instead of others wishes. weight 4.//
        neoliberalChoices[1] = "You go abroad to study in an American university despite your grandparents' wishes for you to stay in Taiwan.";

        //You are tired of renting a flat and depending on the landlord’s decisions. Your motivation comes from a desire to follow neoliberalism/liberalism, causing you to prefer owning things instead of depending on others. weight 4.//
        neoliberalChoices[2] = "You purchased a house along with the basic utilities to be installed.";

        //You do this because you are hungry and want to eat something. Your motivation comes from a desire to follow neoliberalism/liberalism, which values a person’s freedom to exchange items with others under an agreement, opposed to just stealing items. weight 3 //
        neoliberalChoices[3] = "You pay money to eat at a restaurant, you receive food and catering services in return.";

        //You do this because you feel an urge to purchase whatever is hyped up. Your motivation comes from a desire to follow neoliberalism/liberalism, which enables a person to make free decisions without external influence. weight 2.//
        neoliberalChoices[4] = "You decided to spend part of your salary this month to buy celebrity endorsed products.";

        //You do this because neoliberalism values the ability for an indivudal to make choices freely, this can be expressed in many ways including the exchange of items.
        neoliberalChoices[11] = "You trade your BBQ with your friend.";

        //-------------------------------------------------------------------------------------------------------------------------------------------
        /*
                NEOLIBERAL CHOICES (Team 2)
                Choices 5, 6, 7, 8 of the Neoliberalism/Liberalism school
                Adam, Chi, Angus
        */
        //monday left me broken tuesday i was through with hoping
        neoliberalChoices[5] = "You wanted to buy his glasses, he decided to sell them to you.";
        //This makes sense to my values because I am in the neoliberalism school, and the glasses belong to him and he decided to sell them to me. weight 5

        neoliberalChoices[6] = "He tries to force you to teach him math, You decide not to teach him math.";
        //This makes sense to my values because I am in the neoliberalism school, and I have my own right to decide on my own if I want to teach him or not. weight 4

        neoliberalChoices[7] = "She wants to trade her pencil for your Rolex, but you don't think they are the same value. So you denied her trade offer.";
        //This makes sense to my values because I am in the neoliberalism school, and I can decide the value of things I own and if I want to trade them. weight 5

        neoliberalChoices[8] = "He tries to force you to trade pencils with him, and you decided that you didn't want to trade pencils with him.";
        //This makes sense to my values because I am in the neoliberalism school, and because we can only trade things if the choice is free I can decide not to trade with him because the trade isn't free. weight 4 

        neoliberalChoices[9] = "Mom is yelling that it’s time for dinner, but you think it's too early to have dinner, so you don't go to dinner.";
        //This makes sense to my values because I am in the neoliberalism school, and because I own myself and that gives me rights. weight 3
        neoliberalChoices[10] = "Today is the field trip. You felt exhausted today so you slept on the bus.";
        //This makes sense to my values because you own yourself and this agrees with “If I own my own body, I should be free to sleep whenever I want.” - Sandel, Justice, 2009. weight 3

        //-------------------------------------------------------------------------------------------------------------------------------------------

        // VIRTUE ETHICS CHOICES
        //Virtue Ethics team: Amber, Anna, Chelsea W, Irene
        //Your motivation comes from a desire to follow your parent’s example of being a calm person, based on the virtue ethics of Aristotle (imitate good people to be good). Weight 4
        virtueEthicsChoices[0] = "You want to be like your parent who handles conflicts civilly, so when hit you ask what's wrong and don't hit the person back.";
        //Your motivation comes from a desire to model your classmate’s helpfulness, based on Aristotle’s virtue ethics. Weight 5
        virtueEthicsChoices[1] = "You pick up trash from the floor, which keeps the environment clean, because you saw someone do this and want to be like them.";
        //Your motivation comes from a desire to get good grades, based on Confucius’s virtue ethics (孔子 says that it’s fine to be good for the sake of the result and not for goodness). Weight 5
        virtueEthicsChoices[2] = "After noticing the learning habits of a classmate who gets good grades, you turn studious because you want good grades too.";
        //Weight 4
        virtueEthicsChoices[3] = "You gave food to a homeless man because you saw a celebrity do it and it seems like the right thing to do.";
        //Weight 3      
        virtueEthicsChoices[4] = "You study hard because you want to have a good future and it shows others how they can learn from you.";
        //This agrees with virtue ethics' idea of being good by following an example of good people (Athanassoulis, Internet Encyclopedia of Philosophy “Virtue Ethics”, n.d.).
        //Weight
        virtueEthicsChoices[5] = "You take part in the group project because this is what every teammate you've had did, helping your team finish the work faster.";

        //-------------------------------------------------------------------------------------------------------------------------------------------
        //KANTIAN CHOICES
        //Kantian Ethics team: Audrey, Carlson, David, Abby
        //Your motivation comes from Kantian Ethics thinking you should always do the right thing.Weight3
        kantianChoices[0] = "You feed a homeless man because he was starving.";

        //Kantian Ethics thinks you have to do the right things though you will hurt people or yourself. Weight 1
        kantianChoices[1] = "You kick a kid because he almost got hit by a car.";

        //Your motivation comes from .Weight 2
        kantianChoices[2] = "You donate old toys to the local orphanage because they need it.";

        //This is a good choice because everyone makes the same choice. Weight4
        kantianChoices[3] = "The entire class turned their assignments in on time.";

        //I did this because if I didn't pull him he might’ve fallen down and been hurt more. Weight3
        kantianChoices[4] = "You pulled a guy because he almost fell down.";

        //You do this because you don’t want to keep anyone from sitting with who they want. Weight5
        kantianChoices[5] = "You let others choose seats before yourself.";
        //-------------------------------------------------------------------------------------------------------------------------------------------

    }
}
//Background Color 	- 	84CCE1
//Card Color 		- 	586994
//Game Text Color 	-	2D0320
//Card Text Color 	- 	FBFCF8


// Neoliberal 		- 	E06C9F
// Utilitarian 	    -	2B4162
// Rawlsian 		-	6B0504
// Kantian 		    - 	FFE1A8
// Virtue Ethics	- 	EDBFB7
