namespace HW_9_File_Manager
{
    internal class Drives
    {
        public string[] DriveList { get; }

        public Drives()
        {
            DriveList = Directory.GetLogicalDrives(); ;
        }
    }
}
