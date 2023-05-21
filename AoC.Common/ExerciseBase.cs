namespace AoC.Common;

public abstract class ExerciseBase : IExercise
{
    protected readonly TextReader _reader;
    public ExerciseBase(TextReader reader)
    {
        _reader = reader;
    }

    public abstract string SolvePart1();

    public abstract string SolvePart2();

    protected void ResetReader()
    {
        if (_reader is StreamReader streamReader && streamReader.BaseStream.CanSeek)
        {
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
        }
    }
}
