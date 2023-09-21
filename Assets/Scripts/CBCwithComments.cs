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
using Unity.VisualScripting;
using UnityEngine.Networking;
using UCharts;

/* Beginning of the Script or Class
This is the beginning of the script or “class”
that will run in this file. It is called
CBCcontroller, because this script or class
Controls our CBC survey.
*/
public class CBCwithComments : MonoBehaviour
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

    //Example 0.1.4 weight
    public int dayXmorningCurrentChoiceNumber;
    public int dayXafternoonCurrentChoiceNumber;
    public int dayXeveningCurrentChoiceNumber;
    public int dayYmorningCurrentChoiceNumber;
    public int dayYafternoonCurrentChoiceNumber;
    public int dayYeveningCurrentChoiceNumber;
    public int dayZmorningCurrentChoiceNumber;
    public int dayZafternoonCurrentChoiceNumber;
    public int dayZeveningCurrentChoiceNumber;

    


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
    If we assign
    rawlsianChoices[3] = “Happy Birthday”,
    And
    rawlsianChoices[4] = “Goodbye”,
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
        utilitarianPoints = 15;
        rawlsianPoints = 15;
        neoliberalPoints = 15;
        virtueEthicsPoints = 15;
        kantianPoints = 15;

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
    }

    /* Update() method
    This method is Unity’s Update() method
    Anything we put in here will happen roughly 30 times a second
    It is empty right now and doesn't do anything.
    */
    public void Update()
    {

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
        //get a random choice from a random school
        AssignEthicsArrayandChoice();
        //assign that choice’s text to a text box
        dayXmorningText.text = currentEthicsChoiceTextString;
        //assign the ethics school to that text box
        dayXmorningCurrentEthicsSchool = currentEthicsSchoolNumber;

        //Day X Afternoon
        AssignEthicsArrayandChoice();
        dayXafternoonText.text = currentEthicsChoiceTextString;
        dayXafternoonCurrentEthicsSchool = currentEthicsSchoolNumber;

        //Day X Evening
        AssignEthicsArrayandChoice();
        dayXeveningText.text = currentEthicsChoiceTextString;
        dayXeveningCurrentEthicsSchool = currentEthicsSchoolNumber;

        //Day Y Morning
        AssignEthicsArrayandChoice();
        dayYmorningText.text = currentEthicsChoiceTextString;
        dayYmorningCurrentEthicsSchool = currentEthicsSchoolNumber;

        //Day Y Afternoon
        AssignEthicsArrayandChoice();
        dayYafternoonText.text = currentEthicsChoiceTextString;
        dayYafternoonCurrentEthicsSchool = currentEthicsSchoolNumber;

        //Day Y Evening
        AssignEthicsArrayandChoice();
        dayYeveningText.text = currentEthicsChoiceTextString;
        dayYeveningCurrentEthicsSchool = currentEthicsSchoolNumber;

        //Day Z Morning
        AssignEthicsArrayandChoice();
        dayZmorningText.text = currentEthicsChoiceTextString;
        dayZmorningCurrentEthicsSchool = currentEthicsSchoolNumber;

        //Day Z Afternoon
        AssignEthicsArrayandChoice();
        dayZafternoonText.text = currentEthicsChoiceTextString;
        dayZafternoonCurrentEthicsSchool = currentEthicsSchoolNumber;

        //Day Z Evening
        AssignEthicsArrayandChoice();
        dayZeveningText.text = currentEthicsChoiceTextString;
        dayZeveningCurrentEthicsSchool = currentEthicsSchoolNumber;

        
        EndScreenCheck();
        RefreshPointDisplay();
    }

    /* RefreshPointDisplay() method
    This updates the point numbers of each school shown on the screen.
    */
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

    /* ChooseDayY() method
    This method has been assigned in the Unity Editor to be
    Called when the Day Y button is pressed in the program.
    The Day Y button is the whole card for Day Y.


    This method sends the current ethics school of each text
    Choice on the Day X and Day Z cards to the MinusPoints method.
    This is to minus points from each school for each choice that belongs
    to them that the user did not pick, because they picked Day Y.
    */
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

    /* ChooseDayZ() method
    This method has been assigned in the Unity Editor to be
    Called when the Day Z button is pressed in the program.
    The Day Z button is the whole card for Day Z.

    This method sends the current ethics school of each text
    Choice on the Day X and Day Y cards to the MinusPoints method.
    This is to minus points from each school for each choice that belongs
    to them that the user did not pick, because they picked Day Z.
    */
    public void ChooseDayZ()
    {
         MinusPoints(dayXmorningCurrentEthicsSchool      ,   dayXmorningCurrentChoiceNumber);
        MinusPoints(dayXafternoonCurrentEthicsSchool    ,   dayXafternoonCurrentChoiceNumber);
        MinusPoints(dayXeveningCurrentEthicsSchool      ,   dayXeveningCurrentChoiceNumber);
        MinusPoints(dayYmorningCurrentEthicsSchool      ,   dayYmorningCurrentChoiceNumber);
        MinusPoints(dayYafternoonCurrentEthicsSchool    ,   dayYafternoonCurrentChoiceNumber);
        MinusPoints(dayYeveningCurrentEthicsSchool      ,   dayYeveningCurrentChoiceNumber);

        /* PlusPoints
        After it sends the Day X and Day Y text choices to get their points
        Minused, it will send the Day Z choices to get points added
        to their school in the PlusPoints Method.
        */
        PlusPoints(dayZmorningCurrentEthicsSchool       ,   dayZmorningCurrentChoiceNumber);
        PlusPoints(dayZafternoonCurrentEthicsSchool     ,   dayZafternoonCurrentChoiceNumber);
        PlusPoints(dayZeveningCurrentEthicsSchool       ,   dayZeveningCurrentChoiceNumber);

        /* +1 to currentRoundNumber
        We need to keep track of how many times the user has made a choice
        So we add 1 to the integer variable currentRoundNumber every time
        The user makes a day choice. We can use this number to decide when
        To stop the survey. Maybe after 20 choices, maybe after 30.
        */
        currentRoundNumber += 1;

        /* Call AssignText() Method
        This calls the Assigntext() Method to clear all the cards
        and randomly assign new choices to them for the next round.
        */
        AssignText();
    }

    /* Method AssignEthicsArrayandChoice()
    This method randomly chooses one of the five ethics schools
    And then randomly chooses one of the text choices from that school.
    */
    public void AssignEthicsArrayandChoice()
    {
        /* Choose Ethics School
        This assigns a random number between 0 and 4 to currentEthicsSchoolNumber
        0 is Utilitarianism
        1 is Rawlsian
        2 is Virtue Ethics
        3 is NeoLiberal
        4 is Kantian
        */
        currentEthicsSchoolNumber = Random.Range(0, 5);

        /* Switch Statement
        A Switch Statement takes a number (in this case currentEthicsSchoolNumber)
        And does things based on what the number is. In this switch statement
        There are 5 cases, which are case 0, case 1, case 2, case 3, and case 4.
        After the code currentEthicsSchoolNumber = Random.Range(0, 5); above gives
        Us a random ethics school, we use this switch statement to choose a random
        Text choice from the chosen school.
        */
        switch (currentEthicsSchoolNumber)
        {
            /* Random.Range(0, 5)
            If I want to show text in Unity on the screen,
            I can type
            dayXmorningText.text = rawlsianChoices[3];
            I can also type it like this:
            dayXmorningText.text = rawlsianChoices[Random.Range(0, 5)];
            To get a random Rawlsian Choice text from 0 to 4.
            This is because when you use Random.Range(0, 5),
            The highest number will not count as a possible result.
            Ex. Random.Range(0, 5) will give 0, 1, 2, 3, or 4.
            and Random.Range(0, 3) will give 0, 1, or 2.
            And Random.Range(-2, 2) will give -2, -1, 0, or 1.
            */
            case 0:            
                currentEthicsChoiceTextString = utilitarianChoices[Random.Range(0, 5)];
                break;
            case 1:
                currentEthicsChoiceTextString = rawlsianChoices[Random.Range(0, 5)];
                break;
            case 2:
                currentEthicsChoiceTextString = virtueEthicsChoices[Random.Range(0, 5)];
                break;
            /* case 3 random neoliberal choice 
            If currentEthicsSchoolNumber is randomly assigned 3, then
            This switch statement will run the code for “case 3”, which is
            currentEthicsChoiceTextString = neoliberalChoices[Random.Range(0, 10)];
            This will randomly pick a text choice from the NeoLiberal school and assign
            It to the string variable currentEthicsChoiceTextString.
            */
            case 3:
                currentEthicsChoiceTextString = neoliberalChoices[Random.Range(0, 10)];
                break;
            case 4:
                currentEthicsChoiceTextString = kantianChoices[Random.Range(0, 5)];
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
            case 0:
                utilitarianPoints += 4;
                break;
            case 1:
                rawlsianPoints += 4;
                break;
            case 2:
                neoliberalPoints += 4;
                break;
            case 3:
                virtueEthicsPoints += 4;
                break;
            case 4:
                kantianPoints += 4;
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
            case 0:
                utilitarianPoints -= 1;
                break;
            case 1:
                rawlsianPoints -= 1;
                break;
            case 2:
                neoliberalPoints -= 1;
                break;
            case 3:
                virtueEthicsPoints -= 1;
                break;
            case 4:
                kantianPoints -= 1;
                break;
        }
    }

    public void EndScreenCheck()
    {
        if(currentRoundNumber > 10)
        {
            cbcCards.SetActive(false);
            endScreen.SetActive(true);
            statPanel.SetActive(true);
            
            lowestEthicsSchoolScore = Mathf.Min(utilitarianPoints, rawlsianPoints, neoliberalPoints, virtueEthicsPoints, kantianPoints);

            utilitarianPoints   += Mathf.Abs(lowestEthicsSchoolScore);
            rawlsianPoints      += Mathf.Abs(lowestEthicsSchoolScore);
            neoliberalPoints    += Mathf.Abs(lowestEthicsSchoolScore);
            virtueEthicsPoints  += Mathf.Abs(lowestEthicsSchoolScore);
            kantianPoints       += Mathf.Abs(lowestEthicsSchoolScore);
            
            sliderRtoVE.value =     Mathf.InverseLerp(0, (rawlsianPoints     + virtueEthicsPoints)    , virtueEthicsPoints);
            sliderUtoR.value =      Mathf.InverseLerp(0, (utilitarianPoints  + rawlsianPoints)        , rawlsianPoints);
            sliderKtoU.value =      Mathf.InverseLerp(0, (kantianPoints      + utilitarianPoints)     , utilitarianPoints);
            sliderVEtoNL.value =    Mathf.InverseLerp(0, (virtueEthicsPoints + neoliberalPoints)      , neoliberalPoints);
            sliderNLtoK.value =     Mathf.InverseLerp(0, (neoliberalPoints   + kantianPoints)         , kantianPoints);
            
            sliderUtoVE.value =      Mathf.InverseLerp(0, (utilitarianPoints     + virtueEthicsPoints)     , virtueEthicsPoints);
            sliderVEtoK.value =      Mathf.InverseLerp(0, (virtueEthicsPoints     + kantianPoints)     , kantianPoints);
            sliderKtoR.value =      Mathf.InverseLerp(0, (kantianPoints      + rawlsianPoints)     , rawlsianPoints);
            sliderRtoNL.value =      Mathf.InverseLerp(0, (rawlsianPoints     + neoliberalPoints)     , neoliberalPoints);
            sliderNLtoU.value =      Mathf.InverseLerp(0, (neoliberalPoints     + utilitarianPoints)     , utilitarianPoints);

            totalEthicsSchoolPoints = utilitarianPoints + rawlsianPoints + neoliberalPoints + virtueEthicsPoints + kantianPoints;

            utilitarianPercentage.text  = (((float)utilitarianPoints  /(float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            rawlsianPercentage.text     = (((float)rawlsianPoints     /(float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            neoliberalPercentage.text   = (((float)neoliberalPoints   /(float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            virtueEthicsPercentage.text = (((float)virtueEthicsPoints /(float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            kantianPercentage.text      = (((float)kantianPoints      /(float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";

            numberOfWeeksAtEndTextDisplay.text = (currentRoundNumber - 1).ToString();

            highestEthicsSchoolPoints = Mathf.Max(utilitarianPoints , rawlsianPoints , neoliberalPoints , virtueEthicsPoints , kantianPoints);
            
            radarScript.m_Data = new List<float>    {  
                                                        ((float)rawlsianPoints      /(float)highestEthicsSchoolPoints),
                                                        ((float)utilitarianPoints   /(float)highestEthicsSchoolPoints),
                                                        ((float)kantianPoints       /(float)highestEthicsSchoolPoints),
                                                        ((float)neoliberalPoints    /(float)highestEthicsSchoolPoints),                                                        
                                                        ((float)virtueEthicsPoints  /(float)highestEthicsSchoolPoints),
                                                        ((float)virtueEthicsPoints  /(float)highestEthicsSchoolPoints)
                                                    }; 
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
    utilitarianChoices[3] = "camel";
    You can then use it to show text like:
    dayXafternoonText.text = utilitarianChoices[1];
    To show the text “dinosaur” in the dayXafternoon text box.
    */
    public void SetUpStrings()
    {
        /* Choice number Indicators
        If we ever need to see which choices belong to which school, we can
        comment out the area under this section, so that in the ethics
        calculator you will see the school and number of each choice.
        But you will not see the words of the choice statements.
        */
        utilitarianChoices[0] = "utilitarian Choice 1";
        utilitarianChoices[1] = "utilitarian Choice 2";
        utilitarianChoices[2] = "utilitarian Choice 3";
        utilitarianChoices[3] = "utilitarian Choice 4";
        utilitarianChoices[4] = "utilitarian Choice 5";

        rawlsianChoices[0] = "rawlsian Choice 1";
        rawlsianChoices[1] = "rawlsian Choice 2";
        rawlsianChoices[2] = "rawlsian Choice 3";
        rawlsianChoices[3] = "rawlsian Choice 4";
        rawlsianChoices[4] = "rawlsian Choice 5";

        neoliberalChoices[0] = "neo liberal Choice 1";
        neoliberalChoices[1] = "neo liberal Choice 2";
        neoliberalChoices[2] = "neo liberal Choice 3";
        neoliberalChoices[3] = "neo liberal Choice 4";
        neoliberalChoices[4] = "neo liberal Choice 5";
        neoliberalChoices[5] = "neo liberal Choice 6";
        neoliberalChoices[6] = "neo liberal Choice 7";
        neoliberalChoices[7] = "neo liberal Choice 8";
        neoliberalChoices[8] = "neo liberal Choice 9";
        neoliberalChoices[9] = "neo liberal Choice 10";

        virtueEthicsChoices[0] = "virtue Ethics Choice 1";
        virtueEthicsChoices[1] = "virtue Ethics Choice 2";
        virtueEthicsChoices[2] = "virtue Ethics Choice 3";
        virtueEthicsChoices[3] = "virtue Ethics Choice 4";
        virtueEthicsChoices[4] = "virtue Ethics Choice 5";

        kantianChoices[0] = "kantian Choice 1";
        kantianChoices[1] = "kantian Choice 2";
        kantianChoices[2] = "kantian Choice 3";
        kantianChoices[3] = "kantian Choice 4";
        kantianChoices[4] = "kantian Choice 5";

        /*
        These are the choice sentences that
        each group needs to change and make.
        If you change these sentences ,
        they will change in the ethics calculator.
        The numbers "0" and brackets "[]" show that
        these variables called "utilitarianChoices"
        and other names are arrays, or lists, of things.
        They are lists of strings.
        Strings means text or words or letters in Programming.
        Int is integer, which is a whole number, like "0" or "67: or "-3"
        Float is a number that is not whole, like "6.3" or "8.374"
        */

        //UTILITARIAN CHOICES
        //Brendan,Forest

        //Everyone wants equal happiness and help others.
        //(Utilitarianism)I help people to push the gold across and she give
        //me some gold and i help her and we are equal happiness.
        utilitarianChoices[0] = 
        "You help some old people to push gold across the street. You do it because they will give you gold and you will be happy.";

        //Utilitarianism means you do things that make you most happy.
        utilitarianChoices[2] = 
        "You kill 1 person to save 5 people. Because 5 people have more value than 1 person. So 5 people have more value than one.";

        //Utilitarianism thinks everyone have the some value.    
        utilitarianChoices[1] = 
        "There’s ten seconds left on the light, an old woman is halfway across the street. You help her cross the road.You make sure the woman is safe, so you're both happy..";

        //We should maximize happiness for ourselves and others.          
        utilitarianChoices[3] = 
        "You go to order a drink and instead of only buying for yourself, you also buy for 5 other people. Buying drinks for 5 people brings more happiness to them.";

        //Everyone has the same value, so the more people,
        //the more your actions are worth.
        utilitarianChoices[4] = 
        "You perform in front of 200 people instead of 100. 200 people’s happiness combined is more important than 100.";

        //---------------------------------------------------------------------------------------------------------------------------------------

        //RAWLSIAN CHOICES
        //Choices 1, 2, 4, 5, and 7 of the Rawlsian Liberalism School
        //Fifi, Cooper, Chelsea, and Annie

        //Your motivation comes from a desire to follow the agreement
        //made by you and your friend based on the Rawlsian liberalism that choices create agreement.
        rawlsianChoices[0] = 
        "You ask your friend for an eraser, but she refuses to give it to you, so you respect her choice. You respect their choice because you made an agreement.";

        //Your motivation comes from the desire to follow the
        //agreements held by everyone around you based on Rawlsian Liberalism.
        rawlsianChoices[1] = 
        "In a room of people of whom everyone believes that everyone shouldn’t steal from each other, so you don’t steal. You do this to respect the agreement of not stealing in this room.";

        //Your motivation comes from that all the requirements should be
        //made without considering a specific club member individual’s perspective.
        rawlsianChoices[2] = 
        "You are a leader of a club, you decide to give each student an equal amount of supplies regardless of who they are or what they individually need.";
        //rawlsianChoices[2] = "You give your team members equal supplies, regardless of their needs. You do this because equality is better than equity.";
        //Your motivation comes from a desire to follow the
        //agreements of everyone based on Rawlsian Liberalism.
        rawlsianChoices[3] = 
        "In a room where people agree to speak english and only english, you speak english. You do this because you want to respect the agreements held in the room you are in.";

        //Your motivation comes from a desire to follow the law based on the
        //Rawlsian liberalism that law is an agreement and not murder is a requirement.
        //This is because requirements are not determined without determining your perspective.
        rawlsianChoices[4] = 
        "Someone is trying to murder you, but you decide to not kill them to protect themselves. You decide not to kill them because of the law, which was agreed upon by most people.";

        //-------------------------------------------------------------------------------------------------------------------------------------------
        
        /*
        NEOLIBERAL CHOICES (Team 1)
        Choices 0, 1, 2, 3, 4 of the Neoliberalism/Liberalism school
        Eli, Alonzo, DarrenH
        */
        //where the colors go bruhhh
        //You instinctively do this because you value your life more than other people, hence you chose to protect yourself first before serving others. You do this because you believe in neoliberalism/liberalism, which values an individual's rights and ownership over everyone else.        
        neoliberalChoices[0] = 
        "You hide under the tables during a shooting, shielding yourself from the gunfire.";

        //You do this because you believe that receiving an education overseas would be more beneficial to your career. Your motivation comes from a desire to follow neoliberalism/liberalism, based on what you yourself, as an individual, believe in, instead of others wishes.
        neoliberalChoices[1] = 
        "You go abroad to study in an American university despite your grandparents' wishes for you to stay in Taiwan.";

        //You are tired of renting a flat and depending on the landlord’s decisions. Your motivation comes from a desire to follow neoliberalism/liberalism, causing you to prefer owning things instead of depending on others.
        neoliberalChoices[2] = 
        "You purchased a house along with the basic utilities to be installed.";

        //You do this because you are hungry and want to eat something. Your motivation comes from a desire to follow neoliberalism/liberalism, which values a person’s freedom to exchange items with others under an agreement, opposed to just stealing items.
        neoliberalChoices[3] = 
        "You pay money to eat at a restaurant, receiving food and service in exchange for your cash.";

        //You do this because you feel an urge to purchase whatever is hyped up. Your motivation comes from a desire to follow neoliberalism/liberalism, which enables a person to make free decisions without external influence.
        neoliberalChoices[4] = 
        "You spend an exorbitant amount of money on a celebrity endorsed product.";

        //-------------------------------------------------------------------------------------------------------------------------------------------

        /*
                NEOLIBERAL CHOICES (Team 2)
                Choices 5, 6, 7, 8, and 9 of the Neoliberalism/Liberalism school
                Adam, Chi, Angus
                */
        neoliberalChoices[5] = 
        "You wanted to buy his glasses, he decided to sell them to you.";
        //This makes sense to my values because I am in the neoliberalism school, and the glasses belong to him and he decided to sell them to me.

        neoliberalChoices[6] = 
        "He forces you to teach him math, You decide not to teach him math.";
        //This makes sense to my values because I am in the neoliberalism school, and I have my own right to decide on my own if I want to teach him or not.

        neoliberalChoices[7] = 
        "She wants to trade her pencil for your Rolex, but you don't think they are the same value. So you denied her trade offer.";
        //This makes sense to my values because I am in the neoliberalism school, and I can decide the value of things I own and if I want to trade them.

        neoliberalChoices[8] = 
        "He forced you to trade pencils with him, and you decided that you didn't want to trade pencils with him.";
        //This makes sense to my values because I am in the neoliberalism school, and because we can only trade things if the choice is free I can decide not to trade with him because the trade isn't free.

        neoliberalChoices[9] = 
        "You think it's too early to have dinner, so you didn't go to dinner. .";
        //This makes sense to my values because I am in the neoliberalism school, and because values are determined by how we trade this.

        //-------------------------------------------------------------------------------------------------------------------------------------------

        // VIRTUE ETHICS CHOICES
        //Virtue Ethics team: Amber, Anna, Chelsea W, Irene
        
        //Your motivation comes from a desire to follow your parent’s example of being a calm person, based on the virtue ethics of Aristtle (imitate good people to be good).
        virtueEthicsChoices[0] = 
        "A classmate punches you for no apparent reason. You react by calmly asking what’s wrong instead of punching them back, so the problem can be solved instead of escalated.";
        
        //Your motivation comes from a desire to model your classmate’s helpfulness, based on Aristotle’s virtue ethics.
        virtueEthicsChoices[1] = 
        "You help pick up trash from the floor, which keeps the environment clean and pleasant for everyone, because you saw a helpful classmate do this and you want to be helpful like them.";
        
        //Your motivation comes from a desire to get good grades, based on Confucius’s virtue ethics (孔子 says that it’s fine to be good for the sake of the result and not for goodness).
        virtueEthicsChoices[2] = 
        "You become hard-working after noticing the learning habits of a new classmate who always gets good grades. You act like your classmate because you want to get good grades, too.";

        virtueEthicsChoices[3] = 
        "You gave food to a homeless man because you saw Taylor Swift do it and it seems like the right thing to do. So you act like her.";

        //please add a decision here?
        virtueEthicsChoices[4] = 
        "CBC DECISION";

        //-------------------------------------------------------------------------------------------------------------------------------------------
        
        //KANTIAN CHOICES
        //Kantian Ethics team: Audrey, Carlson, David, Abby
        //Your motivation comes from Kantian Ethics thinking you should always do the right thing.
        kantianChoices[0] = 
        "A guy robs you and uses a knife to stab you but you don't fight back because you know hurting a person is not right .";

        //Kantian Ethics thinks you have to do the right things though you will hurt people or yourself.
        kantianChoices[1] = 
        "I kick a kid because he almost got hit by a car.";

        //Your motivation comes from the fact that you think he’s the best actor you have ever seen.
        kantianChoices[2] = 
        "You throw a rose at the actor. He is ecstatic.";

        //This is a good choice because everyone makes the same choice.
        kantianChoices[3] = 
        "The entire class turned their assignments in on time.";

        //I did this because if I didn't pull him he might’ve fallen down and been hurt more.
        kantianChoices[4] = 
        "I pulled a guy because he almost fell down.";
        
        //-------------------------------------------------------------------------------------------------------------------------------------------

        ///*
    }

}

//Background Color - 
//Card Color - 
//Game Text Color -
//Card Text Color -










