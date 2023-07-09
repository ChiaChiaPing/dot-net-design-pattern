using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Threading;




namespace TestCode
{
    //import specific type
    //using DictType = Dictionary<Type, Action<Expression, StringBuilder>>;

    public interface IExpressionVisitor
    {
        void Visit(DoubleExpression de);
        void Visit(AdditionExpression ae);
    }


    public abstract class Expression
    {
        public abstract void Accept(IExpressionVisitor visitor);
    }

    public class DoubleExpression :Expression
    {
        public double Value;
        public DoubleExpression(double value)
        {
            this.Value = value;
        }

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this); // visitor 去拜訪某個型別class 裡面的內容
        }


    }

    public class AdditionExpression : Expression
    {
        public Expression left, right;
        public AdditionExpression(Expression l,Expression r)
        {
            left = l ?? throw new ArgumentNullException(nameof(left));
            right = r ?? throw new ArgumentNullException(nameof(right));
        }
        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // 當我們設計Visitor design pattern, 我們就可以在不改變欲存取物件的情況下, 建立新的operation, 並且該operation 可以存取component 階層中所有的內容
    public class ExpressionPrinter : IExpressionVisitor
    {
        StringBuilder sb = new StringBuilder();
        public void Visit(DoubleExpression de)
        {
            sb.Append(de.Value);
        }
        public void Visit(AdditionExpression ae)
        {
            sb.Append("(");
            ae.left.Accept(this);
            sb.Append("+");
            ae.right.Accept(this);
            sb.Append(")");
        }
        public override string ToString()
        {
            return sb.ToString();
        }
    }

    public class ExpressionCalc : IExpressionVisitor
    {
        public double Result;

        public void Visit(DoubleExpression de)
        {
            Result = de.Value;
        }

        public void Visit(AdditionExpression ae)
        {
            ae.left.Accept(this);
            var a = Result; // 左半邊的總和
            ae.right.Accept(this);
            var b = Result;// 右半邊寵和
            Result = a + b;
        }
    }
    // Dynamic Visitor
    public class ExpressionPrinter1
    {
        public void Print(AdditionExpression ae,StringBuilder sb)
        {
            sb.Append("(");
            Print((dynamic)ae.left, sb); // 加入dynamic 的原因基本上就是因為在呼叫Print 時 帶入的參數ae.left(ae.right) 不確定會是什麼型別，所以家dynamic 代表該變數是可以變動型別的。
            sb.Append("+");
            Print((dynamic)ae.right, sb);
            sb.Append(")");
        }
        public void Print(DoubleExpression de,StringBuilder sb)
        {
            sb.Append(de.Value);
        }
    }



    /*
    public static class ExpressionPrinter
    {
        private static DictType dt = new DictType
        {
            [typeof(DoubleExpression)] = (e, sb) =>
            {
                var de = (DoubleExpression)e;
                sb.Append(de.Value);
            },
            [typeof(AdditionExpression)] = (e, sb) =>
            {
                var ae = (AdditionExpression)e;
                sb.Append("(");
                Print(ae.left, sb);
                sb.Append("+");
                Print(ae.right, sb);
                sb.Append(")");
            }
        };

        public static void Print(Expression e,StringBuilder sb)
        {
            dt[e.GetType()](e, sb);
        }

    }*/
}
