using System.Collections.Generic;
using System.ComponentModel;
using ArtiomOvechko.RPG.Mono.Core.Stats;

namespace ArtiomOvechko.RPG.Mono.Core.Interfaces.Actor
{
    public interface IStats: INotifyPropertyChanged
    {
        List<Effect> CurrentEffects { get; set; }

        float HealthPercentage { get; }

        bool IsAlive { get; }

        int Damage { get; set; }

        int Size { get; set; }
        
        int HealthBarSize { get; }

        int StepLength { get; set; }

        void AddLives(int lives);
    }
}
