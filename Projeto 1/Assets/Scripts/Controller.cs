using UnityEngine;
using UnityEngine.UI; // You need to add this line to access Text component.

public class Controller : MonoBehaviour // Corrected the class name to "Controller"
{
    public Text timeText;
    public float timecnt;
    public bool timeOver = false;


    public void RefreshScreen()
    {
        timeText.text = timecnt.ToString("F0");
    }

    void TimeCount()
    {
        timecnt += Time.deltaTime; // Removed the parentheses after Time.deltaTime
        RefreshScreen();
    }

    private void Update() // Corrected the capitalization of "Update"
    {
        TimeCount();
    }

}
