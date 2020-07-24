using UnityEngine;
using UnityEngine.UI;

public class TutorialLeader : MonoBehaviour
{
    public Text UI_dir;

    //int module = 1;
    int step = 1;
    //int substep = 1;
    //int subsubstep = 1;
    //float timer;
    bool stepSetup = false;

    //Set these to the relevant layers number in the inspector
    [SerializeField] int InteractLayer = 8;
    [SerializeField] int DefaultLayer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(UI_dir);
        Valve = pipe_creator.GetComponent<PipeCreator>().Valve;
    }

    // Update is called once per frame
    void Update()
    {
        stepHandler();
    }

    void stepHandler()
    {
        switch (step)
        {
            case 1:
                step1();
                break;
            case 2:
                if (stepSetup == false)
                {
                    UI_dir.text = "Proof-of-Concept Complete!";
                    stepSetup = true;
                }
                break;
            default:
                UI_dir.text = "Error in Programming";
                break;
        }
    }

    //Create a variable for every gameobject that will be interacted with
    public GameObject pipe_creator; //Need to extract valve from this in Start()
    private GameObject Valve;

    //Step Setup Functions
    //Things that initialize that step's parts.
    //Remember to set stepSetup to true! 
    private void step1setup()
    {
        Debug.Log("Step 1 Setup");
        Valve.layer = InteractLayer;
        stepSetup = true;
    }

    //Step Monitoring Functions
    //Check what tasks must be completed, then set UI Directions based on that
    //If everything is done, advance to the next step by increasing int step and setting bool stepSetup to false. 
    private void step1()
    {
        //Call Setup function if not done yet
        if (stepSetup == false)
            step1setup();

        //Create list of sub-tasks that will appear on screen
        string text = "Steps to do:";
        if (Valve.activeSelf)
            text += "\n-Click on the valve.";
        else text += "\n-Click on the valve. --Done!";

        UI_dir.text = text;

        //Check if sub-tasks for the step are done, and move on if so
        if (!Valve.activeSelf)
        {
            step++;
            stepSetup = false;
        }
        Debug.Log(step);
    }
}