namespace pocketmodise {
    internal abstract class AbstractSuperpageLayout : ISuperpageLayout {
        public abstract uint Columns { get; }
        public abstract uint Rows { get; }
        public uint Count { get { return Columns * Rows; } }
        public abstract bool IsLeftBorderDotted(uint x, uint y);
        public abstract bool IsTopBorderDotted(uint x, uint y);
        public abstract SubpageLayout GetSubpageLayout(uint i);
    }
}