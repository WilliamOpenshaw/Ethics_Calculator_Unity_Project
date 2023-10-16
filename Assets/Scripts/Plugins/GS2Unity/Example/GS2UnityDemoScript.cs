using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GS2UnityDemoScript : MonoBehaviour
{
    GoogleSheetsDB googleSheetsDB;
    public GoogleSheet txtSheet;

    public TextMeshProUGUI txt_1;
    public TextMeshProUGUI txt_2;
    public TextMeshProUGUI txt_3;

    string[][] googleSheetDataResultsForName;

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
        txt_1.text = txtSheet.GetRowData("1", "Name");
        txt_2.text = txtSheet.GetRowData("2", "Name");
        txt_3.text = txtSheet.GetRowData("3", "Name");
        
    }

    
}
