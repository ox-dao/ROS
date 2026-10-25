using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OX.Tablet.UIs.Swap.Canvas
{
    public static class QuoteHelper
    {
        public static IEnumerable<T> RebuildToTypicalPrice<T>(this IEnumerable<T> quotes) where T : MarketQuote, new()
        {
            foreach (var q in quotes)
            {
                var t = new T
                {
                    Timestamp = q.Timestamp,
                    Open = q.Open,
                    High = q.High,
                    Low = q.Low,
                    Close =q.Typical_Price,
                    Volume = q.Volume,
                    Index = q.Index,
                    X = q.X,
                };
                yield return t;
            }
        }
        public static IEnumerable<T> RebuildToMidPrice<T>(this IEnumerable<T> quotes) where T : MarketQuote, new()
        {
            foreach (var q in quotes)
            {
                var t = new T
                {
                    Timestamp = q.Timestamp,
                    Open = q.Open,
                    High = q.High,
                    Low = q.Low,
                    Close =q.MidPrice,
                    Volume = q.Volume,
                    Index = q.Index,
                    X = q.X,
                };
                yield return t;
            }
        }
        public static IEnumerable<T> RebuildToWeightClosePrice<T>(this IEnumerable<T> quotes) where T : MarketQuote, new()
        {
            foreach (var q in quotes)
            {
                var t = new T
                {
                    Timestamp = q.Timestamp,
                    Open = q.Open,
                    High = q.High,
                    Low = q.Low,
                    Close = q.WeightClose_Price,
                    Volume = q.Volume,
                    Index = q.Index,
                    X = q.X,
                };
                yield return t;
            }
        }
        public static IEnumerable<T> RebuildToHLCAPrice<T>(this IEnumerable<T> quotes) where T : MarketQuote, new()
        {
            foreach (var q in quotes)
            {
                var t = new T
                {
                    Timestamp = q.Timestamp,
                    Open = q.Open,
                    High = q.High,
                    Low = q.Low,
                    Close = q.HLCA_Price,
                    Volume = q.Volume,
                    Index = q.Index,
                    X = q.X,
                };
                yield return t;
            }
        }
        public static T[] TimeSort<T>(this IEnumerable<T> quotes) where T : MarketQuote
        {
            var qs = quotes.OrderBy(m => m.Timestamp).ToArray();
            int index = 0;
            foreach (var q in qs)
            {
                q.Index = index;
                index++;
            }
            return qs;
        }
        public static IEnumerable<T> ExtensionAs<T>(this MarketQuote[] quotes, Action<MarketQuote, int, T> parser = null) where T : MarketQuote, new()
        {
            for (int i = 0; i < quotes.Length; i++)
            {
                var q = quotes[i];
                var t = new T
                {
                    Timestamp = q.Timestamp,
                    Open = q.Open,
                    High = q.High,
                    Low = q.Low,
                    Close = q.Close,
                    Volume = q.Volume,
                    Index = q.Index,
                    X = q.X
                };
                if (parser.IsNotNull())
                    parser(q, i, t);
                yield return t;
            }
        }
      
        public static T[] LastLookBack<T>(this IEnumerable<T> quotes, int period, int lookback = 1) where T : MarketQuote
        {
            return quotes.Take(quotes.Count() - lookback).TakeLast(period).TimeSort();
        }
        public static T[] LastLookBackAndReplaceLast<T>(this IEnumerable<T> quotes, int period, MarketQuote lastQuote) where T : MarketQuote
        {
            var qs = quotes.TimeSort().TakeLast(period).ToArray();
            qs[qs.Length - 1] = lastQuote as T;
            return qs;
        }
        public static void RangeIterate<T>(this IEnumerable<T> quotes, int period, Action<IEnumerable<T>> action) where T : MarketQuote
        {
            if (quotes.Count() >= period)
            {
                for (int i = 0; i <= quotes.Count() - period; i++)
                {
                    var range = quotes.Skip(i).Take(period);
                    if (range.Count() == period)
                    {
                        action(range);
                    }
                }
            }
        }
    }
}
