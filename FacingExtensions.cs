namespace pocketmodise {
    using System;

    internal static class FacingExtensions {
        public static int ToAngle(this Facing self) {
            switch (self) {
                case Facing.Up:
                    return 0;
                case Facing.Right:
                    return 90;
                case Facing.Down:
                    return 180;
                case Facing.Left:
                    return 270;
                default:
                    throw new InvalidCastException();
            }
        }

        public static bool IsSideways(this Facing self) {
            switch (self) {
                case Facing.Left:
                case Facing.Right:
                    return true;
                default:
                    return false;
            }
        }
    }
}
