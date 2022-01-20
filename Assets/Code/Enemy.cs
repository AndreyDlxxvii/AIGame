using UnityEngine;
using static UnityEngine.Random;

namespace AIGame
{
    public class Enemy : IEnemy
    {
        private string _name;
        private int _moneyPlayer;
        private int _healthPlayer;
        private int _powerPlayer;

        public Enemy(string name)
        {
            _name = name;
        }
        public void Update(DataPlayer dataPlayer, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Health:
                    var dataHealth = (Health) dataPlayer;
                    _healthPlayer = dataHealth.CountHealth;
                    break;
                
                case DataType.Power:
                    var dataPower = (Power) dataPlayer;
                    _powerPlayer = dataPower.CountPower;
                    break;
                
                case DataType.Money:
                    var dataMoney = (Money) dataPlayer;
                    _moneyPlayer = dataMoney.CountMoney;
                    break;
            }
            Debug.Log($"Enemy{_name}, chande{dataType}");
        }

        public int PowerEnemy
        {
            get
            {
                var t = _moneyPlayer % 2 + _powerPlayer % 2 + _healthPlayer % 2;
                var power = Range(1,_moneyPlayer) + Range(1, _healthPlayer) + Range(1, _powerPlayer) + t;
                if (power < 0 )
                    return power *= -1;
                return power;
            }
        }
    }
}