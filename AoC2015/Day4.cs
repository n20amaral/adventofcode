using System.Security.Cryptography;
using System.Text;
using AoC.Common;

namespace AoC2015;

public class Day4 : ExerciseBase
{
    public Day4(TextReader reader) : base(reader)
    {
    }

    public override string SolvePart1()
    {
        ResetReader();
        var input = _reader.ReadLine() ?? "";
        var complement = FindKeyComplementForZeroStartMD5Hash(input, 5);

        return complement;
    }


    public override string SolvePart2()
    {
        ResetReader();
        var input = _reader.ReadLine() ?? "";
        var complement = FindKeyComplementForZeroStartMD5Hash(input, 6);

        return complement;
    }

    private string FindKeyComplementForZeroStartMD5Hash(string keyPrefix, int zeroCount)
    {
        var zeros = new string[zeroCount];
        Array.Fill(zeros, "0");
        var hashStart = string.Join("", zeros);
        var numberOfBytes = (int)zeroCount / 2 + (zeroCount % 2);
        
        var hash = string.Empty;
        var complement = 0;
        while(!hash.StartsWith(hashStart))
        {
            complement++;
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes($"{keyPrefix}{complement}");
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < numberOfBytes; i++)
                {
                    var hex = hashBytes[i].ToString("X2");
                    if(!hex.StartsWith("0"))
                    {
                        break;
                    }
                    sb.Append(hex);
                }

                hash = sb.ToString();
            }
        }

        return complement.ToString();
    }
}