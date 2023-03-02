using UnityEngine;
using System.IO;
using System.Diagnostics;
using System.Text;

public class LogProfiler : MonoBehaviour
{
    // private
    private StreamWriter writer;
    private Stopwatch stopwatch;
    private int lines = 0;
    private StringBuilder toWrite;

    // public 
    public string logFileName;
    public float benchmarkTime = 5f;

    private bool shouldWrite = false;

    void Start()
    {
        logFileName = GameManager.getInstance().getCollisionMethod().ToString() +  "_" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt";
        toWrite = new StringBuilder();
        stopwatch = new Stopwatch();
        writer = new StreamWriter(logFileName);
        UnityEngine.Debug.Log("Started logging");
        stopwatch.Start();
        shouldWrite = true;
    }

    void Update()
    {
        if(!shouldWrite) return;
        // print frametime instead of fps
        toWrite.Append(Time.deltaTime.ToString(
            // 10 decimal places
            "F10"
        ) + ",\n");

        lines++;

        // 30 seconds after the game starts, stop logging
        if (stopwatch.Elapsed.Seconds > benchmarkTime - 0.2f)
        {
            shouldWrite = false;
            writer.WriteLine(toWrite.ToString());
            stopwatch.Stop();
            // get amount of lines in the file
            // write the amount of lines to the file
            writer.WriteLine("Average FPS: " + (lines - 4) / stopwatch.Elapsed.TotalSeconds);
            writer.WriteLine("Total benchmark time: " + stopwatch.Elapsed.TotalSeconds);
            writer.Close();
            UnityEngine.Debug.Log("Stopped logging");
            // stop playing the game
            Application.Quit();

            // stop playmode
            // UnityEditor.EditorApplication.isPlaying = false;
        }
    }

}
