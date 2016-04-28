using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace myNamespace = new CodeNamespace("HelloWorld");
            myNamespace.Imports.Add(new CodeNamespaceImport("System"));
            CodeTypeDeclaration myClass = new CodeTypeDeclaration("MyClass");
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
            new CodeTypeReferenceExpression("Console"),
            "WriteLine", new CodePrimitiveExpression("Hello World!"));
            compileUnit.Namespaces.Add(myNamespace);
            myNamespace.Types.Add(myClass);
            myClass.Members.Add(start);
            start.Statements.Add(cs1);


            CSharpCodeProvider provider = new CSharpCodeProvider();
            using (StreamWriter sw = new StreamWriter("HelloWorld.cs", false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, " ");
                provider.GenerateCodeFromCompileUnit(compileUnit, tw,
                new CodeGeneratorOptions());
                tw.Close();
            }


            //            Expression trees
            //When using lambdas, you will come across expression trees, which are representations of code
            //in a tree-like data structure. Just as the CodeDom can represent code in a tree-like manner,
            //Expression trees can do the same; they can also be used to generate code.

            BlockExpression blockExpr = Expression.Block(
            Expression.Call(
            null,
            typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
            Expression.Constant("Hello ")
            ),
            Expression.Call(
            null,
            typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
            Expression.Constant("World!")
            )
            );
            Expression.Lambda<Action>(blockExpr).Compile()();
        }
    }
}
