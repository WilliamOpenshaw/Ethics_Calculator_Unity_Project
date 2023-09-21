using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public bool targetModeActive;
    public GameObject mainCamera;
    public GameObject playerController;

    public GameObject dayXUI;
    public GameObject dayYUI;
    public GameObject dayZUI;

    public GameObject morningLabel;
    public GameObject afternoonLabel;
    public GameObject eveningLabel;

    public GameObject uiBackgroundImage;

    public GameObject throwingBall;

    public Transform handPosition;

    public float upForce;
    public float forwardForce;

    public GameObject playerSpawnPoint;

    public GameObject targetEnvironment;

    // Start is called before the first frame update
    void Start()
    {
        upForce = 8.0f;
        forwardForce = 30.0f;
        playerController.transform.position = playerSpawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetModeActive == true)
        {

        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newSphere = Instantiate(throwingBall, handPosition.position , Quaternion.identity);
            newSphere.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            //newSphere.GetComponent<Rigidbody>().AddForce(10, 10, 0, ForceMode.Impulse);
            newSphere.GetComponent<Rigidbody>().AddForce(playerController.transform.forward * forwardForce , ForceMode.Impulse);
            newSphere.GetComponent<Rigidbody>().AddForce(playerController.transform.up * upForce , ForceMode.Impulse);
            newSphere.GetComponent<Rigidbody>().AddForce(playerController.transform.right * 2.0f , ForceMode.Impulse);
            
        }
    }

    public void ToggleTargetMode(bool uiToggleState)
    {
        targetModeActive = uiToggleState;
        if(targetModeActive == true)
        {
            dayXUI.SetActive(false);
            dayYUI.SetActive(false);
            dayZUI.SetActive(false);
            morningLabel.SetActive(false);
            afternoonLabel.SetActive(false);
            eveningLabel.SetActive(false);
            uiBackgroundImage.SetActive(false);

            Cursor.lockState = CursorLockMode.Confined;

            targetEnvironment.SetActive(true);

            playerController.transform.position = playerSpawnPoint.transform.position;

            //playerController.SetActive(true);

            mainCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
        }
        else if (targetModeActive == false)
        {
            dayXUI.SetActive(true);
            dayYUI.SetActive(true);
            dayZUI.SetActive(true);
            morningLabel.SetActive(true);
            afternoonLabel.SetActive(true);
            eveningLabel.SetActive(true);
            uiBackgroundImage.SetActive(true);

            Cursor.lockState = CursorLockMode.None;

            //playerController.SetActive(false);

            mainCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
            playerController.transform.position = playerSpawnPoint.transform.position;

            targetEnvironment.SetActive(false);
        }
    }
}
