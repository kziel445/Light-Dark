using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private static Points instance;
    public static Points GetInstance()
    {
        return instance;
    }
    public Transform LightsPath;
    private TMPro.TextMeshProUGUI pointsText;
    private int points;

    private void Awake()
    {
        instance = this;
        points = 0;
        pointsText = GetComponent<TMPro.TextMeshProUGUI>();
    }
    private void Start()
    {
        PointsTextFormat();
    }
    public void ChangePointsText(bool state)
    {
        if (state) points++;
        else points--;
        pointsText.text = PointsTextFormat();
    }

    public string PointsTextFormat()
    {
        return points.ToString() + "/" + LightsPath.childCount.ToString();
    }
}
