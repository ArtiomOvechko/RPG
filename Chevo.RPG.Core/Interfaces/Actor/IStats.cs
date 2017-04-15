using System.Collections.Generic;
using System.ComponentModel;

namespace Chevo.RPG.Core.Interfaces.Actor
{
    public interface IStats: INotifyPropertyChanged
    {
        ICollection<object> Lives { get; }

        bool IsAlive { get; }

        int Damage { get; set; }

        int Size { get; set; }

        int StepLenght { get; set; }

        void LostLives(int lives);

        void AddLives(int lives);
    }
}
