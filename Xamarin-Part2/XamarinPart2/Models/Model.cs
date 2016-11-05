using System;
using System.Collections.Generic;

namespace FirstHackDallas
{
	public class Model
	{
		public string type { get; set; }
		public Value value { get; set; }
	}

	public class Value
	{
		public int id { get; set; }
		public string joke { get; set; }
		public List<object> categories { get; set; }
	}
}

