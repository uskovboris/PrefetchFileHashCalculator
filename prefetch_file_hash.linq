<Query Kind="Program" />

void Main()
{
	var file_path = @"\DEVICE\HARDDISKVOLUME2\SYSINTERNALSSUITE\DBGVIEW.EXE";

	var hash = ssca_2008_hash_function(file_path);
	hash.Dump();	
}

string ssca_2008_hash_function(string filename)
{
    Int32 hash_value = 314159;
    var filename_index = 0;
	
	var filename_bytes = Encoding.Unicode.GetBytes(filename); 
    var filename_length = filename_bytes.Length;

    while (filename_index + 8 < filename_length)
	{
        var character_value = (filename_bytes[filename_index + 1]) * 37;
        character_value += (filename_bytes[filename_index + 2]);
        character_value *= 37;
        character_value += (filename_bytes[filename_index + 3]);
        character_value *= 37;
        character_value += (filename_bytes[filename_index + 4]);
        character_value *= 37;
        character_value += (filename_bytes[filename_index + 5]);
        character_value *= 37;
        character_value += (filename_bytes[filename_index + 6]);
        character_value *= 37;
        character_value += (filename_bytes[filename_index]) * 442596621;
        character_value += (filename_bytes[filename_index + 7]);

        hash_value = (character_value - (hash_value * 803794207));

        filename_index += 8;
	}
	
    while (filename_index < filename_length)
	{
        hash_value = ((37 * hash_value) + filename_bytes[filename_index]);

		filename_index++;
	}

	hash_value.Dump();

    return hash_value.ToString("X");
}
// Define other methods and classes here