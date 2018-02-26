using CIS.CodeDom.Csharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS.CodeDom.DNA.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //  создаем программоида
            Oid a = new Oid();

            //  в начале мы будем анализировать (функциональный анализ ДНК) программы 
            //  в этом фрагменте, мы получаем имя пространства имен скомпилированного блока
            var a1 = a.DNA;
            Console.WriteLine(a1.UnitMembers.Members[0].GetType().Name);
            Console.WriteLine((((CsNamespace)a1.UnitMembers.Members[0]).NamespaceName).Main);

            //  учитывая, что у нас есть полный доступ к AST его модификация кода слишком проста:
            a1.UnitMembers.Members.Add(new CsNamespace(new CsIdentifier("Users")));
            //  давайте посмотрим, как это выглядит в исходном коде:
            Console.WriteLine(((ICsCode)(((IDNA)a).DNA)).GenerateSourceCode());
            //  видно, что пространство имен с указанным именем будет добавлено в структуре исходного кода
            //  таким образом, завершается (функциональный модификация программы ДНК)

            //  Теперь, когда мы нашли каким именно способом можно модифицировать ДНК программы,
            //  то как, внедрить модифицированную ДНК внутрь самой программы? 
            //  получить исходный код ДНК (в виде строчного выражения), и затем превратить этот код в AST дерево программных объектов 
            //  затем надо выполнить следующую строку она возвращает кортеж из двух строк, первая это идентификационный маркер объекта (строку), 
            //  второй исходный код объектов CodeDom (в данном случае, CsCompileUnit), который представляет AST дерево модифицированного кода в виде объектов CodeDom, т.е. первообразную кода
            var _dn = ((ICsCodeSelf)(((IDNA)a).DNA)).GenerateSelfCode();
            Console.WriteLine(_dn.Item1);
            Console.WriteLine("======================================");
            //  теперь посмотрим, что мы получили 
            string self = _dn.Item2;
            Console.WriteLine(self);

            Console.ReadLine();
        }
    }
}