public class Station {
    public int id { get; set; }
    public string name { get; set; }
    public int bikesAvailable { get; set; }
    public int spacesAvailable { get; set; }
    public bool allowDropoff { get; set; }
    public bool isFloatingBike { get; set; }
    public bool isCarStation { get; set; }
    public bool realTimeData { get; set; }
}