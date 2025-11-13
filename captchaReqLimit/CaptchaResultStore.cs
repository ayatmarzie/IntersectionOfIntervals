using System;
using System.Collections.Generic;

upublic class CaptchaResultStore
{
    private readonly List<string> _logs = new();
    private readonly object _lock = new();

    public void Add(string message)
    {
        lock (_lock)
        {
            _logs.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
            if (_logs.Count > 100)
                _logs.RemoveAt(0); // keep last 100 logs
        }
    }

    public List<string> GetAll()
    {
        lock (_lock)
        {
            return _logs.ToList();
        }
    }
}
