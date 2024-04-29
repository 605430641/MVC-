using IocDemo.InterFace;

namespace IocDemo.Service
{
    public class Class1
    {

    }

    public class TestServiceA: ITestServiceA
    {
      public TestServiceA() { Console.WriteLine($"{this.GetType().Name}被构造"); }

        public void Show()
        {
            Console.WriteLine($"{this.GetType().Name}服务仓储实现类A");
        }
    }
    public class TestServiceB : ITestServiceB
    {
        public TestServiceB() { Console.WriteLine($"{this.GetType().Name}被构造"); }

        public void Show()
        {
            Console.WriteLine($"{this.GetType().Name}服务仓储实现类B");
        }
    }
    public class TestServiceC : ITestServiceC
    {
        public TestServiceC() { Console.WriteLine($"{this.GetType().Name}被构造"); }

        public void Show()
        {
            Console.WriteLine($"{this.GetType().Name}服务仓储实现类C");
        }
    }
    public class TestServiceD : ITestServiceD
    {
        public TestServiceD() { Console.WriteLine($"{this.GetType().Name}被构造"); }

        public void Show()
        {
            Console.WriteLine($"{this.GetType().Name}服务仓储实现类D");
        }
    }
    public class TestServiceE : ITestServiceE
    {
        public TestServiceE() { Console.WriteLine($"{this.GetType().Name}被构造"); }

        public void Show()
        {
            Console.WriteLine($"{this.GetType().Name}服务仓储实现类E");
        }
    }



}