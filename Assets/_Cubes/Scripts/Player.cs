using Mirror;
using UnityEngine;

namespace _Cubes
{
    public class Player : NetworkBehaviour
    {
        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (!isLocalPlayer)
                return;

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal * 0.1f, moveVertical * 0.1f, 0);
            transform.position += movement;
        }
    }
}
