using Hunt_basic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunt_basic.Persistence
{
    internal class TxtFileManager:IFileManager
    {
        private readonly string _filePath;
        public TxtFileManager(string path)
        {
            this._filePath = path;
        }
        public GameData Load()
        {
            try
            {
                string[] line = File.ReadLines(this._filePath).ToArray();

                string[] hunterPos = new string[4];
                for (int i = 0; i < 4; i++)
                {
                    hunterPos[i] = line[i + 3];
                }

                return new GameData(int.Parse(line[0]), int.Parse(line[1]), line[2], hunterPos, line[7]);
            }
            catch (Exception e)
            {

                throw new FileManagerException("Error while reading file");
            }
        }
        public void Save(GameData gd) {
            StreamWriter sw = new StreamWriter(this._filePath);
            sw.WriteLine(gd.gameSize);
            sw.WriteLine(gd.remainingTurns);
            sw.WriteLine(gd.nextStep.ToString());
            foreach (var h in gd.huterPieces)
            {
                sw.WriteLine(h.position.ToString());
            }
            sw.WriteLine(gd.preyPiece.position.ToString());

            sw.Flush();
            sw.Close();
        }

    }

    
}
