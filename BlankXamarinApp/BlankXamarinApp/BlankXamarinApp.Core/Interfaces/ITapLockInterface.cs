namespace BlankXamarinApp.Core.Interfaces
{
	public interface ITapLockMixin
	{
		TapLockMixinVars TapLockMixinVars { get; set; }
	}


	public struct TapLockMixinVars {
		public bool Locked;
	}

	public static class TapLockMixinExtensions {
		public static bool AcquireTapLock(this ITapLockMixin obj)
		{
			// if locked is true, return false
			// if locked is false, set to true and return true
			var vars = obj.TapLockMixinVars;
			return !vars.Locked && (vars.Locked = true) && (obj.TapLockMixinVars = vars).Locked;
		}

		public static void ReleaseTapLock(this ITapLockMixin obj)
		{
			var vars = obj.TapLockMixinVars;
			vars.Locked = false;
			obj.TapLockMixinVars = vars;
		}
	}
}

