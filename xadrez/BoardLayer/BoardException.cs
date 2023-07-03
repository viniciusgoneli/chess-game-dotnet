using System;
namespace xadrez.BoardLayer
{
	public class BoardException : ApplicationException
    {
		public BoardException(string message) : base(message)
		{
		}
	}
}

