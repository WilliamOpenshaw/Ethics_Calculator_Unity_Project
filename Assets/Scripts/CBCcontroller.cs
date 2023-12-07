//0.2.7

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
    public GameObject canvas;
    public int[][] choiceTallies; // 0-Uti. 1-Raw. 2-Vir.Eth. 3-NeoLib 4-Kant // Choices 1-16 each // jagged array that holds tally of how many times each choice is chosen
    public GameObject mainMenu;
    public GameObject nameAndSchool;
    public GameObject mainMenuPlayButton;
    public GameObject nameSchoolContinueButton;
    public GameObject graphButton1;
    public GameObject graphButton2;
    public GameObject graphButton3;
    public GameObject graphButton4;
    public GameObject graphButton5;

    public GameObject graphButton6;
    
    public GameObject retakeButton;
    public string currentLanguage;
    public GameObject dayXFlash;
    public GameObject dayYFlash;
    public GameObject dayZFlash;
    public GameObject dayXWholeCard;
    public GameObject dayYWholeCard;
    public GameObject dayZWholeCard;
    public GameObject[] verticeIndicatorsCBC;

    public GameObject[] verticeIndicatorsCBCB;
    public DataSender dataSenderScript;
    public TextMeshProUGUI dayXmorningText;
    public TextMeshProUGUI dayXeveningText;
    public TextMeshProUGUI dayYmorningText;
    public TextMeshProUGUI dayYafternoonText;
    public TextMeshProUGUI dayXafternoonText;
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

    public string[] utilitarianChoicesChinese;
    public string[] rawlsianChoicesChinese;
    public string[] neoliberalChoicesChinese;
    public string[] virtueEthicsChoicesChinese;
    public string[] kantianChoicesChinese;

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

    public float centroidCoordinateXB;
    public float centroidCoordinateYB;
    public GameObject centroidPointB;

    void Start()
    {
        choiceTallies = new int[5][];
        choiceTallies[0] = new int[9]{0,0,0,0,0,0,0,0,0};
        choiceTallies[1] = new int[10]{0,0,0,0,0,0,0,0,0,0};
        choiceTallies[2] = new int[9]{0,0,0,0,0,0,0,0,0};
        choiceTallies[3] = new int[18]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        choiceTallies[4] = new int[9]{0,0,0,0,0,0,0,0,0};
        
        currentLanguage = "eng";

        utilitarianChoices = new string[9];
        rawlsianChoices = new string[10];
        virtueEthicsChoices = new string[9];
        neoliberalChoices = new string[18];
        kantianChoices = new string[9];

        utilitarianChoicesChinese = new string[9];
        rawlsianChoicesChinese = new string[10];
        virtueEthicsChoicesChinese = new string[9];
        neoliberalChoicesChinese = new string[18];
        kantianChoicesChinese = new string[9];

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
        verticeIndicatorsCBCB = new GameObject[5];

    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftBracket) && cbcCards.activeInHierarchy == true)
        {
                ChooseDayX();
        }
        else if (Input.GetKeyUp(KeyCode.RightBracket) && cbcCards.activeInHierarchy == true)
        {
                ChooseDayY();
        }
        else if (Input.GetKeyUp(KeyCode.Backslash) && cbcCards.activeInHierarchy == true)
        {
                ChooseDayZ();
        }
        else if (mainMenuPlayButton.activeInHierarchy == true && (Input.GetKeyUp(KeyCode.LeftBracket) || Input.GetKeyUp(KeyCode.RightBracket) || Input.GetKeyUp(KeyCode.Backslash) ))
        {
            mainMenuPlayButton.GetComponent<Button>().onClick.Invoke();
            nameSchoolContinueButton.SetActive(false);
            StartCoroutine(Wait());
        }
        else if ((nameSchoolContinueButton.activeInHierarchy == true) && (Input.GetKeyUp(KeyCode.LeftBracket) || Input.GetKeyUp(KeyCode.RightBracket) || Input.GetKeyUp(KeyCode.Backslash) ) )
        {
            nameSchoolContinueButton.GetComponent<Button>().onClick.Invoke();            
        }
        else if (graphButton1.activeInHierarchy == true && (Input.GetKeyUp(KeyCode.LeftBracket) || Input.GetKeyUp(KeyCode.Backslash)))
        {
            graphButton1.GetComponent<Button>().onClick.Invoke();
        }
        else if (graphButton2.activeInHierarchy == true && (Input.GetKeyUp(KeyCode.LeftBracket) || Input.GetKeyUp(KeyCode.Backslash)))
        {
            graphButton2.GetComponent<Button>().onClick.Invoke();
        }
        else if (graphButton3.activeInHierarchy == true && (Input.GetKeyUp(KeyCode.LeftBracket) || Input.GetKeyUp(KeyCode.Backslash)))
        {
            graphButton3.GetComponent<Button>().onClick.Invoke();
        }
        else if (graphButton4.activeInHierarchy == true && (Input.GetKeyUp(KeyCode.LeftBracket) || Input.GetKeyUp(KeyCode.Backslash)))
        {
            graphButton4.GetComponent<Button>().onClick.Invoke();
        }
        else if (graphButton5.activeInHierarchy == true && (Input.GetKeyUp(KeyCode.LeftBracket) || Input.GetKeyUp(KeyCode.Backslash)))
        {
            graphButton5.GetComponent<Button>().onClick.Invoke();
        }
        else if (graphButton6.activeInHierarchy == true && (Input.GetKeyUp(KeyCode.LeftBracket) || Input.GetKeyUp(KeyCode.Backslash)))
        {
            graphButton6.GetComponent<Button>().onClick.Invoke();
        }   
        else if ((graphButton6.activeInHierarchy == true || graphButton5.activeInHierarchy == true || graphButton4.activeInHierarchy == true || graphButton3.activeInHierarchy == true || graphButton2.activeInHierarchy == true || graphButton1.activeInHierarchy == true) && (Input.GetKeyUp(KeyCode.RightBracket)))
        {
            retakeButton.GetComponent<Button>().onClick.Invoke();
            RetakeTest();
        }        
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        nameSchoolContinueButton.SetActive(true);
    }
    public void ChangeLanguage(string chosenLanguage)
    {
        if (chosenLanguage == "english" && currentLanguage != "eng")
        {
            currentLanguage = "eng";
            DisplayEnglish();
        }
        else if (chosenLanguage == "chinese" && currentLanguage != "chi")
        {
            currentLanguage = "chi";
            DisplayChinese();
        }
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

        if (currentLanguage == "chi")
        {
            DisplayChinese();
        }
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
        StartCoroutine(FlashGrowShrink(dayXFlash, dayXWholeCard));
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
        StartCoroutine(FlashGrowShrink(dayYFlash, dayYWholeCard));
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
        StartCoroutine(FlashGrowShrink(dayZFlash, dayZWholeCard));
    }
    public IEnumerator FlashGrowShrink(GameObject clickedDayFlash, GameObject clickedDayWholeCard)
    {
        clickedDayFlash.SetActive(true);
        clickedDayWholeCard.GetComponent<RectTransform>().localScale = new Vector3(1.05f, 1.05f, 1.05f);
        yield return new WaitForSeconds(0.2f);
        clickedDayWholeCard.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
        clickedDayFlash.SetActive(false);
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
    public void DisplayChinese()
    {
        switch (dayXmorningCurrentEthicsSchool)
        {
            case 0:
                dayXmorningText.text = utilitarianChoicesChinese[dayXmorningCurrentChoiceNumber];
                break;
            case 1:
                dayXmorningText.text = rawlsianChoicesChinese[dayXmorningCurrentChoiceNumber];
                break;
            case 2:
                dayXmorningText.text = virtueEthicsChoicesChinese[dayXmorningCurrentChoiceNumber];
                break;
            case 3:
                dayXmorningText.text = neoliberalChoicesChinese[dayXmorningCurrentChoiceNumber];
                break;
            case 4:
                dayXmorningText.text = kantianChoicesChinese[dayXmorningCurrentChoiceNumber];
                break;
        }
        switch (dayXafternoonCurrentEthicsSchool)
        {
            case 0:
                dayXafternoonText.text = utilitarianChoicesChinese[dayXafternoonCurrentChoiceNumber];
                break;
            case 1:
                dayXafternoonText.text = rawlsianChoicesChinese[dayXafternoonCurrentChoiceNumber];
                break;
            case 2:
                dayXafternoonText.text = virtueEthicsChoicesChinese[dayXafternoonCurrentChoiceNumber];
                break;
            case 3:
                dayXafternoonText.text = neoliberalChoicesChinese[dayXafternoonCurrentChoiceNumber];
                break;
            case 4:
                dayXafternoonText.text = kantianChoicesChinese[dayXafternoonCurrentChoiceNumber];
                break;
        }
        switch (dayXeveningCurrentEthicsSchool)
        {
            case 0:
                dayXeveningText.text = utilitarianChoicesChinese[dayXeveningCurrentChoiceNumber];
                break;
            case 1:
                dayXeveningText.text = rawlsianChoicesChinese[dayXeveningCurrentChoiceNumber];
                break;
            case 2:
                dayXeveningText.text = virtueEthicsChoicesChinese[dayXeveningCurrentChoiceNumber];
                break;
            case 3:
                dayXeveningText.text = neoliberalChoicesChinese[dayXeveningCurrentChoiceNumber];
                break;
            case 4:
                dayXeveningText.text = kantianChoicesChinese[dayXeveningCurrentChoiceNumber];
                break;
        }
        switch (dayYmorningCurrentEthicsSchool)
        {
            case 0:
                dayYmorningText.text = utilitarianChoicesChinese[dayYmorningCurrentChoiceNumber];
                break;
            case 1:
                dayYmorningText.text = rawlsianChoicesChinese[dayYmorningCurrentChoiceNumber];
                break;
            case 2:
                dayYmorningText.text = virtueEthicsChoicesChinese[dayYmorningCurrentChoiceNumber];
                break;
            case 3:
                dayYmorningText.text = neoliberalChoicesChinese[dayYmorningCurrentChoiceNumber];
                break;
            case 4:
                dayYmorningText.text = kantianChoicesChinese[dayYmorningCurrentChoiceNumber];
                break;
        }
        switch (dayYafternoonCurrentEthicsSchool)
        {
            case 0:
                dayYafternoonText.text = utilitarianChoicesChinese[dayYafternoonCurrentChoiceNumber];
                break;
            case 1:
                dayYafternoonText.text = rawlsianChoicesChinese[dayYafternoonCurrentChoiceNumber];
                break;
            case 2:
                dayYafternoonText.text = virtueEthicsChoicesChinese[dayYafternoonCurrentChoiceNumber];
                break;
            case 3:
                dayYafternoonText.text = neoliberalChoicesChinese[dayYafternoonCurrentChoiceNumber];
                break;
            case 4:
                dayYafternoonText.text = kantianChoicesChinese[dayYafternoonCurrentChoiceNumber];
                break;
        }
        switch (dayYeveningCurrentEthicsSchool)
        {
            case 0:
                dayYeveningText.text = utilitarianChoicesChinese[dayYeveningCurrentChoiceNumber];
                break;
            case 1:
                dayYeveningText.text = rawlsianChoicesChinese[dayYeveningCurrentChoiceNumber];
                break;
            case 2:
                dayYeveningText.text = virtueEthicsChoicesChinese[dayYeveningCurrentChoiceNumber];
                break;
            case 3:
                dayYeveningText.text = neoliberalChoicesChinese[dayYeveningCurrentChoiceNumber];
                break;
            case 4:
                dayYeveningText.text = kantianChoicesChinese[dayYeveningCurrentChoiceNumber];
                break;
        }
        switch (dayZmorningCurrentEthicsSchool)
        {
            case 0:
                dayZmorningText.text = utilitarianChoicesChinese[dayZmorningCurrentChoiceNumber];
                break;
            case 1:
                dayZmorningText.text = rawlsianChoicesChinese[dayZmorningCurrentChoiceNumber];
                break;
            case 2:
                dayZmorningText.text = virtueEthicsChoicesChinese[dayZmorningCurrentChoiceNumber];
                break;
            case 3:
                dayZmorningText.text = neoliberalChoicesChinese[dayZmorningCurrentChoiceNumber];
                break;
            case 4:
                dayZmorningText.text = kantianChoicesChinese[dayZmorningCurrentChoiceNumber];
                break;
        }
        switch (dayZafternoonCurrentEthicsSchool)
        {
            case 0:
                dayZafternoonText.text = utilitarianChoicesChinese[dayZafternoonCurrentChoiceNumber];
                break;
            case 1:
                dayZafternoonText.text = rawlsianChoicesChinese[dayZafternoonCurrentChoiceNumber];
                break;
            case 2:
                dayZafternoonText.text = virtueEthicsChoicesChinese[dayZafternoonCurrentChoiceNumber];
                break;
            case 3:
                dayZafternoonText.text = neoliberalChoicesChinese[dayZafternoonCurrentChoiceNumber];
                break;
            case 4:
                dayZafternoonText.text = kantianChoicesChinese[dayZafternoonCurrentChoiceNumber];
                break;
        }
        switch (dayZeveningCurrentEthicsSchool)
        {
            case 0:
                dayZeveningText.text = utilitarianChoicesChinese[dayZeveningCurrentChoiceNumber];
                break;
            case 1:
                dayZeveningText.text = rawlsianChoicesChinese[dayZeveningCurrentChoiceNumber];
                break;
            case 2:
                dayZeveningText.text = virtueEthicsChoicesChinese[dayZeveningCurrentChoiceNumber];
                break;
            case 3:
                dayZeveningText.text = neoliberalChoicesChinese[dayZeveningCurrentChoiceNumber];
                break;
            case 4:
                dayZeveningText.text = kantianChoicesChinese[dayZeveningCurrentChoiceNumber];
                break;
        }

    }
    public void DisplayEnglish()
    {
        switch (dayXmorningCurrentEthicsSchool)
        {
            case 0:
                dayXmorningText.text = utilitarianChoices[dayXmorningCurrentChoiceNumber];
                break;
            case 1:
                dayXmorningText.text = rawlsianChoices[dayXmorningCurrentChoiceNumber];
                break;
            case 2:
                dayXmorningText.text = virtueEthicsChoices[dayXmorningCurrentChoiceNumber];
                break;
            case 3:
                dayXmorningText.text = neoliberalChoices[dayXmorningCurrentChoiceNumber];
                break;
            case 4:
                dayXmorningText.text = kantianChoices[dayXmorningCurrentChoiceNumber];
                break;
        }
        switch (dayXafternoonCurrentEthicsSchool)
        {
            case 0:
                dayXafternoonText.text = utilitarianChoices[dayXafternoonCurrentChoiceNumber];
                break;
            case 1:
                dayXafternoonText.text = rawlsianChoices[dayXafternoonCurrentChoiceNumber];
                break;
            case 2:
                dayXafternoonText.text = virtueEthicsChoices[dayXafternoonCurrentChoiceNumber];
                break;
            case 3:
                dayXafternoonText.text = neoliberalChoices[dayXafternoonCurrentChoiceNumber];
                break;
            case 4:
                dayXafternoonText.text = kantianChoices[dayXafternoonCurrentChoiceNumber];
                break;
        }
        switch (dayXeveningCurrentEthicsSchool)
        {
            case 0:
                dayXeveningText.text = utilitarianChoices[dayXeveningCurrentChoiceNumber];
                break;
            case 1:
                dayXeveningText.text = rawlsianChoices[dayXeveningCurrentChoiceNumber];
                break;
            case 2:
                dayXeveningText.text = virtueEthicsChoices[dayXeveningCurrentChoiceNumber];
                break;
            case 3:
                dayXeveningText.text = neoliberalChoices[dayXeveningCurrentChoiceNumber];
                break;
            case 4:
                dayXeveningText.text = kantianChoices[dayXeveningCurrentChoiceNumber];
                break;
        }
        switch (dayYmorningCurrentEthicsSchool)
        {
            case 0:
                dayYmorningText.text = utilitarianChoices[dayYmorningCurrentChoiceNumber];
                break;
            case 1:
                dayYmorningText.text = rawlsianChoices[dayYmorningCurrentChoiceNumber];
                break;
            case 2:
                dayYmorningText.text = virtueEthicsChoices[dayYmorningCurrentChoiceNumber];
                break;
            case 3:
                dayYmorningText.text = neoliberalChoices[dayYmorningCurrentChoiceNumber];
                break;
            case 4:
                dayYmorningText.text = kantianChoices[dayYmorningCurrentChoiceNumber];
                break;
        }
        switch (dayYafternoonCurrentEthicsSchool)
        {
            case 0:
                dayYafternoonText.text = utilitarianChoices[dayYafternoonCurrentChoiceNumber];
                break;
            case 1:
                dayYafternoonText.text = rawlsianChoices[dayYafternoonCurrentChoiceNumber];
                break;
            case 2:
                dayYafternoonText.text = virtueEthicsChoices[dayYafternoonCurrentChoiceNumber];
                break;
            case 3:
                dayYafternoonText.text = neoliberalChoices[dayYafternoonCurrentChoiceNumber];
                break;
            case 4:
                dayYafternoonText.text = kantianChoices[dayYafternoonCurrentChoiceNumber];
                break;
        }
        switch (dayYeveningCurrentEthicsSchool)
        {
            case 0:
                dayYeveningText.text = utilitarianChoices[dayYeveningCurrentChoiceNumber];
                break;
            case 1:
                dayYeveningText.text = rawlsianChoices[dayYeveningCurrentChoiceNumber];
                break;
            case 2:
                dayYeveningText.text = virtueEthicsChoices[dayYeveningCurrentChoiceNumber];
                break;
            case 3:
                dayYeveningText.text = neoliberalChoices[dayYeveningCurrentChoiceNumber];
                break;
            case 4:
                dayYeveningText.text = kantianChoices[dayYeveningCurrentChoiceNumber];
                break;
        }
        switch (dayZmorningCurrentEthicsSchool)
        {
            case 0:
                dayZmorningText.text = utilitarianChoices[dayZmorningCurrentChoiceNumber];
                break;
            case 1:
                dayZmorningText.text = rawlsianChoices[dayZmorningCurrentChoiceNumber];
                break;
            case 2:
                dayZmorningText.text = virtueEthicsChoices[dayZmorningCurrentChoiceNumber];
                break;
            case 3:
                dayZmorningText.text = neoliberalChoices[dayZmorningCurrentChoiceNumber];
                break;
            case 4:
                dayZmorningText.text = kantianChoices[dayZmorningCurrentChoiceNumber];
                break;
        }
        switch (dayZafternoonCurrentEthicsSchool)
        {
            case 0:
                dayZafternoonText.text = utilitarianChoices[dayZafternoonCurrentChoiceNumber];
                break;
            case 1:
                dayZafternoonText.text = rawlsianChoices[dayZafternoonCurrentChoiceNumber];
                break;
            case 2:
                dayZafternoonText.text = virtueEthicsChoices[dayZafternoonCurrentChoiceNumber];
                break;
            case 3:
                dayZafternoonText.text = neoliberalChoices[dayZafternoonCurrentChoiceNumber];
                break;
            case 4:
                dayZafternoonText.text = kantianChoices[dayZafternoonCurrentChoiceNumber];
                break;
        }
        switch (dayZeveningCurrentEthicsSchool)
        {
            case 0:
                dayZeveningText.text = utilitarianChoices[dayZeveningCurrentChoiceNumber];
                break;
            case 1:
                dayZeveningText.text = rawlsianChoices[dayZeveningCurrentChoiceNumber];
                break;
            case 2:
                dayZeveningText.text = virtueEthicsChoices[dayZeveningCurrentChoiceNumber];
                break;
            case 3:
                dayZeveningText.text = neoliberalChoices[dayZeveningCurrentChoiceNumber];
                break;
            case 4:
                dayZeveningText.text = kantianChoices[dayZeveningCurrentChoiceNumber];
                break;
        }

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
                    currentChoiceNumber = Random.Range(0, 9);
                    currentEthicsChoiceTextString = utilitarianChoices[currentChoiceNumber];
                    break;
                case 1:
                    currentChoiceNumber = Random.Range(0, 10);
                    currentEthicsChoiceTextString = rawlsianChoices[currentChoiceNumber];
                    break;
                case 2:
                    currentChoiceNumber = Random.Range(0, 9);
                    currentEthicsChoiceTextString = virtueEthicsChoices[currentChoiceNumber];
                    break;
                case 3:
                    currentChoiceNumber = Random.Range(0, 18);
                    currentEthicsChoiceTextString = neoliberalChoices[currentChoiceNumber];
                    break;
                case 4:
                    currentChoiceNumber = Random.Range(0, 9);
                    currentEthicsChoiceTextString = kantianChoices[currentChoiceNumber];
                    break;
            }

            for (int i = 0; i < rolledChoices.Length; i += 2)
            {
                if (rolledChoices[i] == currentEthicsSchoolNumber
                    &&
                    rolledChoices[i + 1] == currentChoiceNumber)
                {
                    choiceRolledRecently = true; //enable this when done testing
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
        choiceTallies[schoolToPlusPointsTo][chosenChoiceNumber] += 1;
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
                        utilitarianPoints += 4;
                        break;
                    case 7:
                        utilitarianPoints += 3;
                        break;
                    case 8:
                        utilitarianPoints += 2;
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
                    case 7:
                        rawlsianPoints += 5;
                        break;
                    case 8:
                        rawlsianPoints += 3;
                        break;
                    case 9:
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
                    case 13:
                        neoliberalPoints += 2;
                        break;
                    case 15:
                        neoliberalPoints += 4;
                        break;
                    case 17:
                        neoliberalPoints += 3;
                        break;
                    case 12:
                        neoliberalPoints += 4;
                        break;
                    case 14:
                        neoliberalPoints += 4;
                        break;
                    case 16:
                        neoliberalPoints += 3;
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
                    case 6:
                        virtueEthicsPoints += 4;
                        break;
                    case 7:
                        virtueEthicsPoints += 4;
                        break;
                    case 8:
                        virtueEthicsPoints += 4;
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
                    case 6:
                        kantianPoints += 2;
                        break;
                    case 7:
                        kantianPoints += 2;
                        break;
                    case 8:
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
                        utilitarianPoints -= 4;
                        break;
                    case 7:
                        utilitarianPoints -= 3;
                        break;
                    case 8:
                        utilitarianPoints -= 2;
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
                    case 7:
                        rawlsianPoints -= 5;
                        break;
                    case 8:
                        rawlsianPoints -= 3;
                        break;
                    case 9:
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
                    case 13:
                        neoliberalPoints -= 2;
                        break;
                    case 15:
                        neoliberalPoints -= 4;
                        break;
                    case 17:
                        neoliberalPoints -= 3;
                        break;
                    case 12:
                        neoliberalPoints -= 4;
                        break;
                    case 14:
                        neoliberalPoints -= 4;
                        break;
                    case 16:
                        neoliberalPoints -= 3;
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
                    case 6:
                        virtueEthicsPoints -= 4;
                        break;
                    case 7:
                        virtueEthicsPoints -= 4;
                        break;
                    case 8:
                        virtueEthicsPoints -= 4;
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
                    case 6:
                        kantianPoints -= 2;
                        break;
                    case 7:
                        kantianPoints -= 2;
                        break;
                    case 8:
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
            
            
            canvas.GetComponent<Animator>().Play("cbctograph");
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

            SetRadarChartLabelColors();

            verticeIndicatorsCBC[0] = GameObject.Find("RadarChart A").transform.GetChild(1).gameObject;
            verticeIndicatorsCBC[1] = GameObject.Find("RadarChart A").transform.GetChild(2).gameObject;
            verticeIndicatorsCBC[2] = GameObject.Find("RadarChart A").transform.GetChild(3).gameObject;
            verticeIndicatorsCBC[3] = GameObject.Find("RadarChart A").transform.GetChild(4).gameObject;
            verticeIndicatorsCBC[4] = GameObject.Find("RadarChart A").transform.GetChild(5).gameObject;

            verticeIndicatorsCBCB[0] = GameObject.Find("RadarChart B").transform.GetChild(1).gameObject;
            verticeIndicatorsCBCB[1] = GameObject.Find("RadarChart B").transform.GetChild(2).gameObject;
            verticeIndicatorsCBCB[2] = GameObject.Find("RadarChart B").transform.GetChild(3).gameObject;
            verticeIndicatorsCBCB[3] = GameObject.Find("RadarChart B").transform.GetChild(4).gameObject;
            verticeIndicatorsCBCB[4] = GameObject.Find("RadarChart B").transform.GetChild(5).gameObject;

            centroidCoordinateX = (verticeIndicatorsCBC[0].GetComponent<RectTransform>().anchoredPosition.x
                                        + verticeIndicatorsCBC[1].GetComponent<RectTransform>().anchoredPosition.x
                                        + verticeIndicatorsCBC[2].GetComponent<RectTransform>().anchoredPosition.x
                                        + verticeIndicatorsCBC[3].GetComponent<RectTransform>().anchoredPosition.x
                                        + verticeIndicatorsCBC[4].GetComponent<RectTransform>().anchoredPosition.x) / 5f;

            centroidCoordinateY = (verticeIndicatorsCBC[0].GetComponent<RectTransform>().anchoredPosition.y
                                        + verticeIndicatorsCBC[1].GetComponent<RectTransform>().anchoredPosition.y
                                        + verticeIndicatorsCBC[2].GetComponent<RectTransform>().anchoredPosition.y
                                        + verticeIndicatorsCBC[3].GetComponent<RectTransform>().anchoredPosition.y
                                        + verticeIndicatorsCBC[4].GetComponent<RectTransform>().anchoredPosition.y) / 5f;

            centroidPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(centroidCoordinateX, centroidCoordinateY);

            centroidCoordinateXB = (verticeIndicatorsCBCB[0].GetComponent<RectTransform>().anchoredPosition.x
                                        + verticeIndicatorsCBCB[1].GetComponent<RectTransform>().anchoredPosition.x
                                        + verticeIndicatorsCBCB[2].GetComponent<RectTransform>().anchoredPosition.x
                                        + verticeIndicatorsCBCB[3].GetComponent<RectTransform>().anchoredPosition.x
                                        + verticeIndicatorsCBCB[4].GetComponent<RectTransform>().anchoredPosition.x) / 5f;

            centroidCoordinateYB = (verticeIndicatorsCBCB[0].GetComponent<RectTransform>().anchoredPosition.y
                                        + verticeIndicatorsCBCB[1].GetComponent<RectTransform>().anchoredPosition.y
                                        + verticeIndicatorsCBCB[2].GetComponent<RectTransform>().anchoredPosition.y
                                        + verticeIndicatorsCBCB[3].GetComponent<RectTransform>().anchoredPosition.y
                                        + verticeIndicatorsCBCB[4].GetComponent<RectTransform>().anchoredPosition.y) / 5f;

            centroidPointB.GetComponent<RectTransform>().anchoredPosition = new Vector2(centroidCoordinateXB, centroidCoordinateYB);

            dataSenderScript.Send();
            canvas.GetComponent<Animator>().enabled = false;
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
        radarKantianLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color32(247, 235, 82, 255);
        radarNeoliberalLabel.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color32(242, 143, 201, 255);
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
        canvas.GetComponent<Animator>().enabled = true;

        choiceTallies[0] = new int[9]{0,0,0,0,0,0,0,0,0};
        choiceTallies[1] = new int[10]{0,0,0,0,0,0,0,0,0,0};
        choiceTallies[2] = new int[9]{0,0,0,0,0,0,0,0,0};
        choiceTallies[3] = new int[18]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        choiceTallies[4] = new int[9]{0,0,0,0,0,0,0,0,0};
        
        cbcCards.SetActive(false);
        endScreen.SetActive(false);
        nameAndSchool.SetActive(false);
        mainMenu.SetActive(true);
        

        rolledChoices = new int[34];

        choiceRolledRecently = false;

        rolledChoicePlaceSaver = 0;

        runsOfDoWhileChoiceRollLoop = 0;

        utilitarianPoints = 0;
        rawlsianPoints = 0;
        neoliberalPoints = 0;
        virtueEthicsPoints = 0;
        kantianPoints = 0;

        lowestEthicsSchoolScore = 0;
        highestEthicsSchoolPoints = 0;
        totalEthicsSchoolPoints = 0;

        currentRoundNumber = 1;

        AssignText();
        statPanel.SetActive(false);

        resultNumber = 0;
        resultStrings = new string[10];
        resultTimes = new string[10];

        grayLoadingBackground.SetActive(false);

        cbcCards.SetActive(false);
        endScreen.SetActive(false);
        nameAndSchool.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void OpenSite(int choiceOf9)
    {
        switch (choiceOf9)
        {
            case 0:
                switch (dayXmorningCurrentEthicsSchool)
                {
                    case 0:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/utilitarianism/utilitarian-choices/"
                        + dayXmorningCurrentChoiceNumber.ToString() +
                        "-utilitarian-choice");
                        break;
                    case 1:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/rawlsian-ethics/rawlsian-choices/"
                        + dayXmorningCurrentChoiceNumber.ToString() +
                        "-rawlsian-choice");
                        break;
                    case 2:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/virtue-ethics/virtue-ethics-choices/"
                        + dayXmorningCurrentChoiceNumber.ToString() +
                        "virtue-ethics-choice");
                        break;
                    case 3:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/neoliberal-ethics/neoliberal-choices/"
                        + dayXmorningCurrentChoiceNumber.ToString() +
                        "-neoliberal-choice");
                        break;
                    case 4:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/kantian-ethics/kantian-choices/"
                        + dayXmorningCurrentChoiceNumber.ToString() +
                        "-kantian-choice");
                        break;
                }
                break;
            case 1:
                switch (dayXafternoonCurrentEthicsSchool)
                {
                    case 0:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/utilitarianism/utilitarian-choices/"
                        + dayXafternoonCurrentChoiceNumber.ToString() +
                        "-utilitarian-choice");
                        break;
                    case 1:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/rawlsian-ethics/rawlsian-choices/"
                        + dayXafternoonCurrentChoiceNumber.ToString() +
                        "-rawlsian-choice");
                        break;
                    case 2:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/virtue-ethics/virtue-ethics-choices/"
                        + dayXafternoonCurrentChoiceNumber.ToString() +
                        "virtue-ethics-choice");
                        break;
                    case 3:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/neoliberal-ethics/neoliberal-choices/"
                        + dayXafternoonCurrentChoiceNumber.ToString() +
                        "-neoliberal-choice");
                        break;
                    case 4:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/kantian-ethics/kantian-choices/"
                        + dayXafternoonCurrentChoiceNumber.ToString() +
                        "-kantian-choice");
                        break;
                }
                break;
            case 2:
                switch (dayXeveningCurrentEthicsSchool)
                {
                    case 0:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/utilitarianism/utilitarian-choices/"
                        + dayXeveningCurrentChoiceNumber.ToString() +
                        "-utilitarian-choice");
                        break;
                    case 1:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/rawlsian-ethics/rawlsian-choices/"
                        + dayXeveningCurrentChoiceNumber.ToString() +
                        "-rawlsian-choice");
                        break;
                    case 2:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/virtue-ethics/virtue-ethics-choices/"
                        + dayXeveningCurrentChoiceNumber.ToString() +
                        "virtue-ethics-choice");
                        break;
                    case 3:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/neoliberal-ethics/neoliberal-choices/"
                        + dayXeveningCurrentChoiceNumber.ToString() +
                        "-neoliberal-choice");
                        break;
                    case 4:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/kantian-ethics/kantian-choices/"
                        + dayXeveningCurrentChoiceNumber.ToString() +
                        "-kantian-choice");
                        break;
                }
                break;
            case 3:
                switch (dayYmorningCurrentEthicsSchool)
                {
                    case 0:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/utilitarianism/utilitarian-choices/"
                        + dayYmorningCurrentChoiceNumber.ToString() +
                        "-utilitarian-choice");
                        break;
                    case 1:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/rawlsian-ethics/rawlsian-choices/"
                        + dayYmorningCurrentChoiceNumber.ToString() +
                        "-rawlsian-choice");
                        break;
                    case 2:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/virtue-ethics/virtue-ethics-choices/"
                        + dayYmorningCurrentChoiceNumber.ToString() +
                        "virtue-ethics-choice");
                        break;
                    case 3:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/neoliberal-ethics/neoliberal-choices/"
                        + dayYmorningCurrentChoiceNumber.ToString() +
                        "-neoliberal-choice");
                        break;
                    case 4:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/kantian-ethics/kantian-choices/"
                        + dayYmorningCurrentChoiceNumber.ToString() +
                        "-kantian-choice");
                        break;
                }
                break;
            case 4:
                switch (dayYafternoonCurrentEthicsSchool)
                {
                    case 0:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/utilitarianism/utilitarian-choices/"
                        + dayYafternoonCurrentChoiceNumber.ToString() +
                        "-utilitarian-choice");
                        break;
                    case 1:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/rawlsian-ethics/rawlsian-choices/"
                        + dayYafternoonCurrentChoiceNumber.ToString() +
                        "-rawlsian-choice");
                        break;
                    case 2:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/virtue-ethics/virtue-ethics-choices/"
                        + dayYafternoonCurrentChoiceNumber.ToString() +
                        "virtue-ethics-choice");
                        break;
                    case 3:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/neoliberal-ethics/neoliberal-choices/"
                        + dayYafternoonCurrentChoiceNumber.ToString() +
                        "-neoliberal-choice");
                        break;
                    case 4:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/kantian-ethics/kantian-choices/"
                        + dayYafternoonCurrentChoiceNumber.ToString() +
                        "-kantian-choice");
                        break;
                }
                break;
            case 5:
                switch (dayYeveningCurrentEthicsSchool)
                {
                    case 0:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/utilitarianism/utilitarian-choices/"
                        + dayYeveningCurrentChoiceNumber.ToString() +
                        "-utilitarian-choice");
                        break;
                    case 1:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/rawlsian-ethics/rawlsian-choices/"
                        + dayYeveningCurrentChoiceNumber.ToString() +
                        "-rawlsian-choice");
                        break;
                    case 2:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/virtue-ethics/virtue-ethics-choices/"
                        + dayYeveningCurrentChoiceNumber.ToString() +
                        "virtue-ethics-choice");
                        break;
                    case 3:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/neoliberal-ethics/neoliberal-choices/"
                        + dayYeveningCurrentChoiceNumber.ToString() +
                        "-neoliberal-choice");
                        break;
                    case 4:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/kantian-ethics/kantian-choices/"
                        + dayYeveningCurrentChoiceNumber.ToString() +
                        "-kantian-choice");
                        break;
                }
                break;
            case 6:
                switch (dayZmorningCurrentEthicsSchool)
                {
                    case 0:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/utilitarianism/utilitarian-choices/"
                        + dayZmorningCurrentChoiceNumber.ToString() +
                        "-utilitarian-choice");
                        break;
                    case 1:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/rawlsian-ethics/rawlsian-choices/"
                        + dayZmorningCurrentChoiceNumber.ToString() +
                        "-rawlsian-choice");
                        break;
                    case 2:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/virtue-ethics/virtue-ethics-choices/"
                        + dayZmorningCurrentChoiceNumber.ToString() +
                        "virtue-ethics-choice");
                        break;
                    case 3:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/neoliberal-ethics/neoliberal-choices/"
                        + dayZmorningCurrentChoiceNumber.ToString() +
                        "-neoliberal-choice");
                        break;
                    case 4:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/kantian-ethics/kantian-choices/"
                        + dayZmorningCurrentChoiceNumber.ToString() +
                        "-kantian-choice");
                        break;
                }
                break;
            case 7:
                switch (dayZafternoonCurrentEthicsSchool)
                {
                    case 0:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/utilitarianism/utilitarian-choices/"
                        + dayZafternoonCurrentChoiceNumber.ToString() +
                        "-utilitarian-choice");
                        break;
                    case 1:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/rawlsian-ethics/rawlsian-choices/"
                        + dayZafternoonCurrentChoiceNumber.ToString() +
                        "-rawlsian-choice");
                        break;
                    case 2:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/virtue-ethics/virtue-ethics-choices/"
                        + dayZafternoonCurrentChoiceNumber.ToString() +
                        "virtue-ethics-choice");
                        break;
                    case 3:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/neoliberal-ethics/neoliberal-choices/"
                        + dayZafternoonCurrentChoiceNumber.ToString() +
                        "-neoliberal-choice");
                        break;
                    case 4:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/kantian-ethics/kantian-choices/"
                        + dayZafternoonCurrentChoiceNumber.ToString() +
                        "-kantian-choice");
                        break;
                }
                break;
            case 8:
                switch (dayZeveningCurrentEthicsSchool)
                {
                    case 0:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/utilitarianism/utilitarian-choices/"
                        + dayZeveningCurrentChoiceNumber.ToString() +
                        "-utilitarian-choice");
                        break;
                    case 1:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/rawlsian-ethics/rawlsian-choices/"
                        + dayZeveningCurrentChoiceNumber.ToString() +
                        "-rawlsian-choice");
                        break;
                    case 2:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/virtue-ethics/virtue-ethics-choices/"
                        + dayZeveningCurrentChoiceNumber.ToString() +
                        "virtue-ethics-choice");
                        break;
                    case 3:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/neoliberal-ethics/neoliberal-choices/"
                        + dayZeveningCurrentChoiceNumber.ToString() +
                        "-neoliberal-choice");
                        break;
                    case 4:
                        Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools/kantian-ethics/kantian-choices/"
                        + dayZeveningCurrentChoiceNumber.ToString() +
                        "-kantian-choice");
                        break;
                }
                break;
            case 9:
                Application.OpenURL("https://sites.google.com/vis.tp.edu.tw/2023-g10a-pbl-legible-values/ethical-schools");
                break;
        }       
    }
    public void SetUpStrings()
    {
        //UTILITARIAN CHOICES
        //Brendan,Forest

        //Everyone wants equal happiness and help others.
        //(Utilitarianism)I help people to push the gold across and she give
        //me some gold and i help her and we are equal happiness.weight 3 //
        utilitarianChoices[0] = "You help an old person carry gold across the street. You do it because they will be safe, give you gold, and you will both be happy.";
        utilitarianChoicesChinese[0] = "你幫助一位老人將黃金推過馬路。 你這樣做是因為他們會安全，給你黃金，你們都會幸福。";        

        //Even though he might still get hurt, you make sure there’s the least harm possible.weight 3//
        utilitarianChoices[1] = "You save a person by pushing him off his bike when he's about to be hit by a car.";
        utilitarianChoicesChinese[1] = "當一個人即將被汽車撞到時，你可以透過將他從自行車上推下來來拯救他。";

        //Utilitarianism means you do things that make you most happy.weight 4 //
        utilitarianChoices[2] = "You kill 1 person to save 5 people. Because 5 people have more value than 1 person.";
        utilitarianChoicesChinese[2] = "你殺了 1 個人救了 5 個人。因為5個人比1個人更有價值。";

        //We should maximize happiness for ourselves and others.weight 3 //          
        utilitarianChoices[3] = "You go order a drink and instead of only buying for yourself, you also buy for 5 other people. Buying drinks for 5 people brings more happiness to them.";
        utilitarianChoicesChinese[3] = "你去點一杯飲料，不只給自己買，還買給其他 5 個人。為5個人購買飲料會為他們帶來更多的快樂。";
        //Everyone has the same value, so the more people,
        //the more your actions are worth.weight 5// 
        //third test comment
        utilitarianChoices[4] = "You perform in front of 200 people instead of 100. 200 people's happiness combined is more important than 100.";
        utilitarianChoicesChinese[4] = "你在200人面前表演,而不是在100人面前表演。200人的幸福加起來比100人的幸福更重要。";
        //You do this because you want everyone to be happy.
        utilitarianChoices[5] = "You buy food and share it with people that want it.";
        utilitarianChoicesChinese[5] = "您購買食物並與需要的人分享。";
        //When everyone comes into the classroom then there is air conditioning because being Utilitarianism we want everyone to be happy.
        utilitarianChoices[6] = "Go out and have have dinner with neighbors and my family";
        utilitarianChoicesChinese[6] = "出去和鄰居還有我的家人一起吃晚餐";
        //By:I can make my family happy and the neighbors happy too.(Fragment on Government Bentham 1776)
        utilitarianChoices[7] = "Go out and have have dinner with neighbors and my family";
        utilitarianChoicesChinese[7] = "出去和鄰居還有我的家人一起吃晚餐";

        utilitarianChoices[8] = "Celebrate halloween with my family.";
        utilitarianChoicesChinese[8] = "跟我的家人慶祝萬聖節";
        //---------------------------------------------------------------------------------------------------------------------------------------

        //RAWLSIAN CHOICES
        //Choices 1, 2, 4, 5, and 7 of the Rawlsian Liberalism School
        //Fifi, Cooper, Chelsea, and Annie

        //Your motivation comes from a desire to follow the agreement
        //made by you and your friend based on the Rawlsian liberalism that choices create agreement.
        //weight 1
        rawlsianChoices[0] = "When your friend refuses to lend you her eraser, you respect her choice.";
        rawlsianChoicesChinese[0] = "當你的朋友拒絕借你橡皮擦時，你尊重她的選擇。";

        //Your motivation comes from the desire to follow the
        //agreements held by everyone around you based on Rawlsian Liberalism.
        //weight 4
        rawlsianChoices[1] = "Everyone agrees to not steal the diamond on the pedestal, so you don't steal it because you respect this agreement.";
        rawlsianChoicesChinese[1] = "每個人都同意不偷底座上的鑽石，所以你不偷它，因為你尊重這個協議。";

        //Your motivation comes from that all the requirements should be
        //made without considering a specific club member individual’s perspective.
        //weight 3
        rawlsianChoices[2] = "You are a leader of a club, you decide to give each student an equal amount of supplies regardless of each individual.";
        rawlsianChoicesChinese[2] = "你是一個俱樂部的領導者，你決定為每個學生提供等量的用品，無論每個人如何。";

        //Your motivation comes from a desire to follow the
        //agreements of everyone based on Rawlsian Liberalism.
        //weight 2
        rawlsianChoices[3] = "In a room where people agree to speak only English, you only speak English because you respect this agreement.";
        rawlsianChoicesChinese[3] = "在一個人們同意只說英語的房間裡，你只說英語，因為你尊重這個協議。";

        //Your motivation comes from a desire to follow the law based on the
        //Rawlsian liberalism that law is an agreement and not murder is a requirement.
        //This is because requirements are not determined without determining your perspective.
        //weight 5
        rawlsianChoices[4] = "Someone is trying to murder you, but you decided not to beat back because you agree to the law to not kill people.";
        rawlsianChoicesChinese[4] = "有人試圖謀殺你，但你決定不反擊，因為你同意不殺人的法律。";

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
        rawlsianChoicesChinese[5] = "當每個人都同意在某個時間點熄燈時，你就會遵守。";

        rawlsianChoices[6] = "After using equipment in the gym, I will wipe it down.";
        rawlsianChoicesChinese[6] = "在健身房使用完器材後，我會把它擦乾淨。";

        rawlsianChoices[7] = "Had an agreement with my friends to go to the same restaurant. Everyone has an agreement on one thing.";
        rawlsianChoicesChinese[7] = "和我的朋友約定去同一家餐廳。每個人都在一件事上達成一致。";

        rawlsianChoices[8] = "To have interviews with classmates and teachers.";
        rawlsianChoicesChinese[8] = "訪問同學和老師。";

        rawlsianChoices[9] = "I am going to finish the poster on time according to the agreement between Me, and Annie.";
        rawlsianChoicesChinese[9] = "我會按照我和安妮的約定，按時完成海報。";
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
        neoliberalChoicesChinese[0] = "你選擇逃避危險而不是讓自己陷入危險.";


        //You do this because you believe that receiving an education overseas would be more beneficial to your career. Your motivation comes from a desire to follow neoliberalism/liberalism, based on what you yourself, as an individual, believe in, instead of others wishes. weight 4.//
        neoliberalChoices[1] = "You go abroad to study in an American university despite your grandparents' wishes for you to stay in Taiwan.";
        neoliberalChoicesChinese[1] = "儘管你的祖父母希望你留在台灣，但你卻出國到美國大學讀書.";

        //You are tired of renting a flat and depending on the landlord’s decisions. Your motivation comes from a desire to follow neoliberalism/liberalism, causing you to prefer owning things instead of depending on others. weight 4.//
        neoliberalChoices[2] = "You purchased a house along with the basic utilities to be installed.";
        neoliberalChoicesChinese[2] = "您購買了房屋以及要安裝的基本公用設施.";

        //You do this because you are hungry and want to eat something. Your motivation comes from a desire to follow neoliberalism/liberalism, which values a person’s freedom to exchange items with others under an agreement, opposed to just stealing items. weight 3 //
        neoliberalChoices[3] = "You pay money to eat at a restaurant, you receive food and catering services in return.";
        neoliberalChoicesChinese[3] = "你付錢去餐廳吃飯，你會得到食物和餐飲服務作為回報。";

        //You do this because you feel an urge to purchase whatever is hyped up. Your motivation comes from a desire to follow neoliberalism/liberalism, which enables a person to make free decisions without external influence. weight 2.//
        neoliberalChoices[4] = "You decided to spend part of your salary this month to buy celebrity endorsed products.";
        neoliberalChoicesChinese[4] = "你決定花這個月的部分薪水來購買名人代言的產品。";


        //You do this because neoliberalism values the ability for an indivudal to make choices freely, this can be expressed in many ways including the exchange of items.
        neoliberalChoices[11] = "You trade your BBQ with your friend.";
        neoliberalChoicesChinese[11] = "你和你的朋友交換你的烤肉。";

        //You do this because you believe in neoliberalism's core principle of trade and exchange under free will.
        neoliberalChoices[13] = "You buy a video game from store and you trade with him with 1000 dollar.";
        neoliberalChoicesChinese[13] = "你買了一個遊戲在一個店然後你賣給別人1000塊。";
        //Because you own your metro card and you decide if you want to walk into the metro station and walk out again when there are no people.
        neoliberalChoices[15] = "You own your metro card so you can decide if you want to get in and out of the station.";
        neoliberalChoicesChinese[15] = "您擁有地鐵卡，因此您可以決定是否進出車站。";
        //You buy slurpee for your classmate because the 7-Eleven is beside your house, and you charge 5 dollar to your classmate for bringing you the drink
        neoliberalChoices[17] = "You use 5 dollar to exchange for the delivery";
        neoliberalChoicesChinese[17] = "您用5塊換取送貨。";
        //-------------------------------------------------------------------------------------------------------------------------------------------
        /*
                NEOLIBERAL CHOICES (Team 2)
                Choices 5, 6, 7, 8 of the Neoliberalism/Liberalism school
                Adam, Chi, Angus
        */
        //monday left me broken tuesday i was through with hoping
        neoliberalChoices[5] = "You wanted to buy his glasses, he decided to sell them to you.";
        neoliberalChoicesChinese[5] = "你想買他的眼鏡，他決定賣給你。";
        //This makes sense to my values because I am in the neoliberalism school, and the glasses belong to him and he decided to sell them to me. weight 5

        neoliberalChoices[6] = "He tries to force you to teach him math, You decide not to teach him math.";
        neoliberalChoicesChinese[6] = "他試圖強迫你教他數學，你決定不教他數學。";
        //This makes sense to my values because I am in the neoliberalism school, and I have my own right to decide on my own if I want to teach him or not. weight 4

        neoliberalChoices[7] = "She wants to trade her pencil for your Rolex, but you don't think they are the same value. So you denied her trade offer.";
        neoliberalChoicesChinese[7] = "她想用她的鉛筆換你的勞力士，但你認為它們的價值不一樣。 所以你拒絕了她的交易提議。";
        //This makes sense to my values because I am in the neoliberalism school, and I can decide the value of things I own and if I want to trade them. weight 5

        neoliberalChoices[8] = "He tries to force you to trade pencils with him, and you decided that you didn't want to trade pencils with him.";
        neoliberalChoicesChinese[8] = "他試圖強迫您與他交易鉛筆，而您決定不想與他交易鉛筆。";
        //This makes sense to my values because I am in the neoliberalism school, and because we can only trade things if the choice is free I can decide not to trade with him because the trade isn't free. weight 4 

        neoliberalChoices[9] = "Mom is yelling that it’s time for dinner, but you think it's too early to have dinner, so you don't go to dinner.";
        neoliberalChoicesChinese[9] = "媽媽喊著吃晚餐了，你卻覺得吃晚餐太早了，所以就不去吃晚餐了。";
        //This makes sense to my values because I am in the neoliberalism school, and because I own myself and that gives me rights. weight 3
        neoliberalChoices[10] = "Today is the field trip. You felt exhausted today so you slept on the bus.";
        neoliberalChoicesChinese[10] = "今天是實地考察。 今天你覺得很累，所以你在公車上睡了一覺。";
        //This makes sense to my values because you own yourself and this agrees with “If I own my own body, I should be free to sleep whenever I want.” - Sandel, Justice, 2009. weight 3
        neoliberalChoices[12] = "You bring your own lunch to school because you don't want to spend money on lunch.";
        neoliberalChoicesChinese[12] = "你自己帶午餐去學校，因為你不想花錢買午餐。";
        //You do this because neoliberalism values the ability for an individual to make choices freely, and you choose to go buy dessert at 7-11.
        neoliberalChoices[14] = "In public you go to the 7-11 and buy dessert there.";
        neoliberalChoicesChinese[14] = "在公共場合你去7-11並在那裡買甜點。";
        neoliberalChoices[16] = "In public you decide to go to the gym to work out because you feel like you want to get stronger.";
        neoliberalChoicesChinese[16] = "在公共場合，您決定去健身房鍛煉，因為您覺得自己想要變得更強壯。";
        //-------------------------------------------------------------------------------------------------------------------------------------------

        // VIRTUE ETHICS CHOICES
        //Virtue Ethics team: Amber, Anna, Chelsea W, Irene
        //Your motivation comes from a desire to follow your parent’s example of being a calm person, based on the virtue ethics of Aristotle (imitate good people to be good). Weight 4
        virtueEthicsChoices[0] = "You want to be like your parent who handles conflicts civilly, so when hit you ask what's wrong and don't hit the person back.";
        virtueEthicsChoicesChinese[0] = "你想像你的父母一樣，以文明的方式處理衝突，所以當你被打的時候，你要問出了什麼問題，不要還手。";
        //Your motivation comes from a desire to model your classmate’s helpfulness, based on Aristotle’s virtue ethics. Weight 5
        virtueEthicsChoices[1] = "You pick up trash from the floor, which keeps the environment clean, because you saw someone do this and want to be like them.";
        virtueEthicsChoicesChinese[1] = "你撿起地上的垃圾，為了保證環境整潔，因為你看到別人這麼做你也跟這這麼做。";
        //Your motivation comes from a desire to get good grades, based on Confucius’s virtue ethics (孔子 says that it’s fine to be good for the sake of the result and not for goodness). Weight 5
        virtueEthicsChoices[2] = "After noticing the learning habits of a classmate who gets good grades, you turn studious because you want good grades too.";
        virtueEthicsChoicesChinese[2] = "在發現到成績好的同學的學習習慣後，你變得好學，因為你也想取得好成績。";
        //Weight 4
        virtueEthicsChoices[3] = "You gave food to a homeless man because you saw a celebrity do it and it seems like the right thing to do.";
        virtueEthicsChoicesChinese[3] = "你給一個無家可歸的人提供食物是因為你看到一個名人這樣做，而且這似乎是正確的做法。";
        //Weight 3      
        //Weight 3      
        virtueEthicsChoices[4] = "You study hard because you want to have a good future and it shows others how they can learn from you.";
        virtueEthicsChoicesChinese[4] = "你努力學習因為你想要有好的未來，並且你展示了其他人如何向你學習。";
        //This agrees with virtue ethics' idea of being good by following an example of good people (Athanassoulis, Internet Encyclopedia of Philosophy “Virtue Ethics”, n.d.).
        //Weight
        virtueEthicsChoices[5] = "You take part in the group project because this is what every teammate you've had did, helping your team finish the work faster.";
        virtueEthicsChoicesChinese[5] = "您幫忙了小組報告，因為這是您的每個隊友所須做的事情，可以幫助您的團隊更快地完成工作。";

        //This agrees with virtue ethics' idea of being good by following an example of good people.
        virtueEthicsChoices[6] = "You want to focus more on yourself because you want to be like a friend who doesn't poke their nose in other people's business.";
        virtueEthicsChoicesChinese[6] = "你想多關注自己，因為你想成為一個不干涉別人事務的朋友";
        //This decision fits the values of my team’s ethical school because I’m practicing honesty, which is commonly regarded as a virtue (Wilson, Honesty as a Virtue, 2018). Going to bed at a healthy time will improve my overall life quality without hurting anyone. Therefore, both decisions are something a virtuous person who practices honesty and self-discipline may do.
        virtueEthicsChoices[7] = "I'll sleep before 11:30pm for 2 days and honestly check  if I did to practice honesty and improve my life with self-discipline.";
        virtueEthicsChoicesChinese[7] = "我會連續兩天在晚上 11:30 之前睡覺，並誠實地檢查我是否實踐了誠實並通過自律改善了我的生活。";
        //I’ve read about people reading during short periods of free time. Reading during lunch break would fit in that category. So, I will be following what some people with habits I respect do, which fits virtue ethics (Athanasoulis, Virtue Ethics | Internet Encyclopedia of Philosophy, n.d.).
        virtueEthicsChoices[8] = "I will read a little during lunch break one day of the week because people whose blogs I read suggest it.";
        virtueEthicsChoicesChinese[8] = "我會在一週的某一天午休時間讀一點書，因為我讀過部落格的人建議我讀一讀。";





        //-------------------------------------------------------------------------------------------------------------------------------------------
        //KANTIAN CHOICES
        //Kantian Ethics team: Audrey, Carlson, David, Abby
        //Your motivation comes from Kantian Ethics thinking you should always do the right thing.Weight3
        kantianChoices[0] = "You feed a homeless man because he was starving.";
        kantianChoicesChinese[0] = "你給一個無家可歸的人食物因為他很飢餓";

        //Kantian Ethics thinks you have to do the right things though you will hurt people or yourself. Weight 1
        kantianChoices[1] = "You save a kid out of a drunken driver's path, preventing him from getting in an accident.";
        kantianChoicesChinese[1] = "您將一個孩子從酒駕司機行徑的路上救出來，防止他發生事故";

        //Your motivation comes from .Weight 2
        kantianChoices[2] = "You donate old toys to the local orphanage because they need it.";
        kantianChoicesChinese[2] = "您將舊玩具捐贈給當地的孤兒院，因為他們需要它。";

        //This is a good choice because everyone makes the same choice. Weight4
        kantianChoices[3] = "The entire class turned their assignments in on time.";
        kantianChoicesChinese[3] = "全班同學都按時交了作業。";

        //I did this because if I didn't pull him he might’ve fallen down and been hurt more. Weight3
        kantianChoices[4] = "You pulled a guy because he almost fell down.";
        kantianChoicesChinese[4] = "你拉了一個人，因為他差點摔倒了";

        //You do this because you don’t want to keep anyone from sitting with who they want. Weight5
        kantianChoices[5] = "You let others choose seats before yourself.";
        kantianChoicesChinese[5] = "您讓其他人先選擇座位。";

        //It promotes freedom of choice
        kantianChoices[6] = "I let others choose seats before myself";
        kantianChoicesChinese[6] = "我讓別人先選座位";
        //I do this because it is the right thing to do
        kantianChoices[7] = "I sort garbage correctly";
        kantianChoicesChinese[7] = "我準確分類垃圾";
        //As her child it is my duty to help her do chores
        kantianChoices[8] = "I help my mom do chores.";
        kantianChoicesChinese[8] = "我幫媽媽做家事。";



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
