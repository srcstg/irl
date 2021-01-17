using UnityEngine;

namespace InRealLife.Character.Scripts
{
    [CreateAssetMenu(fileName = "Configuration.asset", menuName = "Configuration", order = 0)]
    public class Configuration : ScriptableObject
    {
        public enum InputType { PC, Mobile}

        InputType _currentInputType = InputType.PC;

        public InputType currentInputType
        {
            get
            {
                return _currentInputType;
            }
            set
            {
                if (_currentInputType != value)
                {
                    
                    _currentInputType = value;
                }
            }
        }
        
    }
}