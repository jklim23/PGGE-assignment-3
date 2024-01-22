using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSoundController : MonoBehaviour
{
    
    public AudioClip[] FootstepSounds; // Array to hold footstep sound clips
    public float MinTimeBetweenFootsteps = 0.5f; // Minimum time between footstep sounds
    public float MaxTimeBetweenFootsteps = 0.6f; // Maximum time between footstep sounds
    public float RunSpeed = 0.1f;
    private AudioSource audioSource; // Reference to the Audio Source component
    public bool isWalking; // Flag to track if the player is walking
    public bool isRunning; // Flag to track if the player is walking
    private float TimeSinceLastFootstep; // Time since the last footstep sound
    public Transform Ftransform; //take the transform of the footsteo manager
    private void Awake()
    {
        
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
        isRunning = false;
        isWalking = false;
        
    }


    private void FixedUpdate()
    {
        ////Check if the player is walking
        if (isWalking && !isRunning)
        {
            Debug.Log("is walking");
            playSoundWithDifGroundType();

        }
        //check if the player is walking and running 
        if (isWalking && isRunning)
        {
            Debug.Log("is running");
            playSoundWithDifGroundType();

        }
        else
        {
            Debug.Log("is not walking");
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        
    }
    //public void StartRunning()
    //{
    //    isRunning = true;
    //}
    //public void StopRunning()
    //{
    //    isRunning = false;
    //}
    //public void StartWalking()
    //{
    //    isWalking = true;
    //}
    //public void StopWalking()
    //{
    //    isWalking = false;
    //}
    //function to play sound from an array of audio sources in random order from a range 
    private void playStepSound(int startIndex,int endIndex )
    {
        if (Time.time - TimeSinceLastFootstep >= 0.6f)
        {
            //Play a random footstep sound from the array
            AudioClip footstepSound = FootstepSounds[Random.Range(startIndex, endIndex)];
            audioSource.PlayOneShot(footstepSound);

            TimeSinceLastFootstep = Time.time; // Update the time since the last footstep sound
        }
    }
    //funtion to call playStepSound function based on the ground type
    private void playSoundWithDifGroundType()
    {
        if (Physics.Raycast(Ftransform.position, -Ftransform.up, out RaycastHit hit))
        {
            string hitTag = hit.transform.gameObject.tag;
            Debug.DrawRay(Ftransform.position, -Ftransform.up, Color.blue, 10f);
            //if its wood game object tag play the wood audio sounds 
            if (hitTag == "wood")
            {
                playStepSound(16, 21);
            }
            //if its sand game object tag play the sand audio sounds 
            else if (hitTag == "sand")
            {
                playStepSound(12, 15);
            }
            //if its metal game object tag play the metal audio sounds 
            else if (hitTag == "metal")
            {
                playStepSound(8, 11);
            }
            //if its dirt game object tag play the dirt audio sounds 
            else if (hitTag == "dirt")
            {
                playStepSound(4, 7);
            }
            //if its concrete game object tag play the conrete audio sounds 
            else if (hitTag == "concrete")
            {
                playStepSound(0, 3);
            }
        }
    }
}
