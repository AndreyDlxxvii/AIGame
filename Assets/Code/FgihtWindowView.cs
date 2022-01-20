using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AIGame
{
    public class FgihtWindowView : MonoBehaviour, IDisposable
    {
        //TODO сделать отдельно вьюшку с полями и свойствами отдельно контроллер с логикой
        [SerializeField] private TMP_Text _countMoneyText;
        [SerializeField] private TMP_Text _countHealthText;
        [SerializeField] private TMP_Text _countPowerText;
        [SerializeField] private TMP_Text _countPowerEnemyText;

        [SerializeField] private Button _addMoneyButton;
        [SerializeField] private Button _minusMoneyButton;
        
        [SerializeField] private Button _addHealthButton;
        [SerializeField] private Button _minusHealthButton;
        
        [SerializeField] private Button _addPowerButton;
        [SerializeField] private Button _minusPowerButton;

        [SerializeField] private Button _fightButton;

        private int _allCountMoneyPlayer;
        private int _allCountHealthPlayer;
        private int _allCountPowerPlayer;

        private Money _money;
        private Power _power;
        private Health _health;

        private Enemy _enemy;
        private int _enemyPower;

        private void Start()
        {
            _enemy = new Enemy("Evil Bird");
            _money = new Money();
            _money.Attach(_enemy);
            _power = new Power();
            _power.Attach(_enemy);
            _health = new Health();
            _health.Attach(_enemy);
            
            _addMoneyButton.onClick.AddListener(() => ChangeMoney(true));
            _minusMoneyButton.onClick.AddListener(() => ChangeMoney(false));
            
            _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
            _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));
            
            _addPowerButton.onClick.AddListener(() => ChangePower(true));
            _minusPowerButton.onClick.AddListener(() => ChangePower(false));
            
            _fightButton.onClick.AddListener(()=>Fight());
        }

        private void ChangePower(bool isAddCount)
        {
            if (isAddCount && _allCountPowerPlayer < 100)
                _allCountPowerPlayer++;
            else if(_allCountPowerPlayer > 0 && _allCountPowerPlayer != 100)
                _allCountPowerPlayer--;
            ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
        }
        

        private void ChangeHealth(bool isAddCount)
        {
            if (isAddCount && _allCountHealthPlayer < 100)
                _allCountHealthPlayer++;
            else if (_allCountHealthPlayer > 0 && _allCountHealthPlayer != 100)
                _allCountHealthPlayer--;
            ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
        }

        private void ChangeMoney(bool isAddCount)
        {
            if (isAddCount && _allCountMoneyPlayer < 100)
                _allCountMoneyPlayer++;
            else if (_allCountMoneyPlayer > 0 && _allCountMoneyPlayer != 100)
                _allCountMoneyPlayer--;
                
            ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
        }
        
        private void Fight()
        {
            Debug.Log(_allCountPowerPlayer >= _enemyPower ? "Win" : "Lose");
        }
        private void ChangeDataWindow(int countChangeData, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Money:
                    _countMoneyText.text = $"Player money: {countChangeData}";
                    _money.CountMoney = countChangeData;
                    break;
                case DataType.Health:
                    _countHealthText.text = $"Player health: {countChangeData}";
                    _health.CountHealth = countChangeData;
                    break;
                case DataType.Power:
                    _countPowerText.text = $"Player power: {countChangeData}";
                    _power.CountPower = countChangeData;
                    break;
            }

            _enemyPower = _enemy.PowerEnemy;
            _countPowerEnemyText.text = $"Enemy power: {_enemyPower}";
        }

        public void Dispose()
        {
            _addMoneyButton.onClick.RemoveAllListeners();
            _minusMoneyButton.onClick.RemoveAllListeners();
            _addHealthButton.onClick.RemoveAllListeners();
            _minusHealthButton.onClick.RemoveAllListeners();
            _addPowerButton.onClick.RemoveAllListeners();
            _minusPowerButton.onClick.RemoveAllListeners();
            _fightButton.onClick.RemoveAllListeners();
            
            _money.Detach(_enemy);
            _power.Detach(_enemy);
           _health.Detach(_enemy);
        }
    }
}