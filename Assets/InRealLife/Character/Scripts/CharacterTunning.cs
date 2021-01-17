using UnityEngine;

namespace InRealLife.Character.Scripts
{
    [CreateAssetMenu(fileName = "CharacterTunning.asset", menuName = "CharacterTunning", order = 0)]
    public class CharacterTunning : ScriptableObject
    {
        public float speed = 4;
        public Vector2 rotationSensitivity = new Vector2(150, 100);
    }
}