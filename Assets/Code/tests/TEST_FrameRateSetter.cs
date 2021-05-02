using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_FrameRateSetter : MonoBehaviour
{
    public int frameRate;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = frameRate;
    }
}
