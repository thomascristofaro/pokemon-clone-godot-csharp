using Godot;
using System;

namespace Game.Core;

public partial class Globals : Node
{
	public static Globals Instance { get; private set; }

	[ExportCategory("Gameplay")]
	[Export] public int GRID_SIZE = 16;

	public override void _EnterTree()
	{
		if (Instance != null)
		{
			Logger.LogError("Globals instance already exists!");
			return;
		}
		Instance = this;

		Logger.LogInfo("Globals instance created.");
	}

	public override void _ExitTree()
	{
		Instance = null;
	}
}
