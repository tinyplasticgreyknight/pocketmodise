namespace pocketmodise {
    using System;

    internal class Superpage4x2 : AbstractSuperpageLayout {
        public override uint Columns { get { return 4; } }
        public override uint Rows { get { return 2; } }

        public override bool IsLeftBorderDotted(uint x, uint y) {
            return false;
        }

        public override bool IsTopBorderDotted(uint x, uint y) {
            return (y == 1) && (x >= 1 && x <= 2);
        }

        public override SubpageLayout GetSubpageLayout(uint i) {
            if(i > Count) throw new ArgumentException("index out of range");
            var j = (i + 3) % 8;
            var x = j % 4;
            var y = j / 4;
            var upside = Facing.Up;

            if (y == 1) {
                upside = Facing.Down;
                x = 3 - x;
            }

            return new SubpageLayout() {
                X = x,
                Y = y,
                SuperpageLayout = this,
                Upside = upside
            };
        }
    }
}