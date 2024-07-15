using Mirror;
using UnityEngine;

namespace _Cubes
{
    public class Player : NetworkBehaviour
    {
        [SyncVar(hook = nameof(OnHelloCountChanged))] private int _helloCount = 0;
        
        private void Update()
        {
            HandleMovement();

            if (isLocalPlayer)
            {
                if (Input.GetKeyDown(KeyCode.H))
                {
                    Debug.Log("Sending Hello to Server!");
                    Hello();
                }
            }
        }

        private void HandleMovement()
        {
            if (isLocalPlayer)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");
                Vector3 movement = new Vector3(moveHorizontal * 0.1f, moveVertical * 0.1f, 0);
                transform.position += movement;
            }
        }

        [Command]
        private void Hello()
        {
            Debug.Log("Received Hello from Client!");

            _helloCount += 1;
            
            ReplyHello();
        }

        [TargetRpc]
        private void ReplyHello()
        {
            Debug.Log("Received Hello from server!");
        }

        [ClientRpc]
        private void TooHigh()
        {
            Debug.Log("too high!");
        }

        private void OnHelloCountChanged(int oldCount, int newCount)
        {
            Debug.Log($"We had {oldCount} hellos, but now we have {newCount} hellos");
        }
    }
}
