using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using Microsoft.VisualBasic;
namespace c_larp;

    class Program
   {     
        static void  Main (string[] args)
        {
          List<string> names = new List<string>(); // создал динамический массив 
            names.Add("ALEX");// 0 
            names.Add("SANYA"); // names.Add("") - заполяет данные в динамический массив
            names.Add("ARTEM");
            names.Add("bear");
            names.Add("pill");
            names.Add("FLEX");
            names.Add("lox");
            names.Add("candy");
            names.Add("milk");
            names.Add("tank");
            names.Add("zero");//10

            for (int i = 0; i < names.Count; i++)
            {
                for (int p = 0; p < names.Count - 1 - i; p++) // страшно
                {
                    if ((names[p]).CompareTo(names[p+1]) <0)
                    {
                        string temp = names[p];
                        names[p] = names[p+1];
                        names[p+1] = temp;
                    }
                }
            }
            foreach (string name in names)
            {
                Console.WriteLine($" {name}");
            }
        }
   }

   
             
