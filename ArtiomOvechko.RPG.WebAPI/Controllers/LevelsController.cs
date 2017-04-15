using System.Web.Http;

namespace ArtiomOvechko.RPG.WebAPI.Controllers
{
    /// <summary>
    /// Handles levels and interaction for all players
    /// </summary>
    public class LevelsController : ApiController
    {
        ///// <summary>
        ///// Create new level
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IHttpActionResult> Init()
        //{
        //    BaseLevelSession newSession = new SanctuaryLevelSession();

        //    await Task.Run(() =>
        //    {        
        //        ApiSharedData.GetSessions().Add(newSession);
        //    });

        //    return Ok(newSession.SessionGuid.ToString());
        //}

        ///// <summary>
        ///// Join level
        ///// </summary>
        ///// <param name="levelGuid">Guid string which matches any of level Guids</param>
        ///// <param name="screenWidth">Client screen width</param>
        ///// <param name="screenHeight">Client screen height</param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IHttpActionResult> Join(string levelGuid, int screenWidth, int screenHeight)
        //{
        //    LevelClientModel model = new LevelClientModel(null, 1, 1);
        //    await Task.Run(() =>
        //    {
        //        BaseLevelSession matchedSession = ApiSharedData.GetSessions().FirstOrDefault(x => x.SessionGuid.ToString() == levelGuid);
        //        ICollection<BaseLevelSession> allSessions = ApiSharedData.GetSessions();

        //        model = new LevelClientModel(matchedSession.LevelObjects, screenWidth, screenHeight);
        //        matchedSession.Clients.Add(model);
        //        matchedSession.LevelObjects.Add(model.Player);
        //    });

        //    return Ok(model.ClientGuid.ToString());
        //}

        ///// <summary>
        ///// Get current level state
        ///// </summary>
        ///// <param name="levelGuid">Level guid</param>
        ///// <param name="clientGuid">Player guid</param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IHttpActionResult> Load(string levelGuid, string clientGuid)
        //{
        //    string resultString = "";
        //    await Task.Run(() =>
        //    {
        //        BaseLevelSession matchedSession = ApiSharedData.GetSessions().FirstOrDefault(x => x.SessionGuid.ToString() == levelGuid.ToString());
        //        LevelClientModel model = matchedSession.Clients.FirstOrDefault(x => x.ClientGuid.ToString() == clientGuid.ToString());

        //        ResponseLevelModel result = new ResponseLevelModel(model.ViewPort, model.Interactor, matchedSession.LevelObjects);

        //        resultString = Base64Serializer.SerializeObject(result);
        //    });
        //    //var newResult = (ResponseLevelModel)Base64Serializer.DeserializeObject(resultString);

        //    return Ok(resultString);
        //}

        //[HttpGet]
        //public IHttpActionResult Act(string levelGuid, string playerGuid, ActionType actionType, Direction direction)
        //{
        //    BaseLevelSession matchedSession = ApiSharedData.getInstance.LevelSessions.FirstOrDefault(x => x.SessionGuid.ToString() == levelGuid);
        //    IPlayer player = matchedSession.Clients.FirstOrDefault(x => x.ClientGuid.ToString() == playerGuid.ToString()).Player;

        //    switch (actionType)
        //    {
        //        case ActionType.StartMove:
        //            player.StartMove.Execute(direction);
        //            break;
        //        case ActionType.StopMove:
        //            player.StopMove.Execute(direction);
        //            break;
        //        case ActionType.Interact:
        //            player.TryInteract.Execute(direction);
        //            break;
        //        case ActionType.Attack:
        //            player.Attack.Execute(direction);
        //            break;
        //    }
        //    return Load(levelGuid, playerGuid);
        //}
    }
}
