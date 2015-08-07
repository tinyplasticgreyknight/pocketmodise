namespace pocketmodise {
    using System;

    internal class Superpage4x4 : AbstractSuperpageLayout {
        public override uint Columns { get { return 4; } }
        public override uint Rows { get { return 4; } }

        public override bool IsLeftBorderDotted(uint x, uint y) {
            return false;
        }

        public override bool IsTopBorderDotted(uint x, uint y) {
            return (y == 2) && (x >= 1 && x <= 2);
        }

        public override SubpageLayout GetSubpageLayout(uint i) {
            if (i > Count) throw new ArgumentException("index out of range");
            var j = i % 4;
            var u1 = j % 2;
            var v1 = j / 2;
            var k = i / 4;
            var u2 = k % 2;
            var v2 = k / 2;

            var x = u1 + u2 * 2;
            var y = v1 + v2 * 2;
            return new SubpageLayout() {
                X = x,
                Y = y,
                SuperpageLayout = this,
                Upside = Facing.Left
            };
        }
    }
}
