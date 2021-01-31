public class GameEventSystem
{
	public delegate void EventRaised(EVENT_TYPE type, System.Object data);
	public static event EventRaised GameEventHandler;
	public static void RaiseGameEvent(EVENT_TYPE type, System.Object data = null)
	{
		if (GameEventHandler != null)
		{
			GameEventHandler(type, data);
		}
	}
}

public enum EVENT_TYPE
{
	PLAY_HELP_AUDIO,
	ENEMY_KILLED
}