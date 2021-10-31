using System;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace ScissorsPaperStone
{
    class RandomMoveGenerator
    {
        public string Key { get; private set; }
        public string Move { get; private set; }
        public string HMAC { get; private set; }
        
        public RandomMoveGenerator(string[] moves)
        {
            Key = GenerateKey();
            Move = GenerateMove(moves.Length, moves);
            HMAC = GenerateHmac(Key, Move);
        }


        public int GetMoveId(string[] moves)
        {
            return Array.IndexOf(moves, Move);
        }
        private string GenerateKey()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] data = new byte[16];
            rng.GetBytes(data);
            return BitConverter.ToString(data).Replace("-", string.Empty);
        }

        private string GenerateMove(int totalMovesCount, string[] moves)
        {
            return moves[RandomNumberGenerator.GetInt32(totalMovesCount)];
        }

        private string GenerateHmac(string key, string move)
        {
            byte[] bKey = Encoding.Default.GetBytes(key);
            using (var hmac = new HMACSHA256(bKey))
            {
                byte[] bMove = Encoding.Default.GetBytes(move);
                var bhash = hmac.ComputeHash(bMove);
                return BitConverter.ToString(bhash).Replace("-", string.Empty);
            }
        }
    }
}
