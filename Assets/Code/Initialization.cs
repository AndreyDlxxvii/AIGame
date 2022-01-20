using UnityEngine;

namespace AIGame
{
    public class Initialization
    {
        public Initialization(Controllers controllers, FgihtWindowView fightView)
        {
            
            var controllerWindow = new FightWindowController(fightView);

            controllers.Add(controllerWindow);
        }
    }
}