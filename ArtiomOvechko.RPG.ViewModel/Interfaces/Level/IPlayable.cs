using ArtiomOvechko.RPG.Core.Interfaces.Interaction;


namespace ArtiomOvechko.RPG.ViewModel.Interfaces.Level
{
    public interface IPlayable
    {
        /// <summary>
        /// Player control
        /// </summary>
        IControl Player { get; }

        /// <summary>
        /// Interaction handler
        /// </summary>
        IInteractionHandler Interactor { get; }

        /// <summary>
        /// Camera view port
        /// </summary>
        IViewPort ViewPort { get; set; }
    }
}
