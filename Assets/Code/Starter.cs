using System;
using UnityEngine;

namespace AIGame
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private FightWindowView _fightWindow;
        [SerializeField] private DailyRewardView _dailyRewardView;
        private Controllers _controllers;

        private void Start()
        {
            _controllers = new Controllers();
            new Initialization(_controllers, _fightWindow, _dailyRewardView);
            _controllers.OnStart();
        }
    }
}