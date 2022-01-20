using System;
using UnityEngine;

namespace AIGame
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private FgihtWindowView _fightWindow;
        private Controllers _controllers;

        private void Start()
        {
            _controllers = new Controllers();
            new Initialization(_controllers, _fightWindow);
            _controllers.OnStart();
        }
    }
}