﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;

public class SnapTool : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Starting screenshot...");
            captureScreenshot();
        }
        
    }

    public void captureScreenshot()
    {
        DateTime date = DateTime.Now;
        string filename = "Screen-" + date.Year + "-" + date.Month + "-" + date.Day + " " + date.Hour + "-" + date.Minute + "-" + date.Second + ".png";
        string path = Application.dataPath + "/Swift/StreamingAssets/Screenshots/" + filename;
        Debug.Log("Screenshot path: " + path);

        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);

        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();

        byte[] imageBytes = screenImage.EncodeToPNG();
        System.IO.File.WriteAllBytes(path, imageBytes);
    }
}