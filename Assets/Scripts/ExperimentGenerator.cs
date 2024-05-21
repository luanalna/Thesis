using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using UXF;
using System.Xml;


public class ExperimentGenerator : MonoBehaviour
{
    // Canvas
    public Canvas startPanel;
    public Canvas paddlePanel;
    public Canvas endPanel;
    public Canvas endBlockPanel;

    // Buttons
    public Button startButton;
    public Button endButton;
    public Button endBlockButton;
    public Button continueButton;

    //Others
    public Target target;
    public CameraRotation viewCamera;
    public CSVManager CSVfile;
    public AdjustablePaddle adjustablePaddle;
    public Particles particles;


    // TIMING SETTInGS
    public static float startTime = 0.0f; // reset time when you click the start button
    public static float timeTargetToFall = 3.0f; // time for the ball to fall after spacebar is pressed
    public float deltaTime = 0.0f;


    // VECTORS
    public static Vector3[] targetStartingVelocities;
    public static Vector3[] startTargetPosition;


    float cameraRotationDirection = 1; // init camera rotation right
    float targetFallingDirection = 1; // init targwet falling direction right

    private bool isAnimationPlaying = false;
    private bool isWaitingForSubjectAnswer = false;
    private bool blockEnded = false;

    bool continueButtonPressed = false;
    bool startButtonPressed = false;
    bool endButtonPressed = false;
    bool nextBlockButtonPressed = false;
    bool startTimeOnClick = false;

    

    void Start() 
    {
        paddlePanel.gameObject.SetActive(false);
        startPanel.gameObject.SetActive(true);
        endPanel.gameObject.SetActive(false);
        particles.create = true;
        continueButton.onClick.AddListener(OnContinueClick);
        startButton.onClick.AddListener(OnStartClick);
        endButton.onClick.AddListener(OnEndClick);
        endBlockButton.onClick.AddListener(OnNextBlockClick);
    }

void Update()
{
    /* After the first presentation page (start()) is shown,
    keep everything in pause.
    
    If the continue button is pressed, and if there is valid data
    for a new experiment in the CSV file:
    Start the animation, wait the time it needs to be executed, reset everything,
    pop out the answer screen with the draggable stick. */

    if ((startButtonPressed || continueButtonPressed) && isNextTrialDataValid())
    {
        // Set the target velocity
        target.SetTarget(targetFallingDirection);

        // Set the camera velocity
        viewCamera.SetCamera(cameraRotationDirection);

        target.fall = true;

        // Start the animation 
        startPanel.gameObject.SetActive(false);

        isAnimationPlaying = true;
    }


    // UNTRIGGEER
    if (isAnimationPlaying == true);
    {
        target.fall
    }
    else if (isWaitingForSubjectAnswer)
    {
        paddlePanel.gameObject.SetActive(true);
    }
    else
    {
        // Additional logic if needed when neither animation is playing nor waiting for subject answer
    }
}



    else if (nextBlockButtonPressed) // Remove the semicolon here
    {
        // StartNewBlock();
    }
    else if (endButtonPressed) // Remove the semicolon here
    {
        // ExitAndSave();
    }
    bool isNextTrialDataValid()
    {
        
        /*
        this function checks the next trial data from csv file
        and returns a true in case of success and a false in case
        of failure
        */

        /* initialize return to false (fail)*/
        bool readDataSuccess = false;
        
        if (CSVfile.ReadCSV_row())
        {
            /* update experiment generator variables */
            cameraRotationDirection = CSVfile.CameraDir;
            targetFallingDirection = CSVfile.TargetDir;
            /* update return */
            readDataSuccess = true;
        }
        else{/*do nothing*/}
        return  readDataSuccess;
    }

    void OnContinueClick()
    {
        continueButtonPressed = true;
        startTimeOnClick = true;
    }
    void OnStartClick()
    {
        startButtonPressed = true;
        startTimeOnClick = true;
    }

    void OnNextBlockClick()
    {
        nextBlockButtonPressed = true;
        startTimeOnClick = true;
    }

    void OnEndClick()
    {
        endButtonPressed = true;
    }

    


