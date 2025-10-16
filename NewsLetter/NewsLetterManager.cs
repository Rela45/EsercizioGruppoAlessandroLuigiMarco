namespace NewsLetter;

// Responsabile degli invii delle NewsLetters
class NewsLetterManager
{
    private readonly NewsLetterManager _nlm;
    private NewsLetterManager() { }

    public static NewsLetterManager Instance => _nml = new NewsLetterManager();

}