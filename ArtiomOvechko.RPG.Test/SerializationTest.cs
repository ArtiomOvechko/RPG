using Chevo.RPG.Core.Inventory.Weapon;
using Chevo.RPG.Core.Weapon;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Windows;

namespace ArtiomOvechko.RPG.Test
{
    [TestClass]
    public class SerializationTest
    {
        public SerializationTest()
        {
            if (Application.Current == null)
            {
                new Application();
            }
        }

        //[TestMethod]
        //public void Base64SerializationWorks()
        //{
        //    //// Arrange
        //    //ICollection<BaseLevelSession> LevelSessions = new ICollection<BaseLevelSession>();
        //    //BaseLevelSession newSession = new SanctuaryLevelSession();
        //    //LevelSessions.Add(newSession);

        //    //LevelClientModel model = new LevelClientModel(newSession.LevelObjects, TestSettings.Default.ScreenWidthHeight, TestSettings.Default.ScreenWidthHeight);
        //    //newSession.Clients.Add(model);
        //    //newSession.LevelObjects.Add(model.Player);

        //    //// Act
        //    //ResponseLevelModel responseModel = new ResponseLevelModel(model.ViewPort, model.Interactor, newSession.LevelObjects);
        //    //var testResult = Base64Serializer.SerializeObject(responseModel);

        //    //// Assert
        //    //Assert.IsNotNull(testResult);
        //}
    }
}
