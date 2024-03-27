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
    args[0].Remove(0);
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
                return;
        }
    }
}
void SortArtists(string folder)
{
    foreach(string file in  Directory.GetFiles(folder))
    {
        TagLib.File tag = TagLib.File.Create(file);
        string artist = tag.Tag.FirstAlbumArtist;
        if(Directory.Exists(artist))
        {
            System.IO.File.Move(file, Path.Join(artist, file));
        }
        else
        {
            Directory.CreateDirectory(artist);
            System.IO.File.Move(file, Path.Join(artist, file));
        }
    }
}
void SortAlbums(string folder)
{

}
void SortGenres(string folder)
{

}
