namespace pocketmodise {
    internal interface ISuperpageLayout {
        uint Columns { get; }
        uint Rows { get; }
        uint Count { get; }
        bool IsLeftBorderDotted(uint x, uint y);
        bool IsTopBorderDotted(uint x, uint y);
        SubpageLayout GetSubpageLayout(uint i);
    }
}
