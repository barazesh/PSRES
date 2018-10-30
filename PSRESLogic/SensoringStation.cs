namespace PSRESLogic
{
    class SensoringStation
    {
        public int Id { get; set; }
        public int Zone { get; set; }
        public int ParentId { get; set; }
        public int ParentPin { get; set; }
        public bool Light { get; set; }
        public bool Temperature { get; set; }
        public bool Presence { get; set; }
        public bool distance { get; set; }
    }
}
