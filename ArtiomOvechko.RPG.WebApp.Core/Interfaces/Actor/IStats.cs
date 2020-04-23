using System.Collections.Generic;
using System.ComponentModel;
using Chevo.RPG.WebApp.Core.Stats;

namespace Chevo.RPG.WebApp.Core.Interfaces.Actor
{
    public interface IStats: INotifyPropertyChanged
    {
        public List<Effect> CurrentEffects { get; set; }

        float HealthPercentage { get; }

        bool IsAlive { get; }

        int Damage { get; set; }

        int Size { get; set; }
        
        int HealthBarSize { get; }

        int StepLength { get; set; }

        void AddLives(int lives);
    }
}
