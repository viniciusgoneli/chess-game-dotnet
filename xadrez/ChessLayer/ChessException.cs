using System;
namespace xadrez.ChessLayer
{
	public class ChessException : ApplicationException
	{
		public ChessException(string msg) : base(msg)
		{
		}
	}
}

