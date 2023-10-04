// Version 0.1.6
/* Declaring Libraries
These statements up here are for stating what
Other scripts and libraries this script needs to use.
TMPro is a kind of visual UI text for Unity
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using Unity.VisualScripting;
using UnityEngine.Networking;
using UCharts;
using System;
using Random = UnityEngine.Random;

/* Beginning of the Script or Class
This is the beginning of the script or “class”
that will run in this file. It is called
CBCcontroller, because this script or class
Controls our CBC survey.
*/
public class CBCcontroller : MonoBehaviour
{
    /* Unity UI Text GameObjects
    These 9 things are UI text objects in unity.
    They are the 9 boxes of text on the 3 cards
    Here we are declaring them or willing them
    Into being and giving them life. We are also naming
    Them.
    They are “public” because this means we can control
    and see and change them in the Unity inspector window
    When we select the GameObject that this script is
    Attached to.
    */
    public TextMeshProUGUI dayXmorningText;
    public TextMeshProUGUI dayXafternoonText;
    public TextMeshProUGUI dayXeveningText;
    public TextMeshProUGUI dayYmorningText;
    public TextMeshProUGUI dayYafternoonText;
    public TextMeshProUGUI dayYeveningText;
    public TextMeshProUGUI dayZmorningText;
    public TextMeshProUGUI dayZafternoonText;
    public TextMeshProUGUI dayZeveningText;

    /* UI Text Objects for Showing number Scores
    These 5 properties or variables are also Text Objects
    In Unity. They are the numbers under the U, NL, K,
    VE, and R letters. These text boxes will show the points
    That the survey taker will have in each school.
    */
    public TextMeshProUGUI utilitarianNumberDisplay;
    public TextMeshProUGUI neoliberalNumberDisplay;
    public TextMeshProUGUI kantianNumberDisplay;
    public TextMeshProUGUI virtueethicsNumberDisplay;
    public TextMeshProUGUI rawlsianNumberDisplay;

    /* Integer Variables for Storing Numbers
    These 9 properties or variables are integers,
    or whole numbers. So they cannot be assigned
    Values like 0.8 or -3.5 or 23.4545. They can only
    have values like -64, -1, 0, 1, 3, 57. Numbers
    that are whole. These int(s) have been made
    and named because we need to know what school
    of ethics is represented by the current message
    In which spot. Like, we need to know that the
    Day X Morning Text Box slot on the card “Day X”
    Was randomly assigned the 4th school, which,
    in this script, is the neoliberal group. So, we
    Make a number variable called
    “dayXmorningCurrentEthicsSchool” and when
    dayXMorningText is assigned some text from
    A random school, we change the value of
    dayXmorningCurrentEthicsSchool to the number
    Of that school, which could be 0, 1, 2, 3, or 4.
    Because, in programming, sometimes it is
    Better to start counting from 0 instead of 1.
    */
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

    //Example 0.1.4 weight
    public int currentChoiceNumber;

    /* String Arrays
    If these variables just said
    “public string UtilitarianChoices”,
    Each one would just be one string.
    A string is a variable for holding text,
    Like “h”, “ghost”, “ehdu4yth4u3”, or even
    A space, “ “, like that.
    But these are not just 5 string variables.
    They have brackets after the “string” part,
    Like “string[]”. If you add brackets “[ ]” after
    String, you will make what is called an array.
    An array is a list of things that you can
    Make and call like List[item number 1], or
    List[Item number 2]. We do this by later giving
    Each of these arrays 5 empty spots in their list.
    Each of these spots can be any kind of text.
    If we assign rawlsianChoices[3] = “Happy Birthday”,
    And rawlsianChoices[4] = “Goodbye”,
    Then whenever we use rawlsianChoices[3], it will give
    Use the text “Happy Birthday”.
    */
    public string[] utilitarianChoices;
    public string[] rawlsianChoices;
    public string[] neoliberalChoices;
    public string[] virtueEthicsChoices;
    public string[] kantianChoices;

    /* Ethical School Points Variables
These 5 integer whole number variables
Are made to keep the number of points
for each group.
*/
    public int utilitarianPoints;
    public int rawlsianPoints;
    public int neoliberalPoints;
    public int virtueEthicsPoints;
    public int kantianPoints;

    /* Current Ethics Array Number
We will be giving this integer variable
The values 0, 1, 2, 3, or 4
To keep track of what the currently
Chosen ethics school is.
0 is Utilitarianism
1 is Rawlsian
2 is Virtue Ethics
3 is NeoLiberal
4 is Kantian
*/
    public int currentEthicsSchoolNumber;

    /* Current Ethics Choice Text String
When we are choosing choices from a school of ethics
We need to save what the current chosen ethics choice is
So we can apply it to a TextMeshProUGUI like dayYafternoonText
*/
    public string currentEthicsChoiceTextString;

    /* Current Round Number
    We will use this integer variable to keep track of how many rounds
    The user has done, or how many Days they have chosen.
    */
    public int currentRoundNumber;

    /* userName
When the user enters their name, unity editor has been set to call the
Method SetName(), which applies the name they entered to this string, userName.
*/
    public string userName;
    public TextMeshProUGUI userNameTextDisplay;
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
    public GameObject statPanel;
    public int lowestEthicsSchoolScore;
    public TextMeshProUGUI rawlsianPercentage;
    public TextMeshProUGUI utilitarianPercentage;
    public TextMeshProUGUI virtueEthicsPercentage;
    public TextMeshProUGUI neoliberalPercentage;
    public TextMeshProUGUI kantianPercentage;
    public TextMeshProUGUI numberOfWeeksAtEndTextDisplay;
    public int totalEthicsSchoolPoints;
    public RadarChart radarScript;
    public int highestEthicsSchoolPoints;

    public TextMeshProUGUI resultReferenceDisplayText;

    public int resultNumber;

    public string[] resultStrings;

    public string[] resultTimes;

    /* Start()
This is Unity’s Start() method. Any code we write in here runs one time when
The program starts. Before this part we have named all the variables above, 
so that they can be used in any method, like this one, Start(). 
*/
    void Start()
    {
        /* Assigning lengths to Arrays
If we assign these lengths here in the Start function, the ethical school arrays
Will have a certain number of spaces like [5] five spaces or [10] spaces.
If we dot not do this here, and we do it somewhere else in the script, other
Methods and code in this script will try 
and do stuff like get or change utilitarianChoices[1],
Before it has any spaces or any choices. If this happens, Unity will not run the 
program and there will be an error in the console window of the Unity Editor that
Will say “Index of array is out of bounds”, which means you are trying to get 
Utilitarian Choice number 2, utilitarianChoices[1], 
but that the array utilitarianChoices[] doesn’t have that space yet.
So we need to give each one the number of spaces it needs, or there will be an error.
*/
        utilitarianChoices = new string[5];
        rawlsianChoices = new string[5];
        neoliberalChoices = new string[10];
        virtueEthicsChoices = new string[5];
        kantianChoices = new string[5];

        /* Starting Points for Ethical Schools
These integers assign the starting score of each school at the beginning, so
That they are equal. The number is 0.
*/
        utilitarianPoints = 0;
        rawlsianPoints = 0;
        neoliberalPoints = 0;
        virtueEthicsPoints = 0;
        kantianPoints = 0;

        /* Reset current round number to zero
Just in case currentRoundNumber is not 1 at the beginning,
We set it to 1 to make sure it is one, and that it has a value.
If it does not have a set value, there might be an error.
*/
        currentRoundNumber = 1;

        /* Calling SetUpStrings() in Start()
SetUpStrings() is the method at the bottom of the script where
We entered our text choices for each school.
This method assigns the text of the choices we typed to
The string arrays we made.
*/
        SetUpStrings();

        /* Calling AssignText() in Start()
        This method randomly chooses a school of ethics 
        and a random choice from that school for every 
        text box in the X, Y, and Z Day Cards.
        */
        AssignText();
        statPanel.SetActive(false);

        resultNumber = 0;
        resultStrings = new string[10];
        resultTimes = new string[10];

    }
    /* SetName() method
SetName() takes what the user typed in Unity, 
makes it a string called enteredName, and then
Makes userName the same as enteredName
*/
    public void SetName(string enteredName)
    {
        userName = enteredName;
        userNameTextDisplay.text = userName;
    }

    /* AssignText() method
This method refreshes all the choices on the day cards at
The start and whenever a Day button is pressed, 
which means the user made a choice.
It calls the method AssignEthicsArrayandChoice();
To get a random school’s random choice text,
And then assigns that choice’s text to a text box.
Then it notes what school that choice is from for that
Text box
It does this 9 times, once for each of the 9 text boxes on
The three day cards.
*/
    public void AssignText()
    {
        //Day X Morning
        AssignEthicsArrayandChoice();
        dayXmorningText.text = currentEthicsChoiceTextString;
        dayXmorningCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayXmorningCurrentChoiceNumber = currentChoiceNumber;

        //Day X Afternoon
        AssignEthicsArrayandChoice();
        dayXafternoonText.text = currentEthicsChoiceTextString;
        dayXafternoonCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayXafternoonCurrentChoiceNumber = currentChoiceNumber;

        //Day X Evening
        AssignEthicsArrayandChoice();
        dayXeveningText.text = currentEthicsChoiceTextString;
        dayXeveningCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayXeveningCurrentChoiceNumber = currentChoiceNumber;

        //Day Y Morning
        AssignEthicsArrayandChoice();
        dayYmorningText.text = currentEthicsChoiceTextString;
        dayYmorningCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayYmorningCurrentChoiceNumber = currentChoiceNumber;

        //Day Y Afternoon
        AssignEthicsArrayandChoice();
        dayYafternoonText.text = currentEthicsChoiceTextString;
        dayYafternoonCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayYafternoonCurrentChoiceNumber = currentChoiceNumber;

        //Day Y Evening
        AssignEthicsArrayandChoice();
        dayYeveningText.text = currentEthicsChoiceTextString;
        dayYeveningCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayYeveningCurrentChoiceNumber = currentChoiceNumber;

        //Day Z Morning
        AssignEthicsArrayandChoice();
        dayZmorningText.text = currentEthicsChoiceTextString;
        dayZmorningCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayZmorningCurrentChoiceNumber = currentChoiceNumber;

        //Day Z Afternoon
        AssignEthicsArrayandChoice();
        dayZafternoonText.text = currentEthicsChoiceTextString;
        dayZafternoonCurrentEthicsSchool = currentEthicsSchoolNumber;
        dayZafternoonCurrentChoiceNumber = currentChoiceNumber;

        //Day Z Evening
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

    /* ChooseDayX() method
This method has been assigned in the Unity Editor to be
Called when the Day X button is pressed in the program.
The Day X button is the whole card for Day X.

This method sends the current ethics school of each text
Choice on the Day Z and Day Y cards to the MinusPoints method.
This is to minus points from each school for each choice that belongs
to them that the user did not pick, because they picked Day X.
*/
    public void ChooseDayX()
    {
        PlusPoints(dayXmorningCurrentEthicsSchool    ,  dayXmorningCurrentChoiceNumber);
        PlusPoints(dayXafternoonCurrentEthicsSchool  ,  dayXafternoonCurrentChoiceNumber);
        PlusPoints(dayXeveningCurrentEthicsSchool    ,  dayXeveningCurrentChoiceNumber);

        MinusPoints(dayYmorningCurrentEthicsSchool   ,  dayYmorningCurrentChoiceNumber);
        MinusPoints(dayYafternoonCurrentEthicsSchool ,  dayYafternoonCurrentChoiceNumber);
        MinusPoints(dayYeveningCurrentEthicsSchool   ,  dayYeveningCurrentChoiceNumber);
        MinusPoints(dayZmorningCurrentEthicsSchool   ,  dayZmorningCurrentChoiceNumber);
        MinusPoints(dayZafternoonCurrentEthicsSchool ,  dayZafternoonCurrentChoiceNumber);
        MinusPoints(dayZeveningCurrentEthicsSchool   ,  dayZeveningCurrentChoiceNumber);
        currentRoundNumber += 1;
        AssignText();
    }

    public void ChooseDayY()
    {
        MinusPoints(dayXmorningCurrentEthicsSchool      ,   dayXmorningCurrentChoiceNumber);
        MinusPoints(dayXafternoonCurrentEthicsSchool    ,   dayXafternoonCurrentChoiceNumber);
        MinusPoints(dayXeveningCurrentEthicsSchool      ,   dayXeveningCurrentChoiceNumber);

        PlusPoints(dayYmorningCurrentEthicsSchool       ,   dayYmorningCurrentChoiceNumber);
        PlusPoints(dayYafternoonCurrentEthicsSchool     ,   dayYafternoonCurrentChoiceNumber);
        PlusPoints(dayYeveningCurrentEthicsSchool       ,   dayYeveningCurrentChoiceNumber);

        MinusPoints(dayZmorningCurrentEthicsSchool      ,   dayZmorningCurrentChoiceNumber);
        MinusPoints(dayZafternoonCurrentEthicsSchool    ,   dayZafternoonCurrentChoiceNumber);
        MinusPoints(dayZeveningCurrentEthicsSchool      ,   dayZeveningCurrentChoiceNumber);

        currentRoundNumber += 1;
        AssignText();
    }

    public void ChooseDayZ()
    {
        MinusPoints(dayXmorningCurrentEthicsSchool      ,   dayXmorningCurrentChoiceNumber);
        MinusPoints(dayXafternoonCurrentEthicsSchool    ,   dayXafternoonCurrentChoiceNumber);
        MinusPoints(dayXeveningCurrentEthicsSchool      ,   dayXeveningCurrentChoiceNumber);
        MinusPoints(dayYmorningCurrentEthicsSchool      ,   dayYmorningCurrentChoiceNumber);
        MinusPoints(dayYafternoonCurrentEthicsSchool    ,   dayYafternoonCurrentChoiceNumber);
        MinusPoints(dayYeveningCurrentEthicsSchool      ,   dayYeveningCurrentChoiceNumber);

        PlusPoints(dayZmorningCurrentEthicsSchool       ,   dayZmorningCurrentChoiceNumber);
        PlusPoints(dayZafternoonCurrentEthicsSchool     ,   dayZafternoonCurrentChoiceNumber);
        PlusPoints(dayZeveningCurrentEthicsSchool       ,   dayZeveningCurrentChoiceNumber);

        currentRoundNumber += 1;

        AssignText();
    }
    /* Method AssignEthicsArrayandChoice()
This method randomly chooses one of the five ethics schools
And then randomly chooses one of the text choices from that school.
*/
    public void AssignEthicsArrayandChoice()
    {
        currentEthicsSchoolNumber = Random.Range(0, 5);
        switch (currentEthicsSchoolNumber)
        {
            case 0:
                currentChoiceNumber = Random.Range(0, 5);
                currentEthicsChoiceTextString = utilitarianChoices[currentChoiceNumber];
                break;
            case 1:
                currentChoiceNumber = Random.Range(0, 5);
                currentEthicsChoiceTextString = rawlsianChoices[currentChoiceNumber];
                break;
            case 2:
                currentChoiceNumber = Random.Range(0, 5);
                currentEthicsChoiceTextString = virtueEthicsChoices[currentChoiceNumber];
                break;
            case 3:
                currentChoiceNumber = Random.Range(0, 10);
                currentEthicsChoiceTextString = neoliberalChoices[currentChoiceNumber];
                break;
            case 4:
                currentChoiceNumber = Random.Range(0, 5);
                currentEthicsChoiceTextString = kantianChoices[currentChoiceNumber];
                break;
        }
    }
    /* PlusPoints() method
This method adds points to the school’s that the user picks choices of.
*/
    public void PlusPoints(int schoolToPlusPointsTo, int chosenChoiceNumber)
    {
        switch (schoolToPlusPointsTo)
        {
            //utilitarianPoints
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
                }
                break;
            //rawlsianPoints
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
                }
                break;
            //neoliberalPoints    
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
                }
                break;
            //virtueEthicsPoints    
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
                }
                break;
            //kantianPoints    
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
                }
                break;
        }
    }

    /* MinusPoints() method
This method subtracts points from the school’s that the user doesn’t pick the choices of.
*/
    public void MinusPoints(int schoolToMinusPointsFrom, int unChosenChoiceNumber)
    {
        switch (schoolToMinusPointsFrom)
        {
            //utilitarianPoints
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
                }
                break;
            //rawlsianPoints
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
                }
                break;
            //neoliberalPoints    
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
                }
                break;
            //virtueEthicsPoints    
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
                }
                break;
            //kantianPoints    
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
                }
                break;
        }
    }

    //This limits the amount of rounds to 10
    //We decided on 10 rounds because it is enough to give each school justice and still be engaging
    //
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

            utilitarianPoints += Mathf.Abs(lowestEthicsSchoolScore);
            rawlsianPoints += Mathf.Abs(lowestEthicsSchoolScore);
            neoliberalPoints += Mathf.Abs(lowestEthicsSchoolScore);
            virtueEthicsPoints += Mathf.Abs(lowestEthicsSchoolScore);
            kantianPoints += Mathf.Abs(lowestEthicsSchoolScore);

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

            totalEthicsSchoolPoints =   utilitarianPoints + 
                                        rawlsianPoints + 
                                        neoliberalPoints + 
                                        virtueEthicsPoints + 
                                        kantianPoints;

            utilitarianPercentage.text = (((float)utilitarianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            rawlsianPercentage.text = (((float)rawlsianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            neoliberalPercentage.text = (((float)neoliberalPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            virtueEthicsPercentage.text = (((float)virtueEthicsPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            kantianPercentage.text = (((float)kantianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";


            numberOfWeeksAtEndTextDisplay.text = (currentRoundNumber - 1).ToString();


            highestEthicsSchoolPoints = Mathf.Max(  utilitarianPoints, 
                                                    rawlsianPoints, 
                                                    neoliberalPoints, 
                                                    virtueEthicsPoints, 
                                                    kantianPoints);

            radarScript.m_Data = new List<float>    
            {
                ((float)rawlsianPoints      /(float)highestEthicsSchoolPoints),
                ((float)utilitarianPoints   /(float)highestEthicsSchoolPoints),
                ((float)kantianPoints       /(float)highestEthicsSchoolPoints),
                ((float)neoliberalPoints    /(float)highestEthicsSchoolPoints),
                ((float)virtueEthicsPoints  /(float)highestEthicsSchoolPoints)
            };

            resultNumber += 1;
            resultTimes[resultNumber] = DateTime.Now.ToString();
            resultStrings[resultNumber] = "Result " + (resultNumber).ToString() + " - " + resultTimes[resultNumber];
            resultReferenceDisplayText.text = resultStrings[resultNumber];
            
        }
    }

    /* SetUpStrings() method 
    This method, when it is called when the program starts, assigns text
    Strings to each of the spots in each ethical school’s string array.
    An array is a list of things.
    A string array, string[] , is a list of strings, which means “text”.
    An array starts with spot 0, and then spot 1, and then spot 2, and onwards…
    If you gave a string array 4 spots, with utilitarianChoices = new string[4]; 
    And you give them each a value like:
    utilitarianChoices[0] = "hippo";
    utilitarianChoices[1] = "dinosaur";
    utilitarianChoices[2] = "swan";
    utilitarianChoices[3] = "flamingo";
    You can then use it to show text like:
    dayXafternoonText.text = utilitarianChoices[1];
    To show the text “dinosaur” in the dayXafternoon text box.
    */
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
        utilitarianChoices[1] = "You save a person by pushing him off his bike when he’s about to be hit by a car.";

        //We should maximize happiness for ourselves and others.weight 3 //          
        utilitarianChoices[3] = "You go order a drink and instead of only buying for yourself, you also buy for 5 other people. Buying drinks for 5 people brings more happiness to them.";

        //Everyone has the same value, so the more people,
        //the more your actions are worth.weight 5// 
        utilitarianChoices[4] = "You perform in front of 200 people instead of 100. 200 people’s happiness combined is more important than 100.";

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
        rawlsianChoices[1] = "In a room of people of whom everyone agrees to not steal the diamond on the pedestal, so you don’t steal it because you respect this agreement.";

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
        rawlsianChoices[4] = "Someone is trying to murder you, but you decided to not kill them to protect yourself, since you shouldn’t murder in anycase, according to the unanimously agreed law.";

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
        rawlsianChoices[5] = "When everyone agrees to have lights out by a certain time, you will comply (field trip, at night, with all the roommates). You do this because you are obligated to follow the rules in the camp, regardless of whether you want to party at night or not.";

        //-------------------------------------------------------------------------------------------------------------------------------------------
        /*
       NEOLIBERAL CHOICES (Team 1)
       Publication #0005 Last Edit 0849z 21 SEP 23
        Choices 0, 1, 2, 3, 4 of the Neoliberalism/Liberalism school
        Eli, Alonzo, DarrenH
        */
        //You instinctively do this because you value your life more than other people, hence you chose to protect yourself first before serving others. You do this because you believe in neoliberalism/liberalism, which values an individual's rights and ownership over everyone else. weight 3//
        neoliberalChoices[0] = "Because you own yourself, and owning yourself gives you importance over others as an individual. You chose to run away from danger instead of putting yourself in it.";

        //You do this because you believe that receiving an education overseas would be more beneficial to your career. Your motivation comes from a desire to follow neoliberalism/liberalism, based on what you yourself, as an individual, believe in, instead of others wishes. weight 4.//
        neoliberalChoices[1] = "You go abroad to study in an American university despite your grandparents' wishes for you to stay in Taiwan.";

        //You are tired of renting a flat and depending on the landlord’s decisions. Your motivation comes from a desire to follow neoliberalism/liberalism, causing you to prefer owning things instead of depending on others. weight 4.//
        neoliberalChoices[2] = "You purchased a house along with the basic utilities to be installed.";

        //You do this because you are hungry and want to eat something. Your motivation comes from a desire to follow neoliberalism/liberalism, which values a person’s freedom to exchange items with others under an agreement, opposed to just stealing items. weight 3 //
        neoliberalChoices[3] = "You pay money to eat at a restaurant, you receive food and catering services in return.";

        //You do this because you feel an urge to purchase whatever is hyped up. Your motivation comes from a desire to follow neoliberalism/liberalism, which enables a person to make free decisions without external influence. weight 2.//
        neoliberalChoices[4] = "You decided to spend part of your salary this month to buy celebrity endorsed products.";

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

        neoliberalChoices[9] = "Mom is yelling that it’s time for dinner, but you think it's too early to have dinner, so you don’t go to dinner.";
        //This makes sense to my values because I am in the neoliberalism school, and because I own myself and that gives me rights. weight 3

        //-------------------------------------------------------------------------------------------------------------------------------------------

        // VIRTUE ETHICS CHOICES
        //Virtue Ethics team: Amber, Anna, Chelsea W, Irene
        //Your motivation comes from a desire to follow your parent’s example of being a calm person, based on the virtue ethics of Aristotle (imitate good people to be good). Weight 4
        virtueEthicsChoices[0] = "You calmly ask your classmate what’s wrong instead of punching them back when they punch you out of nowhere because you want to be like your parent who handles disagreements civilly.";
        //Your motivation comes from a desire to model your classmate’s helpfulness, based on Aristotle’s virtue ethics. Weight 5
        virtueEthicsChoices[1] = "You help pick up trash from the floor, which keeps the environment clean and pleasant for everyone, because you saw a helpful classmate do this and you want to be helpful like them.";
        //Your motivation comes from a desire to get good grades, based on Confucius’s virtue ethics (孔子 says that it’s fine to be good for the sake of the result and not for goodness). Weight 5
        virtueEthicsChoices[2] = "You become hard-working after noticing the learning habits of a new classmate who always gets good grades. You act like your classmate because you want to get good grades, too.";
        //Weight 4
        virtueEthicsChoices[3] = "You gave food to a homeless man because you saw Taylor Swift do it and it seems like the right thing to do. So you act like her.";

//Weight 3      
virtueEthicsChoices[4] = "You study hard because you want to have a good future and it shows others how they can learn from you.";

        //-------------------------------------------------------------------------------------------------------------------------------------------
        //KANTIAN CHOICES
        //Kantian Ethics team: Audrey, Carlson, David, Abby
        //Your motivation comes from Kantian Ethics thinking you should always do the right thing.Weight3
        kantianChoices[0] = "You feed a homeless man because he was starving.";

        //Kantian Ethics thinks you have to do the right things though you will hurt people or yourself. Weight 1
        kantianChoices[1] = "I kick a kid because he almost got hit by a car.";

        //Your motivation comes from .Weight 2
        kantianChoices[2] = "You donate old toys to the local orphanage because they need it.";

        //This is a good choice because everyone makes the same choice. Weight4
        kantianChoices[3] = "The entire class turned their assignments in on time.";

        //I did this because if I didn't pull him he might’ve fallen down and been hurt more. Wegihrnyt3
        kantianChoices[4] = "I pulled a guy because he almost fell down.";
        //-------------------------------------------------------------------------------------------------------------------------------------------
        
        ///*
    }
}
//Background Color 	- 	84CCE1
//Card Color 		- 	586994
//Game Text Color 	-	2D0320
//Card Text Color 	- 	FBFCF8


// Neoliberal 		- 	E06C9F
// Utilitarian 	-	2B4162
// Rawlsian 		-	6B0504
// Kantian 		- 	FFE1A8
// Virtue Ethics	- 	EDBFB7


