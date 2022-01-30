using System;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

namespace AIGame
{
    public class CurrencyView : MonoBehaviour
    {
        private const string WoodKey = nameof(WoodKey); 
        private const string DiamondKey = nameof(DiamondKey); 
        public static CurrencyView Instance { get; private set; }

        [SerializeField] private TMP_Text _currenCountWood;
        [SerializeField] private TMP_Text _currenCountDiamond;
        private void Awake()
        {
            Instance = this; 
        }

        public void AddWood(int value)
        {
            SaveNewCountIntPlayer(WoodKey, value);
            _currenCountWood.text = PlayerPrefs.GetInt(WoodKey, 0).ToString();
        }
        
        public void AddDiamond(int value)
        {
            SaveNewCountIntPlayer(DiamondKey, value);
            _currenCountDiamond.text = PlayerPrefs.GetInt(DiamondKey, 0).ToString();
        }

        private void SaveNewCountIntPlayer(string key, int value)
        {
            var currentCount = PlayerPrefs.GetInt(key, 0);
            var newCount = currentCount + value;
            PlayerPrefs.SetInt(key, newCount);
        }
    }
}