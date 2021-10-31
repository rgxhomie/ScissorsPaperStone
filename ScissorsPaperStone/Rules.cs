using System;
using System.Collections.Generic;
using System.Text;

namespace ScissorsPaperStone
{
    class Rules
    {
        public string PickWinner(string[] moves, int PCMove, int userMove)
        {
            if (PCMove == userMove)
            {
                return "Tie";
            }

            if (moves.Length - PCMove >= ((moves.Length - 1) / 2))
            {
                for (int i = PCMove + 1; i <= PCMove + ((moves.Length - 1) / 2); i++)
                {
                    if (i == userMove || i == userMove + moves.Length) { return "User"; }
                }
                return "PC";
            }
            else
            {
                for (int i = PCMove - 1; i >= PCMove - ((moves.Length - 1) / 2); i--)
                {
                    if (i == userMove) { return "PC"; }
                }
                return "User";
            }
        }
    }
}
