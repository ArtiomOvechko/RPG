using System.ComponentModel;

namespace Chevo.RPG.WebApp.Core.Interaction
{
    public interface ISpec: INotifyPropertyChanged
    {
        int Size { get; set; }

        int XPos { get; set; }

        int YPos { get; set; }

        int CenteredXPosForDisplay { get; }

        int CenteredYPosForDisplay { get; }
    }
}