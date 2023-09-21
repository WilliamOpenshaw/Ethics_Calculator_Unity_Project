using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Networking;
using UCharts;
public class CBCnoComments : MonoBehaviour
{
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

    //Example 0.1.4 weight
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

    void Start()
    {
        utilitarianChoices = new string[5];
        rawlsianChoices = new string[5];
        neoliberalChoices = new string[10];
        virtueEthicsChoices = new string[5];
        kantianChoices = new string[5];


        utilitarianPoints = 15;
        rawlsianPoints = 15;
        neoliberalPoints = 15;
        virtueEthicsPoints = 15;
        kantianPoints = 15;

        currentRoundNumber = 1;

        SetUpStrings();

        AssignText();

        statPanel.SetActive(false);
    }

    public void SetName(string enteredName)
    {
        userName = enteredName;
        userNameTextDisplay.text = userName;
    }

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
                        utilitarianPoints += 5;
                        break; 
                    case 2:
                        utilitarianPoints += 5;
                        break; 
                    case 3:
                        utilitarianPoints += 5;
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
                        rawlsianPoints += 5;
                        break; 
                    case 1:
                        rawlsianPoints += 5;
                        break; 
                    case 2:
                        rawlsianPoints += 5;
                        break; 
                    case 3:
                        rawlsianPoints += 5;
                        break; 
                    case 4:
                        rawlsianPoints += 5;
                        break;           
                }
                break;
            //neoliberalPoints    
            case 2:
                switch (chosenChoiceNumber) 
                { 
                    case 0:
                        neoliberalPoints += 5;
                        break; 
                    case 1:
                        neoliberalPoints += 5;
                        break; 
                    case 2:
                        neoliberalPoints += 5;
                        break; 
                    case 3:
                        neoliberalPoints += 5;
                        break; 
                    case 4:
                        neoliberalPoints += 5;
                        break; 
                    case 5:
                        neoliberalPoints += 5;
                        break;  
                    case 6:
                        neoliberalPoints += 5;
                        break;  
                    case 7:
                        neoliberalPoints += 5;
                        break;  
                    case 8:
                        neoliberalPoints += 5;
                        break;  
                    case 9:
                        neoliberalPoints += 5;
                        break;            
                }
                break;
            //virtueEthicsPoints    
            case 3:
                switch (chosenChoiceNumber) 
                { 
                    case 0:
                        virtueEthicsPoints += 5;
                        break; 
                    case 1:
                        virtueEthicsPoints += 5;
                        break; 
                    case 2:
                        virtueEthicsPoints += 5;
                        break; 
                    case 3:
                        virtueEthicsPoints += 5;
                        break; 
                    case 4:
                        virtueEthicsPoints += 5;
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
                        kantianPoints += 5;
                        break; 
                    case 2:
                        kantianPoints += 5;
                        break; 
                    case 3:
                        kantianPoints += 5;
                        break; 
                    case 4:
                        kantianPoints += 5;
                        break;           
                }
                break;
        }
    }

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
                        utilitarianPoints -= 5;
                        break; 
                    case 2:
                        utilitarianPoints -= 5;
                        break; 
                    case 3:
                        utilitarianPoints -= 5;
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
                        rawlsianPoints -= 5;
                        break; 
                    case 1:
                        rawlsianPoints -= 5;
                        break; 
                    case 2:
                        rawlsianPoints -= 5;
                        break; 
                    case 3:
                        rawlsianPoints -= 5;
                        break; 
                    case 4:
                        rawlsianPoints -= 5;
                        break;           
                }
                break;
            //neoliberalPoints    
            case 2:
                switch (unChosenChoiceNumber) 
                { 
                     case 0:
                        neoliberalPoints += 5;
                        break; 
                    case 1:
                        neoliberalPoints += 5;
                        break; 
                    case 2:
                        neoliberalPoints += 5;
                        break; 
                    case 3:
                        neoliberalPoints += 5;
                        break; 
                    case 4:
                        neoliberalPoints += 5;
                        break; 
                    case 5:
                        neoliberalPoints += 5;
                        break;  
                    case 6:
                        neoliberalPoints += 5;
                        break;  
                    case 7:
                        neoliberalPoints += 5;
                        break;  
                    case 8:
                        neoliberalPoints += 5;
                        break;  
                    case 9:
                        neoliberalPoints += 5;
                        break;                  
                }
                break;
            //virtueEthicsPoints    
            case 3:
                switch (unChosenChoiceNumber) 
                { 
                    case 0:
                        virtueEthicsPoints -= 5;
                        break; 
                    case 1:
                        virtueEthicsPoints -= 5;
                        break; 
                    case 2:
                        virtueEthicsPoints -= 5;
                        break; 
                    case 3:
                        virtueEthicsPoints -= 5;
                        break; 
                    case 4:
                        virtueEthicsPoints -= 5;
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
                        kantianPoints -= 5;
                        break; 
                    case 2:
                        kantianPoints -= 5;
                        break; 
                    case 3:
                        kantianPoints -= 5;
                        break; 
                    case 4:
                        kantianPoints -= 5;
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

            lowestEthicsSchoolScore = Mathf.Min(utilitarianPoints, rawlsianPoints, neoliberalPoints, virtueEthicsPoints, kantianPoints);

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

            totalEthicsSchoolPoints = utilitarianPoints + rawlsianPoints + neoliberalPoints + virtueEthicsPoints + kantianPoints;

            utilitarianPercentage.text = (((float)utilitarianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            rawlsianPercentage.text = (((float)rawlsianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            neoliberalPercentage.text = (((float)neoliberalPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            virtueEthicsPercentage.text = (((float)virtueEthicsPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";
            kantianPercentage.text = (((float)kantianPoints / (float)totalEthicsSchoolPoints) * 100f).ToString("F0") + "%";

            numberOfWeeksAtEndTextDisplay.text = (currentRoundNumber - 1).ToString();

            highestEthicsSchoolPoints = Mathf.Max(utilitarianPoints, rawlsianPoints, neoliberalPoints, virtueEthicsPoints, kantianPoints);

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

    public void SetUpStrings()
    {
        //Everyone wants equal happiness and help others.
        //(Utilitarianism)I help people to push the gold across and she give
        //me some gold and i help her and we are equal happiness. weight 3
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










