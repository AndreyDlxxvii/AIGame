using UnityEngine;

namespace AIGame
{
    public class Initialization
    {
        public Initialization(Controllers controllers, FightWindowView fightView, DailyRewardView dailyRewardView)
        {
            
            var controllerWindow = new FightWindowController(fightView);
            var controllerReward = new DailyRewardController(dailyRewardView);

            controllers.Add(controllerWindow);
            controllers.Add(controllerReward);
        }
    }
}