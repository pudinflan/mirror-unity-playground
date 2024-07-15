using UnityEngine;

namespace _MultiplayerTutorial
{
    public class NetworkManager : Mirror.NetworkManager
    {
        public override void OnStartServer()
        {
            Debug.Log("Server Started");
        }

        public override void OnStopServer()
        {
            Debug.Log("Server Stoped");
        }

        public override void OnClientConnect()
        {
            Debug.Log("Connected to server");
        }

        public override void OnClientDisconnect()
        {
            Debug.Log("Disconnected from server");
        }
    }
}
