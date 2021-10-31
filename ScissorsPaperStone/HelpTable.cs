using System;
using ConsoleTables;

namespace ScissorsPaperStone
{
    class HelpTable
    {
        public void DrawHelpTable(string[] moves, Rules rules)
        {
            string[] head = new string[moves.Length + 1];
            head[0] = "PC\\User";
            for (int i = 1; i <= moves.Length; i++)
            {
                head[i] = moves[i - 1];
            }
            var table = new ConsoleTable(head);

            for (int i = 0; i < moves.Length; i++)
            {
                string[] addRow = new string[head.Length];
                addRow[0] = moves[i];
                for (int j = 1; j < addRow.Length; j++)
                {
                    addRow[j] = rules.PickWinner(moves, GetMoveId(moves, addRow[0]), GetMoveId(moves, moves[j - 1]));
                }
                table.AddRow(addRow);
            }

            
            table.Write();
        }

        private int GetMoveId(string[] moves, string move)
        {
            return Array.IndexOf(moves, move);
        }
    }
}
