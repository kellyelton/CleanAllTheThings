namespace CleanAllTheThings
{

	public static class ExtensionMethods
	{
		public static IDirtyObject PlanCleanup(this object obj) => new DirtyObject(obj);
		public static IDirtyObject Clean(this object obj) {
			DirtyObject d = new DirtyObject(obj);
			d.Clean();
			return d;
		}
	}
}
