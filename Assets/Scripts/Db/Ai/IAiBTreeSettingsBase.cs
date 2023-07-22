using System.Collections.Generic;

namespace Db.Ai
{
	public interface IAiBTreeSettingsBase
	{
		List<BTreeRootTask> Get(EAiType heroType);
	}
}