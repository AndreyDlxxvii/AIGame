using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AIGame
{
    public class ContainerSlotView : MonoBehaviour
    {
        [SerializeField] private Image _iconCurrency;
        [SerializeField] private Image _backgroundSelect;
        [SerializeField] private TMP_Text _textDays;
        [SerializeField] private TMP_Text _textCountReward;

        public void SetData(Reward reward, int countDay, bool isSelect)
        {
            _iconCurrency.sprite = reward.IconCurrency;
            _textDays.text = $"Day {countDay}";
            _textCountReward.text = reward.CountCurrency.ToString();
            _backgroundSelect.gameObject.SetActive(isSelect);
        }

    }
}