using System.ComponentModel;

namespace ArtiomOvechko.RPG.Core.Interfaces.Instance
{
    public interface ISpec: INotifyPropertyChanged
    {
        string Name { get; set; }

        int Lives { get; set; }

        int Damage { get; set; }

        int XPos { get; set; }

        int YPos { get; set; }

        int Size { get; set; }

        int StepLenght { get; set; }

        int CenteredXPosForDisplay { get; }

        int CenteredYPosForDisplay { get; }
    }
}
