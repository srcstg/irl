using UnityEngine;

namespace InRealLife.Character.Scripts
{
    /// <summary>
    /// Handles the movement of the character using the virtual joystick
    /// </summary>
    public class CharacterMovement_Mobile : MonoBehaviour
    {
#pragma warning disable 0649
        [Header("Tunning")] 
        [SerializeField] CharacterTunning characterTunning;

        [Header("Dependencies")] 
        [SerializeField] Joystick virtualJoystick;
        [SerializeField] CharacterController controller;
        [SerializeField] Configuration config;
#pragma warning restore 0649
        Transform _myTransform;
        Transform myTransform
        {
            get
            {
                if (_myTransform == null)
                    _myTransform = GetComponent<Transform>();
                return _myTransform;
            }
        }

        
        void Update()
        {
            float z = virtualJoystick.Vertical;
            Vector3 move = myTransform.forward * (z * characterTunning.speed);
            controller.Move(move * Time.deltaTime);
        }
    }
}