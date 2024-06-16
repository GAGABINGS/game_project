using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeMode : MonoBehaviour
{
    public TMP_Text TextMode;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            NormalMode();
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            SlowedMode();
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            StopedMode();
        }
    }

    void NormalMode()
    {
        TextMode.text = "Normaled";
        TextMode.color = Color.green;
        Time.timeScale = 1f;
    }

    void SlowedMode()
    {
        TextMode.text = "Slowed";
        TextMode.color = Color.yellow;
        Time.timeScale = 0.5f;
    }

    void StopedMode()
    {
        TextMode.text = "Stoped";
        TextMode.color = Color.red;
        Time.timeScale = 0f;
    }
}
