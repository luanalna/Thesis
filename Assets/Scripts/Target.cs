using UnityEngine;


public class Target : MonoBehaviour
{

    // initiali Target's positions
    public Vector3 startingTargetPosition = new Vector3(2f, 26f, 20f);
    // initial Target's fall velocity
    Vector3 fallVelocity = new Vector3(0f, 0f, 0f);

    public bool fall = false;

    void Start(){fall=false;}
    void Update()
    {
        if(fall) // let the target fall only if startTargetFalling is true
        {
            // Update Target's velocity
            fallVelocity.y -= Physics.gravity.magnitude * Time.deltaTime;
            // Update the Target's position
            transform.position += fallVelocity * Time.deltaTime + Physics.gravity * Time.deltaTime * Time.deltaTime * 0.5f;
        }
    }
    public void SetTarget(float dir)
    {
         // reset target's position
        transform.position = startingTargetPosition;
        // reset target's velocity
        fallVelocity.y *= dir; // vel y = vel y * dir;
    }

    // Overload SetTarget without parameters
    public void SetTarget()
    {
        SetTarget(1f); // Default direction value
    }
    public void startFalling()
    
    {
            fall = true;
    }

    public void stopFalling()
    {
            fall = false;
    }
}

