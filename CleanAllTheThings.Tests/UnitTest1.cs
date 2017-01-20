using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanAllTheThings;

namespace CleanAllTheThings.Tests
{
	[TestClass]
	public class Playground
	{
		[TestMethod]
		public void Playground_1() {
		}
	}

	[TestClass]
	public class Requirements
	{
		[TestMethod]
		public void DirtyObject_DoesNotStartOutClean() {
			Assert.IsFalse(new DirtyObject("asdf").IsClean, "DirtyObject should not start out clean");
		}

		[TestMethod]
		public void IDirtyObject_CallToClean_RunsImmediatly() {
			var obj = new DirtyObject("asdf");
			obj.Clean();
			Assert.IsTrue(obj.IsClean, "Object was cleaned and isn't marked as Clean");
		}

		[TestMethod]
		public void IDirtyObject_PlanAndClean_DoesNotRunImmediatly() {
			DirtyObject obj = new DirtyObject("asdf");
			bool ran = false;
			CleanupPlan confirmThisRan = new CleanupPlan(x => {
				ran = true;
				return x;
			});

			obj.PlanCleanup().And(confirmThisRan);
			Assert.IsFalse(ran, "Cleanup ran a plan and it shouldn't have.");
			Assert.IsFalse(obj.IsClean, "Object was cleaned and shouldn't have been");
		}
	}
}
