using System.Collections.Generic;

namespace StreamAddFee.IntervalService
{
    public class IntervalService
    {
        private readonly List<Interval> _intervals = new();

        public bool TryAddInterval(Interval newInterval)
        {
            // لیست همیشه مرتب بر اساس Start
            int index = _intervals.BinarySearch(newInterval, Comparer<Interval>.Create((a, b) => a.Start.CompareTo(b.Start)));

            if (index < 0)
                index = ~index; // محل درج پیشنهادی

            // بررسی بازه قبلی
            if (index > 0 && _intervals[index - 1].End >= newInterval.Start)
                return false;

            // بررسی بازه بعدی
            if (index < _intervals.Count && _intervals[index].Start <= newInterval.End)
                return false;

            // درج در مکان درست
            _intervals.Insert(index, newInterval);
            return true;
        }

        public IEnumerable<Interval> GetAll() => _intervals;
    }
}
