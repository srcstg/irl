using UnityEngine;

namespace InRealLife.Character.Scripts
{
    /// <summary>
    /// Handles the rotation of the character and camera with Mobile input
    /// </summary>
    public class CharacterLook_Mobile : MonoBehaviour
    {
#pragma warning disable 0649
        [Header("Tunning")] 
        [SerializeField] CharacterTunning characterTunning;
        [Header("Dependencies")]
        [SerializeField] Joystick virtualJoystick;
        [SerializeField] Transform cameraTransform;
        [SerializeField] Transform characterBody;
        [SerializeField] Configuration config;
#pragma warning restore 0649
        float xRotation = 0f;

        void Update()
        {
            float mouseX = virtualJoystick.Horizontal;
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            characterBody.Rotate(Vector3.up * mouseX);
        }
        
    }
}