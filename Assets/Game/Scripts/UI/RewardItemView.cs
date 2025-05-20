using TMPro;
using UnityEngine;

namespace Runtime.UI
{
    public sealed class RewardItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void Init(string reward) => _text.text = reward;
    }
}