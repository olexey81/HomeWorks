namespace HW_9_File_Manager
{
    internal class TextReader
    {
        public void TxtReader(string path)
        {
            if (path.ToLower().EndsWith(".txt"))
            {
                Console.Clear();
                Console.WriteLine($"File {Path.GetFileName(path)} consist:\n");
                Console.WriteLine(File.ReadAllText(path));
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Incorrect file format. Only *.txt files can be opened");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
