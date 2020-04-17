using System;
using System.Threading;
using Chevo.RPG.WebApp.ViewModel.Interfaces;
using Chevo.RPG.WebApp.ViewModel.Level;

namespace ArtiomOvechko.RPG.WebApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart ts = new ThreadStart(() => { new Sanctuary((int) 0, 0); });
            ts.Invoke();
            
            System.Console.ReadLine();
        }
    }
}