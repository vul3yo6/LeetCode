using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LeetCode.Problems
{
    /*
     * Implement FP-Growth Algorithm.
     * 
     * Apriori算法是一种先产生候选项集再检验是否频繁的“产生-测试”的方法。
     * 这种方法有种弊端：当数据集很大的时候，需要不断扫描数据集造成运行效率很低。
     * 而FP-Growth算法就很好地解决了这个问题。
     * 它的思路是把数据集中的事务映射到一棵FP-Tree上面，再根据这棵树找出频繁项集。
     * FP-Tree的构建过程只需要扫描两次数据集。
     * 
     * FP-Growth演算法是韓嘉煒等人提出的關聯分析演算法。該個演算法構建通過兩次資料掃描，
     * 將原始資料中的item壓縮到一個FP-tree（Frequent Pattern Tree，頻繁模式樹）上，
     * 接著通過FP-tree找出每個item的條件模式基，最終得到所有的頻繁項集。
     * 
     * FP-Growth 演算法優缺點
     * 優點：簡單易上手，部署起來也很方便。
     * 缺點：需要有較多的資料，且效果一般。
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
    public class FPGrowthAlgorithmProblem
    {
        private ShoppingRecords2 _dataset = new ShoppingRecords2();

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
            // Scan Data
            var itemKeys = _dataset.GetSortHeaderTable();
            var supDataset = _dataset.GetFilter(itemKeys);
            FPNode tree = CreateFPTree(supDataset);

            CalculateSupport(tree, minSupport);

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

        private void CalculateSupport(FPNode tree, double minSupport)
        {

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
                //List<ItemKey> itemKeys = _dataset.GetAllCombinationIds();
                //GetSupport(itemKeys, minSupport);

                // todo: 遞迴找 頻繁資料集的步驟未完成
                //var record = new AprioriRecord(itemKey, count);
                //_resultDict[itemKey.CombinationId] = record;
            }
            finally
            {
                _sw.Stop();
                _timeDict[nameof(CalculateSupport)] = _sw.Elapsed.TotalMilliseconds;
            }
        }

        private FPNode CreateFPTree(ShoppingRecords2 supDataset)
        {
            var root = new FPNode("root");
            foreach (ShoppingRecord2 record in supDataset.Data.Values)
            {
                root.Add(record.Items, 0);
            }

            return root;
        }

        internal class ShoppingRecords2
        {
            private Dictionary<string, ShoppingRecord2> _dict = new Dictionary<string, ShoppingRecord2>();
            public Dictionary<string, ShoppingRecord2> Data
            {
                get { return new Dictionary<string, ShoppingRecord2>(_dict);  }
            }

            public void Add(string tranId, string item)
            {
                if (_dict.ContainsKey(tranId) == false)
                {
                    _dict[tranId] = new ShoppingRecord2();
                }

                _dict[tranId].Add(item);
            }

            public void Clear()
            {
                _dict.Clear();
            }

            public Dictionary<string, int> GetSortHeaderTable()
            {
                var dict = new Dictionary<string, int>();
                foreach (ShoppingRecord2 record in _dict.Values)
                {
                    foreach (string item in record.Items)
                    {
                        if (dict.ContainsKey(item) == false)
                        {
                            dict[item] = 1;
                        }
                        else
                        {
                            dict[item]++;
                        }
                    }
                }

                return dict.OrderBy(x => x.Value)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
            }

            public ShoppingRecords2 GetFilter(Dictionary<string, int> filter)
            {
                var result = new ShoppingRecords2();
                foreach (var kvp in _dict)
                {
                    ShoppingRecord2 record = kvp.Value;
                    foreach (string item in record.Items)
                    {
                        if (filter.ContainsKey(item) == false)
                        {
                            continue;
                        }

                        // todo: need sort
                        result.Add(kvp.Key, item);
                    }
                }

                return result;
            }
        }

        internal class ShoppingRecord2
        {
            private List<string> _items = new List<string>();
            public List<string> Items
            {
                get { return new List<string>(_items); }
            }

            public void Add(string item)
            {
                _items.Add(item);
            }

            public override string ToString()
            {
                return $"[{string.Join(",", Items)}]";
            }
        }

        //internal class FPTree
        //{

        //}

        internal class FPNode
        {
            private Dictionary<string, FPNode> _childs;

            public string Item { get; private set; }
            public int Count { get; private set; }

            public FPNode(string item)
            {
                Item = item;
            }

            public void Add(List<string> items, int index)
            {
                if (index >= items.Count)
                {
                    return;
                }

                string item = items[index];
                if (Item == item)
                {
                    Count++;
                    Add(items, ++index);
                    return;
                }

                if (_childs == null)
                {
                    _childs = new Dictionary<string, FPNode>();
                }

                if (_childs.ContainsKey(item) == false)
                {
                    _childs[item] = new FPNode(item);
                }

                _childs[item].Add(items, index);
            }

            public override string ToString()
            {
                return $"[{Item}:{Count}]";
            }

            // 產生頻繁序列結果
            public bool Contains(string item)
            {
                if (Item == item)
                {
                    return true;
                }

                if (_childs != null)
                {
                    foreach (FPNode child in _childs.Values)
                    {
                        if (child.Contains(item))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }
    }
}
