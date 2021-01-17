using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using UnityEngine;

namespace InRealLife.Character.Scripts
{
    /// <summary>
    /// Detects if the input comes from PC (keyboard) or Mobile (mouse) and updates the value in the configuration
    /// </summary>
    public class InputTypeDetection : MonoBehaviour
    {
#pragma warning disable 0649
        [Header("Dependencies")]
        [SerializeField] Joystick virtualJoystick;
        [SerializeField] Configuration config;
#pragma warning restore 0649

        CharacterMovement_PC _characterMovementPC;
        CharacterMovement_PC characterMovementPC
        {
            get
            {
                if (_characterMovementPC == null)
                    _characterMovementPC = GetComponent<CharacterMovement_PC>();
                return _characterMovementPC;
            }
        }

        CharacterMovement_Mobile _characterMovementMobile;
        CharacterMovement_Mobile characterMovementMobile
        {
            get
            {
                if (_characterMovementMobile == null)
                    _characterMovementMobile = GetComponent<CharacterMovement_Mobile>();
                return _characterMovementMobile;
            }
        }

        CharacterLook_PC _characterLookPC;
        CharacterLook_PC characterLookPC
        {
            get
            {
                if (_characterLookPC == null)
                    _characterLookPC = GetComponent<CharacterLook_PC>();
                return _characterLookPC;
            }
        }

        CharacterLook_Mobile _characterLookMobile;
        CharacterLook_Mobile characterLookMobile
        {
            get
            {
                if (_characterLookMobile == null)
                    _characterLookMobile = GetComponent<CharacterLook_Mobile>();
                return _characterLookMobile;
            }
        }


        [DllImport("__Internal")]
        private static extern bool IsMobile();

        public bool isMobile()
        {
#if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
#endif
            return false;
        }

        void Start()
        {
            config.currentInputType = isMobile() ? Configuration.InputType.Mobile : Configuration.InputType.PC;
            Debug.Log($"Input Detection: {config.currentInputType}");
            RefreshInputScripts();
        }
        
        void RefreshInputScripts()
        {
            virtualJoystick.gameObject.SetActive(config.currentInputType == Configuration.InputType.Mobile);
            characterLookMobile.enabled = (config.currentInputType == Configuration.InputType.Mobile);
            characterMovementMobile.enabled = (config.currentInputType == Configuration.InputType.Mobile);
            characterLookPC.enabled = (config.currentInputType == Configuration.InputType.PC);
            characterMovementPC.enabled = (config.currentInputType == Configuration.InputType.PC);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                config.currentInputType = (config.currentInputType == Configuration.InputType.Mobile) ? Configuration.InputType.PC : Configuration.InputType.Mobile;
                RefreshInputScripts();
            }
        }
    }
}