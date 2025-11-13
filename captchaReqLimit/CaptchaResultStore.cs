public class CaptchaResultStore
{
    private readonly List<string> _responses = new();
    private readonly object _lock = new();

    public void Add(string message)
    {
        lock (_lock)
        {
            _responses.Add(message);
            if (_responses.Count > 50)
                _responses.RemoveAt(0); // keep last 50
        }
    }

    public List<string> GetAll()
    {
        lock (_lock)
        {
            return _responses.ToList();
        }
    }
}
