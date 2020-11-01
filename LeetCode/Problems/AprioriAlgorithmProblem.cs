using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * Implement Apriori Algorithm.
     * 
     * 關聯分析的概念是由Agrawal et. al. （1993） 所提出。
     * 隨後，Agrawal & Srikant （1994） 進一步提出 Apriori演算法，以做為關聯法則之工具。
     * 關聯分析主要透過「支持度」（Support）與「信賴度」（Confidence）來對商品項目之間的關聯性，進行篩選。
     * 其中，
     * 支持度（Support）意指即某項目集在資料庫中出現的次數比例。
     * 例如：某資料庫中有100筆交易紀錄，其中有20筆交易有購買啤酒，則啤酒的支持度為20%。
     * 信賴度（Confidence）意指兩個項目集之間的條件機率，也就是在A出現的情況下，B出現的機率值。
     * 
     * Apriori 演算法優缺點
     * 優點：易編碼實現
     * 缺點：在大資料集上可能較慢
     * 適用資料型別：數值型 或者 標稱型資料。
     * 
     * Example 1:
     * Input: 123
     * Output: 321
     * 
     * Example 2:
     * Input: -123
     * Output: -321
     * 
     * Example 3:
     * Input: 120
     * Output: 21
     * 
     * Note: Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
     */
    public class AprioriAlgorithmProblem
    {
        private ShoppingRecords _dataset = new ShoppingRecords();

        // 計算結果
        private double _minSupport;
        private Dictionary<string, AprioriRecord> _resultDict = new Dictionary<string, AprioriRecord>();

        // 統計時間
        private Stopwatch _sw = new Stopwatch();
        private Dictionary<string, double> _timeDict = new Dictionary<string, double>();

        public void ReadFile(string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                throw new FileNotFoundException($"File does not exist, path: {filePath}");
            }

            _dataset.Clear();
            _resultDict.Clear();
            _timeDict.Clear();

            _sw.Reset();
            _sw.Start();

            try
            {
                using (var sr = File.OpenText(filePath))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] words = line.Split(
                            new char[] { '\n', ' ' },
                            StringSplitOptions.RemoveEmptyEntries);

                        string transactionId = words[1];
                        string itemId = words[2];

                        _dataset.Add(transactionId, itemId);
                    }
                }
            }
            finally
            {
                _sw.Stop();
                _timeDict[nameof(ReadFile)] = _sw.Elapsed.TotalMilliseconds;
            }
        }

        public double GetResult(double minSupport, List<string> boughtItemIds, List<string> forecastItemIds)
        {
            CalculateSupport(minSupport);

            _sw.Reset();
            _sw.Start();

            try
            {
                // todo: 排序項目, 計算機率
                var boughtKey = new ItemKey(boughtItemIds);
                int boughtCount = _resultDict.ContainsKey(boughtKey.CombinationId) ?
                    _resultDict[boughtKey.CombinationId].Count : 0;

                if (boughtCount == 0)
                {
                    return 0;
                }

                var allIds = boughtItemIds.Concat(forecastItemIds).ToList();
                var allKey = new ItemKey(allIds);
                int allCount = _resultDict.ContainsKey(boughtKey.CombinationId) ?
                    _resultDict[allKey.CombinationId].Count : 0;

                return allCount / (boughtCount / 1d);   // 轉成 double
            }
            finally
            {
                _sw.Stop();
                _timeDict[nameof(GetResult)] = _sw.Elapsed.TotalMilliseconds;
            }
        }

        private void CalculateSupport(double minSupport)
        {
            //L(1) = Scan database to find {frequent itemset}  
            //do  
            //    Gnerate C(k+1) from L(k)  
            //    Remove the itemset which has any subset that is not a frequent itemset (detect from L(k))  
            //    L(k+1) = candicates in C(k+1) with min_support  
            //    for all possible of partition L(k+1) into two parts A,B  
            //        if P(L(k+1)) / P(A) >= min_confidence  
            //            A => B is one association rule  
            //until L(k+1) is ∅  

            // 已經有資料不重新計算
            if (_resultDict.Count > 0 && _minSupport == minSupport)
            {
                return;
            }

            _sw.Reset();
            _sw.Start();

            try
            {
                // Get id from the items
                List<ItemKey> itemKeys = _dataset.GetAllCombinationIds();
                GetSupport(itemKeys, minSupport);
            }
            finally
            {
                _sw.Stop();
                _timeDict[nameof(CalculateSupport)] = _sw.Elapsed.TotalMilliseconds;
            }
        }

        private void GetSupport(List<ItemKey> itemKeys, double minSupport)
        {
            var records = new AprioriRecords();
            foreach (ItemKey itemKey in itemKeys)
            {
                int count = _dataset.GetSupport(itemKey);
                if (count >= minSupport)
                {
                    var record = new AprioriRecord(itemKey, count);
                    records.Add(record);
                    _resultDict[itemKey.CombinationId] = record;
                }
            }

            var subKeys = records.GetAllCombinationIds2();
            if (subKeys.Count == 0)
            {
                return;
            }
            else
            {
                GetSupport(subKeys, minSupport);
            }
        }
    }

    public class ItemKey
    {
        private SortedSet<string> _ids = new SortedSet<string>();
        public string CombinationId
        {
            get { return "{" + string.Join(",", _ids) + "}"; }
        }

        public List<string> Ids
        {
            get { return new List<string>(_ids); }
        }

        public int Count { get { return _ids.Count; } }

        public ItemKey(string itemId) : this(new List<string>() { itemId })
        {
        }
        public ItemKey(ICollection<string> ids)
        {
            foreach (string id in ids)
            {
                _ids.Add(id);
            }
        }

        internal bool HasItem(string itemId)
        {
            return _ids.Any(x => x.Equals(itemId));
        }

        public override string ToString()
        {
            return CombinationId;
        }

        public override int GetHashCode() { return CombinationId.GetHashCode(); }
        public override bool Equals(object obj) 
        {
            var target = obj as ItemKey;
            if (target == null)
            {
                return false;
            }

            return CombinationId == target.CombinationId;
        }
    }

    internal class ItemKeyComparar : IComparer<ItemKey>
    {
        public int Compare(ItemKey x, ItemKey y)
        {
            return x.CombinationId.CompareTo(y.CombinationId);
        }
    }

    public class ShoppingRecords
    {
        private Dictionary<string, ShoppingRecord> _dataset = new Dictionary<string, ShoppingRecord>();
        public Dictionary<string, ShoppingRecord> Dataset
        {
            get { return new Dictionary<string, ShoppingRecord>(_dataset); }
        }

        public void Add(string transactionId, string itemId)
        {
            if (_dataset.ContainsKey(transactionId) == false)
            {
                _dataset[transactionId] = new ShoppingRecord();
            }

            _dataset[transactionId].Add(itemId);
        }

        public void Clear()
        {
            _dataset.Clear();
        }

        public List<ItemKey> GetAllCombinationIds()
        {
            SortedSet<string> itemIds = new SortedSet<string>();
            foreach (ShoppingRecord record in _dataset.Values)
            {
                foreach (var itemId in record.ItemIds)
                {
                    itemIds.Add(itemId);
                }
            }


            var itemKeys = new List<ItemKey>();
            foreach (string itemId in itemIds)
            {
                itemKeys.Add(new ItemKey(itemId));
            }

            return itemKeys;
        }

        public int GetSupport(ItemKey itemId)
        {
            int count = 0;
            foreach (ShoppingRecord record in _dataset.Values)
            {
                if (record.HasItems(itemId))
                {
                    count++;
                }
            }

            return count;
        }
    }

    // 原始資料
    public class ShoppingRecord
    {
        public List<string> _itemIds = new List<string>();
        public List<string> ItemIds
        {
            get { return new List<string>(_itemIds); }
        }

        public void Add(string itemId)
        {
            _itemIds.Add(itemId);
        }

        internal bool HasItems(ItemKey itemKey)
        {
            int count = 0;
            foreach (string itemId in _itemIds)
            {
                if (itemKey.HasItem(itemId))
                {
                    count++;
                }
            }

            return count == itemKey.Count;
        }
    }

    // 計算後的結果
    internal class AprioriRecords
    {
        public List<AprioriRecord> _records = new List<AprioriRecord>();
        public int Count { get { return _records.Count; } }

        internal void Add(AprioriRecord record)
        {
            _records.Add(record);
        }

        // https://stackoverflow.com/questions/7802822/all-possible-combinations-of-a-list-of-values
        // 取得組合後的 ItemKey
        public List<ItemKey> GetAllCombinationIds2()
        {
            var result = new SortedSet<ItemKey>(new ItemKeyComparar());

            for (int i = 0; i < _records.Count; i++)
            {
                for (int j = i + 1; j < _records.Count; j++)
                {
                    ItemKey key = GetKey(_records[i].ItemKey, _records[j].ItemKey);
                    if (key != null)
                    {
                        result.Add(key);
                    }
                }
            }

            return result.ToList();
        }

        private ItemKey GetKey(ItemKey itemKey1, ItemKey itemKey2)
        {
            SortedSet<string> itemKeys = new SortedSet<string>();
            foreach (string key in itemKey1.Ids)
            {
                itemKeys.Add(key);
            }

            foreach (string key in itemKey2.Ids)
            {
                itemKeys.Add(key);
            }
            return itemKeys.Count != itemKey1.Count + 1 ? null : new ItemKey(itemKeys);
        }
    }

    internal class AprioriRecord
    {
        public ItemKey ItemKey { get; private set; }
        public int Count { get; private set; }

        public AprioriRecord(ItemKey itemKey, int count)
        {
            ItemKey = itemKey;
            Count = count;
        }

        public override string ToString()
        {
            return $"{ItemKey.CombinationId}:{Count}";
        }
    }
}
