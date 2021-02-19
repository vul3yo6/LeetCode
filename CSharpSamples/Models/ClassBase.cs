using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpSamples.Models
{
    /*
     * 繼承的執行順序
     * 1. 子類別的欄位
     * 2. 父類別的欄位
     * 3. 父類別的建構式
     * 4. 子類別的建構式
     */
    abstract class ClassBase
    {
        private string _childField = "AAAA";

        public ClassBase()
        {
            Console.WriteLine("ClassBase()");
        }
        public ClassBase(string msg)
        {
            Console.WriteLine("ClassBase(string msg)");
        }

        public void Print()
        {
            Console.WriteLine("ClassBase Print");
        }

        public virtual void Print2()
        {
            Console.WriteLine("ClassBase Print2");
        }
    }

    class ClassChild : ClassBase
    {
        private string _childField = "BBBB";

        public ClassChild() : base("CCCCC")
        {
            Console.WriteLine("ClassChild()");
        }

        // 未使用 override 關鍵字後, 則根據指標決定跑「父類別的方法」or「子類別的方法」
        //public void Print()
        public new void Print()
        {
            Console.WriteLine("ClassChild Print");
        }

        // 使用 override 關鍵字後, 一律跑子類別的方法
        public override void Print2()
        {
            Console.WriteLine("ClassChild Print2");
        }
    }
}
