using System;
using UnityEngine;

namespace AIGame
{
    public class FightWindowController : IController, IOnStart, IDisposable
    {
        private FightWindowView _fightWindowView;
        
        private int _allCountMoneyPlayer;
        private int _allCountHealthPlayer;
        private int _allCountPowerPlayer;

        private Money _money;
        private Power _power;
        private Health _health;

        private Enemy _enemy;
        private int _enemyPower;
        
        public FightWindowController(FightWindowView fightView)
        {
            _fightWindowView = fightView;
        }

        public void OnStart()
        {
            _enemy = new Enemy("Evil Bird");
            _money = new Money();
            _money.Attach(_enemy);
            _power = new Power();
            _power.Attach(_enemy);
            _health = new Health();
            _health.Attach(_enemy);
                
            _fightWindowView.AddMoneyButton.onClick.AddListener(() => ChangeMoney(true));
            _fightWindowView.MinusMoneyButton.onClick.AddListener(() => ChangeMoney(false));
            
            _fightWindowView.AddHealthButton.onClick.AddListener(() => ChangeHealth(true));
            _fightWindowView.MinusHealthButton.onClick.AddListener(() => ChangeHealth(false));
            
            _fightWindowView.AddPowerButton.onClick.AddListener(() => ChangePower(true));
            _fightWindowView.MinusPowerButton.onClick.AddListener(() => ChangePower(false));
            
            _fightWindowView.FightButton.onClick.AddListener(()=>Fight());
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
                    _fightWindowView.CountMoneyText.text = $"Player money: {countChangeData}";
                    _money.CountMoney = countChangeData;
                    break;
                case DataType.Health:
                    _fightWindowView.CountHealthText.text = $"Player health: {countChangeData}";
                    _health.CountHealth = countChangeData;
                    break;
                case DataType.Power:
                    _fightWindowView.CountPowerText.text = $"Player power: {countChangeData}";
                    _power.CountPower = countChangeData;
                    break;
            }

            _enemyPower = _enemy.PowerEnemy;
            _fightWindowView.CountPowerEnemyText.text = $"Enemy power: {_enemyPower}";
        }

        public void Dispose()
        {
            _fightWindowView.AddMoneyButton.onClick.RemoveAllListeners();
            _fightWindowView.MinusMoneyButton.onClick.RemoveAllListeners();
            _fightWindowView.AddHealthButton.onClick.RemoveAllListeners();
            _fightWindowView.MinusHealthButton.onClick.RemoveAllListeners();
            _fightWindowView.AddPowerButton.onClick.RemoveAllListeners();
            _fightWindowView.MinusPowerButton.onClick.RemoveAllListeners();
            _fightWindowView.FightButton.onClick.RemoveAllListeners();
            
            _money.Detach(_enemy);
            _power.Detach(_enemy);
            _health.Detach(_enemy);
        }
    }
}