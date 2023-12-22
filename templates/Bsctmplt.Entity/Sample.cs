using Bscframework.Core;
using System;
namespace Bsctmplt.Entity
{
	public class Sample : IEntity<int>
	{
		public int Id { get; set; }
		public int Value { get; set; }
	}
}

