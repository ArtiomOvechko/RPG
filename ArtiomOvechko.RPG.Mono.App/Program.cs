using System;
using ArtiomOvechko.RPG.Mono.ViewModel.Level;

namespace ArtiomOvechko.RPG.Mono.App
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameLevel())
                game.Run();
        }
    }
}