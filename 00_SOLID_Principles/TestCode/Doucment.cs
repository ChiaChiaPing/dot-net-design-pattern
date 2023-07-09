using System;
namespace TestCode
{

    public interface IMachine
    {
        // 這就是一種不好的寫法，萬一有機器他只能print，但因為實作 IMachine 所以他不得不實作Scan 可是又完全不會用到，違反ISP
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }



    public class Document
    {

    }

    public interface IPrinter
    {
        void Print(Document d);
    }
    public interface IScanner
    {
        void Scan(Document d);

    }
    public interface MultiFunctionality : IPrinter, IScanner
    {
        // why 不用實作，因為自己本身也是介面，無需實作
    }

    public class OldPrinter : MultiFunctionality
    {

        private IPrinter printer;
        private IScanner scanner;

        public OldPrinter(IPrinter ip, IScanner Is )
        {
            this.printer = ip ?? throw new Exception();
            this.scanner = Is ?? throw new Exception();
        }

        // 上者是指派完實作介面之類別的物件後，可以利用該物件呼叫實作方法來實踐 oldprinter行為
        

        // delegate 代表的是說，介面的方法由實作該介面的類別來定義，並且實踐該行為
        public void Print(Document d)
        {   

        }

        public void Scan(Document d)
        {

        }
    }






}
