using UnityEngine;

namespace Game.Scripts.UI
{
    public sealed class UIRoot : MonoBehaviour
    {
        [field: SerializeField] public Transform MainRoot { get; private set; }
        [field: SerializeField] public Transform PopupRoot { get; private set; }
    }
}