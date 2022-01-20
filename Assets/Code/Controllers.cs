using System.Collections.Generic;

namespace AIGame
{
    public class Controllers
    {
        public const string startMethod = "OnStart";
        
        private List<IOnStart> _onStarts = new List<IOnStart>();
        
        public Controllers Add(IController controller)
        {
            if (controller is IOnStart onStart)
            {
                _onStarts.Add(onStart);
            }
            return this;
        }
        
        public void OnStart()
        {
            foreach (var ell in _onStarts)
            {
                if (ell.HasMethod(startMethod))
                {
                    ell.OnStart();
                }
            }
        }
    }
}