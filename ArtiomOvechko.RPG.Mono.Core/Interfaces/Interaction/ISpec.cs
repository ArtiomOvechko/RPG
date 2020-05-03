﻿using System.ComponentModel;

namespace ArtiomOvechko.RPG.Mono.Core.Interaction
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