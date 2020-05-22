using System;
using System.IO;
using System.Text;

class MainClass
{
    public static void Main()
    {
        // Specify input and output file paths
        string path = @"/Users/jacobbyerline/Documents/Programs/C#/Image_to_Hex/Image_to_Hex/fire.png";
        string outputPath = @"/Users/jacobbyerline/Documents/Programs/C#/Image_to_Hex/Image_to_Hex/fireHex.txt";

        // Read in input image in Binary
        byte[] byteArr = File.ReadAllBytes(path);

        // Make a StringBuilder
        StringBuilder hex = new StringBuilder(byteArr.Length * 2);

        // Append each byte in Hex format to the StringBuilder
        foreach (byte b in byteArr)
            hex.AppendFormat("{0:x2}", b);

        // Convert StringBuilder to String
        string hexString = hex.ToString();

        // Make Hex Letters UpperCase
        hexString = hexString.ToUpper();

        // Separate out Hex into pairs of 2
        for (int i = 2; i <= hexString.Length; i += 2)
        {
            hexString = hexString.Insert(i, " ");
            i++;
        }

        // Insert a new line after 16 pairs
        for (int i = 48; i <= hexString.Length; i += 48)
        {
            hexString = hexString.Insert(i, "\n");
            i++;
        }

        // Write to Console
        Console.WriteLine(hexString);

        // Write to Output file 
        File.WriteAllText(outputPath, hexString);

    }
}