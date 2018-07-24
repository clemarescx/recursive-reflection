using System;
using System.Collections.Generic;
using System.Reflection;

namespace RecursiveReflectionTest
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var k = new Kernel("DefaultBehaviour")
            {
                States = new List<State>
                {
                    new State("Walk"),
                    new State("Pursue"),
                    new State("Evade")
                }
            };

            k.States?.ForEach(s => s.Transitions = new List<Transition>
            {
                new Transition("Enter"),
                new Transition("Exit")
            });


            void CloneRecurse(ResourceData res)
            {
                res?.CreateResourceId();
                var fields = res?.GetType()
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                foreach (var field in fields)
                {
                    Console.WriteLine($"field: {field.Name}");
                    var list = new List<ResourceData>();
                    var t = field.FieldType;
                    if (IsSubclassOfRawGeneric(typeof(List<>), t))
                    {
                        Console.WriteLine("        We have a collection!");

                        var listType = t.GetGenericArguments()[0];
                        if (listType.IsSubclassOf(typeof(ResourceData)))
                        {
                            Console.WriteLine("A collection of ResourceData!");
                            dynamic l = field.GetValue(res);
                            list.AddRange(l);
                        }
                    }

                    else if (t.IsSubclassOf(typeof(ResourceData)))
                    {
                        Console.WriteLine("Only a single ResourceData...");
                        list.Add(field.GetValue(res) as ResourceData);
                    }

                    foreach (var rd in list)
                    {
                        Console.WriteLine($"class: {res.GetType().Name} - field:{field.Name}");
                        CloneRecurse(rd);
                    }
                }
            }

            Console.WriteLine("Start recursion...");
            CloneRecurse(k);
            Console.ReadKey();
        }

        private static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur) return true;
                toCheck = toCheck.BaseType;
            }

            return false;
        }
    }
}