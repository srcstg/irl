using UnityEngine;

namespace InRealLife.Character.Scripts
{
    /// <summary>
    /// Applies gravity to the character
    /// </summary>
    public class CharacterGravity : MonoBehaviour
    {
#pragma warning disable 0649
        [Header("Dependencies")]
        [SerializeField] CharacterController controller;
#pragma warning restore 0649        
        
        Vector3 velocity;
        
        void LateUpdate()
        {
            if(controller.isGrounded)
            {
                velocity.y = -2f;
            }
            else
            {
                velocity += Physics.gravity * Time.deltaTime;    
            }
            
            controller.Move(velocity * Time.deltaTime);
        }
    }
}