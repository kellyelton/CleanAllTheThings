using System.Collections.Generic;
using System.Reflection;

namespace CleanAllTheThings
{
	public class DirtyObject : IDirtyObject
	{
		public bool IsClean { get; private set; }
		public object Object { get; }

		private Queue<CleanupPlan> _plans;

		public DirtyObject(object obj) {
			_plans = new Queue<CleanupPlan>();
			Object = obj;
		}

		public IDirtyObject And(CleanupPlan plan) {
			_plans.Enqueue(plan);
			return this;
		}

		public void Clean() {
			while(_plans.Count > 0) {
				CleanupPlan plan = _plans.Dequeue();
				try {
					plan?.Invoke(this);
				} catch (TargetInvocationException ex) {
					throw ex.InnerException; // Unwrap
				}
			}
			IsClean = true;
		}
	}
}
