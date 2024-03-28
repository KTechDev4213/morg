using TagLib;

string dir = Directory.GetCurrentDirectory();

string helpString = "Program Help" +
    "\nCOMMANDS\n artist: Sort files into folders by artist";
string badParams = "shoots";

foreach (string arg in args)
{
    if (arg == "help")
    {
        Console.Write(helpString);

    }
    else if (arg == "artist")
    {
        {
            SortArtists(dir);
        }
    }
    else if (arg == "album")
    {
        SortAlbums(dir);
    }
    else
    {
        Console.WriteLine(badParams);
    }
}
SortAlbums(dir);
void SortArtists(string folder)
{
    foreach(string file in  Directory.GetFiles(folder))
    {
        TagLib.File tag = TagLib.File.Create(file);
        string artist = tag.Tag.FirstArtist;
        if (artist != null && artist != "")
        {
            string newPath = Path.Join(Path.GetDirectoryName(file), artist, Path.GetFileName(file));
            if (!Directory.Exists(artist))
            {
                Directory.CreateDirectory(artist);
            }
            Console.WriteLine(newPath);
            System.IO.File.Move(file, newPath);

        }

    }
}
void SortAlbums(string folder)
{
    foreach(string file in Directory.GetFiles(folder))
    {
        TagLib.File tag = TagLib.File.Create(file);
        string album = tag.Tag.Album;
        if(album != null && album != "")
        {
            string newPath = Path.Join(Path.GetDirectoryName(file), album, Path.GetFileName(file));
            if(!Directory.Exists(album))
            {
                Directory.CreateDirectory(album);
            }
            Console.WriteLine(newPath);
            System.IO.File.Move(file, newPath);

        }
    }
}
void SortGenres(string folder)
{

}
