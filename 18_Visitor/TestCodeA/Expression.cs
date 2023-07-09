using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Threading;




namespace TestCode
{
    public interface IVisitor { }
    public interface IVisitor<TVisitable>
    {
        void Visit(TVisitable obj);
    }


    public abstract class Expression
    {
        public abstract void Accept(IVisitor visitor);
    }

    public class DoubleExpression :Expression
    {
        public double Value;
        public DoubleExpression(double value)
        {
            this.Value = value;
        }

        public override void Accept(IVisitor visitor)
        {
            if (visitor is IVisitor<DoubleExpression> typed)
                typed.Visit(this);
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
        public override void Accept(IVisitor visitor)
        {
            if (visitor is IVisitor<AdditionExpression> typed)
                typed.Visit(this);
        }
    }

    // 當我們設計Visitor design pattern, 我們就可以在不改變欲存取物件的情況下, 建立新的operation, 並且該operation 可以存取component 階層中所有的內容
    public class ExpressionPrinter : IVisitor,IVisitor<AdditionExpression>,IVisitor<Expression>,IVisitor<DoubleExpression>
    {
        StringBuilder sb = new StringBuilder();
        public void Visit(Expression e) { }
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
}
