using Hunt_basic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Formats.Asn1;
using System.Xml.Schema;

namespace Hunt_Test
{
    [TestClass]
    public class HuntTests
    {
        [TestMethod]
        public void TestGameCreation_small()
        {
            Game g1 = new Game(3);
            Assert.AreEqual(g1.size, 3);
            Assert.AreEqual(g1.remRounds, 12);
            Assert.AreEqual(g1.winner, null);
        }
        [TestMethod]
        public void TestGameCreation_medium()
        {
            Game g2 = new Game(5);
            Assert.AreEqual(g2.size, 5);
            Assert.AreEqual(g2.remRounds, 20);
            Assert.AreEqual(g2.winner, null);
        }
        [TestMethod]
        public void TestGameCreation_large()
        {
            Game g3 = new Game(7);
            Assert.AreEqual(g3.size, 7);
            Assert.AreEqual(g3.remRounds, 28);
            Assert.AreEqual(g3.winner, null);
        }
        [TestMethod]
        public void TestInitialPiecePlacement_small()
        {
            Game g1 = new Game(3);
            (int, int)[] positions_small = { (0, 0), (0, 2), (2, 0), (2, 2) };
            for (int i = 0; i < g1.hunterPosions.Length; i++)
            {
                Assert.AreEqual(g1.hunterPosions[i], positions_small[i]);
            }
            Assert.AreEqual(g1.preyPosition, (1, 1));

        }
        [TestMethod]
        public void TestInitialPiecePlacement_medium()
        {

            (int, int)[] positions_medium = { (0, 0), (0, 4), (4, 0), (4, 4) };
            Game g2 = new Game(5);
            for (int i = 0; i < g2.hunterPosions.Length; i++)
            {
                Assert.AreEqual(g2.hunterPosions[i], positions_medium[i]);
            }
            Assert.AreEqual(g2.preyPosition, (2, 2));

            Game g3 = new Game(7);
            (int, int)[] positions_large = { (0, 0), (0, 6), (6, 0), (6, 6) };
            for (int i = 0; i < g3.hunterPosions.Length; i++)
            {
                Assert.AreEqual(g3.hunterPosions[i], positions_large[i]);
            }
            Assert.AreEqual(g3.preyPosition, (3, 3));

        }
        [TestMethod]
        public void TestInitialPiecePlacement_large()
        {
            Game g3 = new Game(7);
            (int, int)[] positions_large = { (0, 0), (0, 6), (6, 0), (6, 6) };
            for (int i = 0; i < g3.hunterPosions.Length; i++)
            {
                Assert.AreEqual(g3.hunterPosions[i], positions_large[i]);
            }
            Assert.AreEqual(g3.preyPosition, (3, 3));
        }
        [TestMethod]
        public void TestMovement()
        {
            Game g1 = new Game(3);
            g1.movePrey(directions.DOWN);
            Assert.AreEqual(g1.preyPosition, (1, 2));
            Assert.AreEqual(g1.currentStep, players.HUNTER);
            Assert.AreEqual(g1.remRounds, 12);

            g1.moveHunter(directions.RIGHT, 0);
            Assert.AreEqual(g1.hunterPosions[0], (1, 0));
            Assert.AreEqual(g1.currentStep, players.PREY);
            Assert.AreEqual(g1.remRounds, 11);


            g1.movePrey(directions.UP);
            Assert.AreEqual(g1.preyPosition, (1, 1));
            Assert.AreEqual(g1.currentStep, players.HUNTER);
            Assert.AreEqual(g1.remRounds, 11);


            g1.moveHunter(directions.LEFT, 3);
            Assert.AreEqual(g1.hunterPosions[3], (1, 2));
            Assert.AreEqual(g1.currentStep, players.PREY);
            Assert.AreEqual(g1.remRounds, 10);

        }
        [TestMethod]
        public void TestDirectionQuery()
        {
            Game g1 = new Game(3);
            var moves = g1.getPossiblePreyMoves();
            directions[] middleMoves = { directions.LEFT, directions.RIGHT, directions.UP, directions.DOWN };
            for (int i = 0; i < middleMoves.Length; i++)
            {
                Assert.AreEqual(moves[i], middleMoves[i]);
            }

            directions[] top_leftMoves = { directions.RIGHT, directions.DOWN };
            moves = g1.getPossibleHunterDirections(0);
            for (int i = 0; i < moves.Length; i++)
            {
                Assert.AreEqual(moves[i], top_leftMoves[i]);
            }

            directions[] bottom_leftMoves = { directions.RIGHT, directions.UP };
            moves = g1.getPossibleHunterDirections(1);
            for (int i = 0; i < moves.Length; i++)
            {
                Assert.AreEqual(moves[i], bottom_leftMoves[i]);
            }

            directions[] top_rightMoves = { directions.LEFT, directions.DOWN };
            moves = g1.getPossibleHunterDirections(2);
            for (int i = 0; i < moves.Length; i++)
            {
                Assert.AreEqual(moves[i], top_rightMoves[i]);
            }

            directions[] bottom_rightMoves = { directions.LEFT, directions.UP };
            moves = g1.getPossibleHunterDirections(3);
            for (int i = 0; i < moves.Length; i++)
            {
                Assert.AreEqual(moves[i], bottom_rightMoves[i]);
            }

            g1.movePrey(directions.DOWN);
            moves = g1.getPossibleHunterDirections(3);
            Assert.AreEqual(moves.Length, 1);
            Assert.AreEqual(moves[0], directions.UP);

            moves = g1.getPossibleHunterDirections(1);
            Assert.AreEqual(moves.Length, 1);
            Assert.AreEqual(moves[0], directions.UP);

            moves = g1.getPossiblePreyMoves();
            Assert.AreEqual(moves.Length, 1);
            Assert.AreEqual(moves[0], directions.UP);
        }
        [TestMethod]
        public void TestIndexToDirectionConversion_Small()
        {
            Game g = new Game(3);
            Assert.AreEqual(g.indexToMoveDirection(0, 1), directions.RIGHT);
            Assert.AreEqual(g.indexToMoveDirection(0, 3), directions.DOWN);
            Assert.AreEqual(g.indexToMoveDirection(2, 1), directions.LEFT);
            Assert.AreEqual(g.indexToMoveDirection(3, 0), directions.UP);

            Assert.AreEqual(g.indexToMoveDirection(4, 1), directions.UP);
            Assert.AreEqual(g.indexToMoveDirection(4, 3), directions.LEFT);
            Assert.AreEqual(g.indexToMoveDirection(4, 5), directions.RIGHT);
            Assert.AreEqual(g.indexToMoveDirection(4, 1), directions.UP);

            Assert.AreEqual(g.indexToMoveDirection(4, 0), null);
            Assert.AreEqual(g.indexToMoveDirection(4, 2), null);
            Assert.AreEqual(g.indexToMoveDirection(4, 6), null);
            Assert.AreEqual(g.indexToMoveDirection(4, 8), null);

            Assert.AreEqual(g.indexToMoveDirection(0, -1), null);
            Assert.AreEqual(g.indexToMoveDirection(-1, 0), null);

            Assert.AreEqual(g.indexToMoveDirection(2, 3), null);
            Assert.AreEqual(g.indexToMoveDirection(3, 2), null);

            Assert.AreEqual(g.indexToMoveDirection(8, 9), null);
            Assert.AreEqual(g.indexToMoveDirection(9, 8), null);
        }
        [TestMethod]
        public void TestIndexToDirectionConversion_Medium()
        {
            Game g = new Game(5);
            Assert.AreEqual(g.indexToMoveDirection(0, 1), directions.RIGHT);
            Assert.AreEqual(g.indexToMoveDirection(0, 5), directions.DOWN);
            Assert.AreEqual(g.indexToMoveDirection(4, 3), directions.LEFT);
            Assert.AreEqual(g.indexToMoveDirection(5, 0), directions.UP);

            Assert.AreEqual(g.indexToMoveDirection(12, 7), directions.UP);
            Assert.AreEqual(g.indexToMoveDirection(12, 11), directions.LEFT);
            Assert.AreEqual(g.indexToMoveDirection(12, 13), directions.RIGHT);
            Assert.AreEqual(g.indexToMoveDirection(12, 17), directions.DOWN);

            Assert.AreEqual(g.indexToMoveDirection(0,0),null);

            Assert.AreEqual(g.indexToMoveDirection(12, 0), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 4), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 6), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 8), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 16), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 18), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 20), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 24), null);

            Assert.AreEqual(g.indexToMoveDirection(12, 10), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 14), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 2), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 22), null);

            Assert.AreEqual(g.indexToMoveDirection(0, -1), null);
            Assert.AreEqual(g.indexToMoveDirection(-1, 0), null);

            Assert.AreEqual(g.indexToMoveDirection(4,5), null);
            Assert.AreEqual(g.indexToMoveDirection(5,4), null);

            Assert.AreEqual(g.indexToMoveDirection(24, 25), null);
            Assert.AreEqual(g.indexToMoveDirection(25,24), null);
        }
        [TestMethod]
        public void TestIndexToDirectionConversion_Large()
        {
            Game g = new Game(7);
            Assert.AreEqual(g.indexToMoveDirection(0, 1), directions.RIGHT);
            Assert.AreEqual(g.indexToMoveDirection(0, 7), directions.DOWN);
            Assert.AreEqual(g.indexToMoveDirection(6, 5), directions.LEFT);
            Assert.AreEqual(g.indexToMoveDirection(7, 0), directions.UP);

            Assert.AreEqual(g.indexToMoveDirection(23, 16), directions.UP);
            Assert.AreEqual(g.indexToMoveDirection(23, 22), directions.LEFT);
            Assert.AreEqual(g.indexToMoveDirection(23, 24), directions.RIGHT);
            Assert.AreEqual(g.indexToMoveDirection(23, 30), directions.DOWN);

            Assert.AreEqual(g.indexToMoveDirection(0, 0), null);

            Assert.AreEqual(g.indexToMoveDirection(23, 0), null);
            Assert.AreEqual(g.indexToMoveDirection(23, 6), null);
            Assert.AreEqual(g.indexToMoveDirection(23, 8), null);
            Assert.AreEqual(g.indexToMoveDirection(23, 12), null);
            Assert.AreEqual(g.indexToMoveDirection(23, 18), null);
            Assert.AreEqual(g.indexToMoveDirection(23, 20), null);
            Assert.AreEqual(g.indexToMoveDirection(23, 29), null);
            Assert.AreEqual(g.indexToMoveDirection(23, 31), null);
            Assert.AreEqual(g.indexToMoveDirection(23, 31), null);

            Assert.AreEqual(g.indexToMoveDirection(12, 10), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 14), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 2), null);
            Assert.AreEqual(g.indexToMoveDirection(12, 22), null);

            Assert.AreEqual(g.indexToMoveDirection(0, -1), null);
            Assert.AreEqual(g.indexToMoveDirection(-1, 0), null);

            Assert.AreEqual(g.indexToMoveDirection(6,7), null);
            Assert.AreEqual(g.indexToMoveDirection(7,6), null);

            Assert.AreEqual(g.indexToMoveDirection(48,49), null);
            Assert.AreEqual(g.indexToMoveDirection(49,48), null);
        }
        [TestMethod]
        public void TestWinner_small_prey()
        {
            Game g1 = new Game(3);
            for (int i = 0; i < (3 * 4) / 2; i++)
            {
                g1.movePrey(directions.DOWN);
                g1.moveHunter(directions.DOWN, 0);
                g1.movePrey(directions.UP);
                g1.moveHunter(directions.UP, 0);
            }
            Assert.AreEqual(g1.winner, players.PREY);
        }
        [TestMethod]
        public void TestWinner_small_hunter()
        {
            Game g1 = new Game(3);

            g1.movePrey(directions.DOWN);
            g1.moveHunter(directions.UP, 3);
            g1.movePrey(directions.RIGHT);
            g1.moveHunter(directions.RIGHT, 1);

            Assert.AreEqual(g1.winner, players.HUNTER);
        }
        [TestMethod]
        public void TestWinner_medium_prey()
        {
            Game g2 = new Game(5);
            for (int i = 0; i < (5 * 4) / 2; i++)
            {
                g2.movePrey(directions.DOWN);
                g2.moveHunter(directions.DOWN, 0);
                g2.movePrey(directions.UP);
                g2.moveHunter(directions.UP, 0);
            }
            Assert.AreEqual(g2.winner, players.PREY);
        }
        [TestMethod]
        public void TestWinner_medium_hunter()
        {
            Game g2 = new Game(5);
            g2.movePrey(directions.DOWN);
            g2.moveHunter(directions.UP, 3);
            g2.movePrey(directions.DOWN);
            g2.moveHunter(directions.RIGHT, 1);
            g2.movePrey(directions.RIGHT);
            g2.moveHunter(directions.RIGHT, 1);
            g2.movePrey(directions.RIGHT);
            g2.moveHunter(directions.RIGHT, 1);
            Assert.AreEqual(g2.winner, players.HUNTER);
        }
        [TestMethod]
        public void TestWinner_large_prey()
        {
            Game g3 = new Game(7);
            for (int i = 0; i < (7 * 4) / 2; i++)
            {
                g3.movePrey(directions.DOWN);
                g3.moveHunter(directions.DOWN, 0);
                g3.movePrey(directions.UP);
                g3.moveHunter(directions.UP, 0);
            }
            Assert.AreEqual(g3.winner, players.PREY);
        }
        [TestMethod]
        public void TestWinner_large_hunter()
        {
            Game g3 = new Game(7);
            g3.movePrey(directions.DOWN);
            g3.moveHunter(directions.UP, 3);
            g3.movePrey(directions.DOWN);
            g3.moveHunter(directions.RIGHT, 1);
            g3.movePrey(directions.DOWN);
            g3.moveHunter(directions.RIGHT, 1);
            g3.movePrey(directions.RIGHT);
            g3.moveHunter(directions.RIGHT, 1);
            g3.movePrey(directions.RIGHT);
            g3.moveHunter(directions.RIGHT, 1);
            g3.movePrey(directions.RIGHT);
            g3.moveHunter(directions.RIGHT, 1);
            Assert.AreEqual(g3.winner, players.HUNTER);
        }
        [TestMethod]
        public void TestTxtLoad()
        {
            string[] lines = new string[] { "5", "10", "HUNTER", "1,1", "2,2", "3,3", "4,4", "0,0" };
            FileStream fs = File.Create(Path.Combine("testInput.hnt"));
            fs.Dispose();
            File.WriteAllLines("testInput.hnt", lines);

            Game g1 = new Game("testInput.hnt");
            Assert.AreEqual(g1.size, 5);
            Assert.AreEqual(g1.winner, null);
            Assert.AreEqual(g1.currentStep, players.HUNTER);
            for (int i = 0; i < g1.hunterPosions.Length; i++)
            {
                Assert.AreEqual(g1.hunterPosions[i], (i + 1, i + 1));
            }
            Assert.AreEqual(g1.preyPosition, (0, 0));
        }
        [TestMethod]
        public void TestTxtSave()
        {
            string[] lines = new string[] { "5", "10", "HUNTER", "1,1", "2,2", "3,3", "4,4", "0,0" };
            FileStream fs = File.Create(Path.Combine("testInput.hnt"));
            fs.Dispose();
            File.WriteAllLines("testInput.hnt", lines);

            Game g1 = new Game("testInput.hnt");

            g1.moveHunter(directions.UP, 3);
            g1.movePrey(directions.DOWN);
            g1.moveHunter(directions.DOWN, 2);

            g1.save("testOutput.hnt");
            lines = File.ReadAllLines("testOutput.hnt");
            lines[0] = "5";
            lines[1] = "10";
            lines[2] = "PREY";
            lines[3] = "1,1";
            lines[4] = "2,2";
            lines[5] = "3,4";
            lines[6] = "4,3";
            lines[7] = "0,1";
        }

    }
}