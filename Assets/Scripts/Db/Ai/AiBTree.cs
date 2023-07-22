using System.Collections.Generic;

namespace Db.Ai
{
	public class AiBTree
	{
		public readonly EAiType AiType;
		public readonly List<BTreeRootTask> RootTasks = new List<BTreeRootTask>();

		public AiBTree(EAiType aiType)
		{
			AiType = aiType;
		}
	}
}