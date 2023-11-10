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

        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        Debug.Log("Post Sent");

        yield return www.SendWebRequest();

    }
}

