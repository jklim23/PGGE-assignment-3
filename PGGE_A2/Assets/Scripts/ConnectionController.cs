﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

namespace PGGE
{
    namespace Multiplayer
    {
        public class ConnectionController : MonoBehaviourPunCallbacks
        {
            const string gameVersion = "1";

            public byte maxPlayersPerRoom = 3;

            public GameObject mConnectionProgress;
            public GameObject mBtnJoinRoom;
            public GameObject mInpPlayerName;
            public AudioSource mAudioSource;
            bool isConnecting = false;

            void Awake()
            {
                // this makes sure we can use PhotonNetwork.LoadLevel() on 
                // the master client and all clients in the same 
                // room sync their level automatically
                PhotonNetwork.AutomaticallySyncScene = true;
            }


            // Start is called before the first frame update
            void Start()
            {
                mConnectionProgress.SetActive(false);
            }

            public void Connect()
            {
                mBtnJoinRoom.SetActive(false);
                mInpPlayerName.SetActive(false);
                mConnectionProgress.SetActive(true);

                //play audio on click 
                mAudioSource.Play();

                // we check if we are connected or not, we join if we are, 
                // else we initiate the connection to the server.
                if (PhotonNetwork.IsConnected)
                {
                    // Attempt joining a random Room. 
                    // If it fails, we'll get notified in 
                    // OnJoinRandomFailed() and we'll create one.
                    PhotonNetwork.JoinRandomRoom();
                }
                else
                {
                    // Connect to Photon Online Server.
                    isConnecting = PhotonNetwork.ConnectUsingSettings();
                    PhotonNetwork.GameVersion = gameVersion;
                }
            }
            public override void OnConnectedToMaster()
            {
                if (isConnecting)
                {
                    Debug.Log("OnConnectedToMaster() was called by PUN");
                    PhotonNetwork.JoinRandomRoom();
                }
            }

            public override void OnDisconnected(DisconnectCause cause)
            {
                Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}", cause);
                isConnecting = false;
            }

            public override void OnJoinRandomFailed(short returnCode, string message)
            {
                Debug.Log("OnJoinRandomFailed() was called by PUN. " +
                    "No random room available" +
                    ", so we create one by Calling: " +
                    "PhotonNetwork.CreateRoom");

                // Failed to join a random room.
                // This may happen if no room exists or 
                // they are all full. In either case, we create a new room.
                PhotonNetwork.CreateRoom(null,
                    new RoomOptions
                    {
                        MaxPlayers = maxPlayersPerRoom
                    });
            }

            public override void OnJoinedRoom()
            {
                Debug.Log("OnJoinedRoom() called by PUN. Client is in a room.");
                if (PhotonNetwork.IsMasterClient)
                {
                    Debug.Log("We load the default room for multiplayer");
                    PhotonNetwork.LoadLevel("MultiplayerMap00");
                }
            }

            //added a function to move the player from the Multiplayer_launcher scene back to the main menu
            public void BackToMenu()
            {
                //SceneManager.LoadScene("Menu");
                StartCoroutine(PlayClickSound("Menu"));
                
            }
            IEnumerator PlayClickSound(string scene)
            {
                mAudioSource.Play();
                yield return new WaitForSeconds(1);
                SceneManager.LoadScene(scene);
            }
        }
    }
}
