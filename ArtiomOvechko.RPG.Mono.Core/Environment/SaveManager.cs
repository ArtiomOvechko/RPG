using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ArtiomOvechko.RPG.Mono.Core.Environment
{
    /// <summary>
    /// Responsible for data save\load
    /// </summary>
    public static class SaveManager
    {
        private const string SaveFileName = "save.save";
        private const string LevelFileResolution = ".lvl";
        private const string LevelsDirectory = "levels";

        /// <summary>
        /// Saves game state to JSON file
        /// </summary>
        /// <param name="conditions">Key-valued pairs of game state properties</param>
        public static void SaveGame(Dictionary<string, string> gameStateDictionary)
        {
            string dataToSave = JsonConvert.SerializeObject(gameStateDictionary);
            using (FileStream fs = new FileStream(string.Format("{0}/{1}", Directory.GetCurrentDirectory(), SaveFileName), FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(dataToSave);
                }
            }
        }

        /// <summary>
        /// Loads key-valued state of the game
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> LoadGame()
        {
            using (FileStream fs = new FileStream(string.Format("{0}/{1}", Directory.GetCurrentDirectory(), SaveFileName), FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string saveData = sr.ReadToEnd();
                    Dictionary<string, string> result = JsonConvert.DeserializeObject<Dictionary<string, string>>(saveData);

                    return result;
                }
            }
        }

        /// <summary>
        /// Erases game save
        /// </summary>
        public static void DeleteSave()
        {
            File.Delete(string.Format("{0}/{1}", Directory.GetCurrentDirectory(), SaveFileName));
        }

        /// <summary>
        /// Loads all levels
        /// </summary>
        /// <returns></returns>
        public static List<LevelSaveMetadata> GetLevels()
        {
            List<LevelSaveMetadata> result = new List<LevelSaveMetadata>();
            string saveDirectory = string.Format("{0}/{1}", Directory.GetCurrentDirectory(), LevelsDirectory);
            if (Directory.Exists(saveDirectory))
            {
                foreach (string fileName in Directory.GetFiles(saveDirectory, string.Format("*{0}", LevelFileResolution)))
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Open))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            string levelData = sr.ReadToEnd();
                            result.Add(JsonConvert.DeserializeObject<LevelSaveMetadata>(levelData));
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Deletes all the level info
        /// </summary>
        public static void DeleteLevel(string levelName)
        {
            File.Delete(string.Format("{0}/{1}/{2}{3}", Directory.GetCurrentDirectory(), LevelsDirectory, levelName, LevelFileResolution));
        }

        /// <summary>
        /// Saves level
        /// </summary>
        /// <param name="metadata"></param>
        public static void SaveLevel(LevelSaveMetadata metadata)
        {
            string dataToSave = JsonConvert.SerializeObject(metadata);
            string saveDirectory = string.Format("{0}/{1}", Directory.GetCurrentDirectory(), LevelsDirectory);
            using (FileStream fs = new FileStream(string.Format("{0}/{1}{2}", saveDirectory, metadata.LevelName, LevelFileResolution), FileMode.OpenOrCreate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(dataToSave);
                }
            }
        }
    }
}
