using UnityEngine;

namespace InRealLife.Character.Scripts
{
    /// <summary>
    /// Handles the rotation of the character and camera with PC input
    /// </summary>
    public class CharacterLook_PC : MonoBehaviour
    {
#pragma warning disable 0649
        [Header("Tunning")] 
        [SerializeField] CharacterTunning characterTunning;
        
        [Header("Dependencies")]
        [SerializeField] Transform cameraTransform;
        [SerializeField] Transform characterBody;
        [SerializeField] Configuration config;
#pragma warning restore 0649
        float xRotation = 0f;

        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * characterTunning.rotationSensitivity.x * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * characterTunning.rotationSensitivity.y * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -45f, 45f);
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            characterBody.Rotate(Vector3.up * mouseX);
        }

    }
}