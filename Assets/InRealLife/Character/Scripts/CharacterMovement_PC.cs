using System;
using UnityEngine;

namespace InRealLife.Character.Scripts
{
    /// <summary>
    /// Handles the movement of the character using PC input
    /// </summary>
    public class CharacterMovement_PC : MonoBehaviour
    {
#pragma warning disable 0649
        [Header("Tunning")] 
        [SerializeField] CharacterTunning characterTunning;
        
        [Header("Dependencies")]
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

        void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void OnDisable()
        {
            
            Cursor.lockState = CursorLockMode.None;
        }

        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = (myTransform.right * x + myTransform.forward * z) * characterTunning.speed;
            controller.Move(move * Time.deltaTime);
        }
    }
}