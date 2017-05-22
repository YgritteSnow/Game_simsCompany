using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Data
{
	#region Base info for all entities
	class InfoBase
	{
		Type m_type;
	}
	#endregion

	#region Level info
	enum LevelEndingState
	{
		LevelEnding_red,
		LevelEnding_blu,
	}
	enum LevelUnlockState
	{
		LevelUnlock_lock,
		LevelUnlock_unlock,
	}
	class LevelInfo : InfoBase
	{
		List<LevelEndingState> m_levelEnding;
		List<LevelUnlockState> m_levelUnlock;
	}
	#endregion

	class PlayerInfo : InfoBase
	{
		LevelInfo m_levelEnding;
	}

	class MonsterInfo : InfoBase
	{
	}
}
