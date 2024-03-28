using TagLib;

string dir = Directory.GetCurrentDirectory();

string helpString = "";
string badParams = "shoots";
if (args[0] == "help")
{
    Console.Write(helpString);

}
else if (args[0].StartsWith("-"))
{
    args[0] = args[0].Remove(0);
    foreach (char c in args[0])
    {
        switch (c)
        {
            case 's':
                Console.WriteLine("Sorting Artists...");
                SortArtists(dir);
                break;
            case 'a':
                SortAlbums(dir); break;
            case 'g':
                SortGenres(dir); break;
            default:
                Console.Write(badParams);
                break;
                //return;
        }
        
    }
    SortArtists(dir);
}
void SortArtists(string folder)
{
    foreach(string file in  Directory.GetFiles(folder))
    {
        TagLib.File tag = TagLib.File.Create(file);
        string artist = tag.Tag.FirstArtist;
        if (artist != null && artist != "")
        {
            if (Directory.Exists(artist))
            {
                Console.WriteLine(Path.Join(artist, file));
                System.IO.File.Move(file, Path.Join(artist, file));
            }
            else
            {
                Directory.CreateDirectory(artist);
                Console.WriteLine(Path.Join(artist, file));
                Console.WriteLine(file);
                System.IO.File.Move(file, Path.Join(artist, file));
            }
        }

    }
}
void SortAlbums(string folder)
{

}
void SortGenres(string folder)
{

}
