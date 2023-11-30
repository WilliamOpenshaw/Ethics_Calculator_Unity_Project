using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.UI;
public class DataSender : MonoBehaviour
{
    public CBCcontroller cbcScript;
    public string latitude = "no lat";
    public string longitude = "no long";

    string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdtPEIM_KLOsTPj8vRIdtGN3Zh6-LmLNxKU8AJCpj9FucIMMw/formResponse";

    //group is R, VE, K, NL, U, Undecided, or Test
    public string userName = "empty";
    public string group = "Test";
    public int rScore = 10;
    public int kScore = 20;
    public int nlScore = 30;
    public int uScore = 40;
    public int veScore = 50;

    public float centroidX = 0f;
    public float centroidY = 0f;   

    
    public void Start()
    {
        //Debug.Log("Starting Coroutine Find Location");
        StartCoroutine(FindLocation());
    }
    IEnumerator FindLocation()
    {
        //Debug.Log("Checking if location is enabled");
        // Check if the user has location service enabled.
        if (!Input.location.isEnabledByUser)
            yield break;

        // Starts the location service.
        //Debug.Log("Trying to start location service");
        Input.location.Start();

        // Waits until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            //Debug.Log("Timed out");
            print("Timed out");
            yield break;
        }

        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            //Debug.Log("Unable to determine device location");
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            //Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            latitude = Input.location.lastData.latitude.ToString();
            longitude = Input.location.lastData.longitude.ToString();
        }

        // Stops the location service if there is no need to query location updates continuously.
        Input.location.Stop();
    }

    public void Send()
    {
        
        StartCoroutine(Post());
    }

    IEnumerator Post()
    {
        yield return new WaitForSeconds(3.0f);

        userName = cbcScript.userName;
        group = cbcScript.userGroup;
        rScore = cbcScript.rawlsianPoints;
        uScore = cbcScript.utilitarianPoints;
        veScore = cbcScript.virtueEthicsPoints;
        nlScore = cbcScript.neoliberalPoints;
        kScore = cbcScript.kantianPoints;
        centroidX = cbcScript.centroidCoordinateX;
        centroidY = cbcScript.centroidCoordinateY;
        
        WWWForm form = new WWWForm();

        form.AddField("entry.1353047631", userName);
        form.AddField("entry.205765843", group);
        form.AddField("entry.1941289967", rScore);
        form.AddField("entry.1600336115", uScore);
        form.AddField("entry.1005102263", veScore);
        form.AddField("entry.1608873293", nlScore);
        form.AddField("entry.774927074", kScore);
        form.AddField("entry.486155804", centroidX.ToString());
        form.AddField("entry.457027932", centroidY.ToString());
        form.AddField("entry.1183135596", SystemInfo.deviceModel);
        form.AddField("entry.907664288", SystemInfo.deviceName);
        form.AddField("entry.1443394546", SystemInfo.deviceType.ToString());
        form.AddField("entry.1189217858", SystemInfo.deviceUniqueIdentifier);
        form.AddField("entry.1511207901", latitude);
        form.AddField("entry.1833503118", longitude);
        form.AddField("entry.1401316779", cbcScript.choiceTallies[0][0]);
        form.AddField("entry.1815227531", cbcScript.choiceTallies[0][1]);
        form.AddField("entry.1392333044", cbcScript.choiceTallies[0][2]);
        form.AddField("entry.171482940", cbcScript.choiceTallies[0][3]);
        form.AddField("entry.1777760764", cbcScript.choiceTallies[0][4]);
        form.AddField("entry.1760145998", cbcScript.choiceTallies[0][5]);
        form.AddField("entry.1986807934", cbcScript.choiceTallies[0][6]);
        form.AddField("entry.691769320", cbcScript.choiceTallies[0][7]);
        form.AddField("entry.1630351695", cbcScript.choiceTallies[0][8]);
        form.AddField("entry.1426186394", cbcScript.choiceTallies[1][0]);
        form.AddField("entry.1973965609", cbcScript.choiceTallies[1][1]);
        form.AddField("entry.1426788781", cbcScript.choiceTallies[1][2]);
        form.AddField("entry.934354430", cbcScript.choiceTallies[1][3]);
        form.AddField("entry.792146802", cbcScript.choiceTallies[1][4]);
        form.AddField("entry.301350437", cbcScript.choiceTallies[1][5]);
        form.AddField("entry.154445035", cbcScript.choiceTallies[1][6]);
        form.AddField("entry.1958067531", cbcScript.choiceTallies[1][7]);
        form.AddField("entry.1205890617", cbcScript.choiceTallies[1][8]);
        form.AddField("entry.1753789035", cbcScript.choiceTallies[1][9]);
        form.AddField("entry.326596123", cbcScript.choiceTallies[2][0]);
        form.AddField("entry.993009290", cbcScript.choiceTallies[2][1]);
        form.AddField("entry.1652288855", cbcScript.choiceTallies[2][2]);
        form.AddField("entry.303178475", cbcScript.choiceTallies[2][3]);
        form.AddField("entry.458770322", cbcScript.choiceTallies[2][4]);
        form.AddField("entry.818540433", cbcScript.choiceTallies[2][5]);
        form.AddField("entry.170506664", cbcScript.choiceTallies[2][6]);
        form.AddField("entry.715334802", cbcScript.choiceTallies[2][7]);
        form.AddField("entry.151507240", cbcScript.choiceTallies[2][8]);
        form.AddField("entry.33018445", cbcScript.choiceTallies[3][0]);
        form.AddField("entry.657224123", cbcScript.choiceTallies[3][1]);
        form.AddField("entry.1450634288", cbcScript.choiceTallies[3][2]);
        form.AddField("entry.1607819777", cbcScript.choiceTallies[3][3]);
        form.AddField("entry.1409592019", cbcScript.choiceTallies[3][4]);
        form.AddField("entry.2044956405", cbcScript.choiceTallies[3][5]);
        form.AddField("entry.821353146", cbcScript.choiceTallies[3][6]);
        form.AddField("entry.1442384448", cbcScript.choiceTallies[3][7]);
        form.AddField("entry.769722693", cbcScript.choiceTallies[3][8]);
        form.AddField("entry.2116383366", cbcScript.choiceTallies[3][9]);
        form.AddField("entry.1823269810", cbcScript.choiceTallies[3][10]);
        form.AddField("entry.1914070060", cbcScript.choiceTallies[3][11]);
        form.AddField("entry.335181392", cbcScript.choiceTallies[3][12]);
        form.AddField("entry.1331130476", cbcScript.choiceTallies[3][13]);
        form.AddField("entry.872011412", cbcScript.choiceTallies[3][14]);
        form.AddField("entry.1788472008", cbcScript.choiceTallies[3][15]);
        form.AddField("entry.376861715", cbcScript.choiceTallies[3][16]);
        form.AddField("entry.1691971700", cbcScript.choiceTallies[3][17]);
        form.AddField("entry.1816457745", cbcScript.choiceTallies[4][0]);
        form.AddField("entry.176344882", cbcScript.choiceTallies[4][1]);
        form.AddField("entry.1557485531", cbcScript.choiceTallies[4][2]);
        form.AddField("entry.110101234", cbcScript.choiceTallies[4][3]);
        form.AddField("entry.1487595523", cbcScript.choiceTallies[4][4]);
        form.AddField("entry.1745039299", cbcScript.choiceTallies[4][5]);
        form.AddField("entry.926731459", cbcScript.choiceTallies[4][6]);
        form.AddField("entry.494625668", cbcScript.choiceTallies[4][7]);
        form.AddField("entry.397602160", cbcScript.choiceTallies[4][8]);

        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        Debug.Log("Post Sent");

        yield return www.SendWebRequest();

    }
}

