namespace CleanAllTheThings
{
	public interface IDirtyObject
	{
		bool IsClean { get; }
		object Object { get; }
		IDirtyObject And(CleanupPlan plan);
		void Clean();
	}
}
