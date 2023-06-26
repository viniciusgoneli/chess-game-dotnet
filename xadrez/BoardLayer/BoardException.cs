using System;
namespace xadrez.BoardLayer
{
	public class BoardException : Exception
	{
		public BoardException(string message) : base(message)
		{
		}
	}
}

