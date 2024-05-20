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
    public Button endBlock;
    public Button continueButton;

    //Others
    public Target target;
    public CameraRotation viewCamera;
    public CSVManager CSVfile;
    public AdjustablePaddle adjustablePaddle;
    public Particles particles;


    // TIMING SETTINGS
    public static float timeAtBeginningSpacebarPress = 0.0f; // time when the subject is ready to start the experiment
    public static float timeTargetToFall = 3.0f; // time for the ball to fall after spacebar is pressed


    // VECTORS
    public static Vector3[] targetStartingVelocities;

    public static Vector3[] startTargetPosition;



    float cameraRotationDirection = 1; // init camera rotation right
    float targetFallingDirection = 1; // init targwet falling direction right

    private bool isAnimationPlaying = false;
    private bool isWaitingForSubjectAnswer = false;

    bool isContinueButtonPressed = false;
    bool isStartButtonPressed = false;
    bool isEndButtonPressed = false;
    bool isEndBlockButtonPressed = false;
    void Start() 
    {
        paddlePanel.gameObject.SetActive(false);
        startPanel.gameObject.SetActive(true);
        endPanel.gameObject.SetActive(false);
        particles.create = true;
        continueButton.onClick.AddListener(OnContinueClick);
        startButton.onClick.AddListener(OnStartClick);
        endButton.onClick.AddListener(OnContinueClick);
        endBlock.onClick.AddListener(OnContinueClick);
    }

    void Update()
    {
        /* after the first presentation page (start()) is showed, 
        keep everything in pause. 
        
        If continue button is pressed, and if
        There is valid data for a new experiment on the csv file:
        Start the animation, 
        wait the time it needs to be executed, reset everything,
        popout the answer screen with the draggable stick. */

        if(isStartButtonPressed && isNextTrialDataValid())
        {         
            
             // set the target velocity
            target.SetTarget(targetFallingDirection);

            // set the camera velocity
            viewCamera.SetCamera(cameraRotationDirection);

            //start the animation 
            startPanel.gameObject.SetActive(false);

            isStartButtonPressed = false;
        }

        else if (isContinueButtonPressed && isNextTrialDataValid())
        {
            // set the target velocity
            target.SetTarget(targetFallingDirection);

            // set the camera velocity
            viewCamera.SetCamera(cameraRotationDirection);

            //start the animatiion 
            startPanel.gameObject.SetActive(false);

        }

        // UNTRIGGEER
        if(isAnimationPlaying)
        {
            /* do nothing let the animation play */
            // update thee time
            
        }
        else if(isWaitingForSubjectAnswer)
        {

            paddlePanel.gameObject.SetActive(true);

        }
        else
        {

        }

            



        /* If continue button is pressed, and if
        There is valid data for a new experiment on the csv file,
        and if the answer have been recorderd,
        Start the animation: */


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

    void ShowAnimation()
    {
        isContinueButtonPressed = false;
        isAnimationPlaying = true;
        target.fall = true;
        viewCamera.rotate = true;
    }

    void OnContinueClick()
    {
        isContinueButtonPressed = true;
    }
    void OnStartClick()
    {
        isStartButtonPressed = true;
    }

}