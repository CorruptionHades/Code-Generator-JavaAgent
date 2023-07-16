﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program {

    public static List<MappingClass> classList = new List<MappingClass>();

    static void Main() {
        string inputPath = @"mappings/client.txt";

        string[] lines = File.ReadAllLines(inputPath);

        MappingClass currentClass = null;

        foreach (string fileLine in lines) {
            string line = fileLine.Replace("    ", "");
            if (line.EndsWith(":")) {
                string[] classParts = line.Split(" -> ");

                string unobfuscatedName = classParts[0].Trim().Replace(" ", "_");
                string obfuscatedName = classParts[1].Trim().Replace(":", "").Replace(" ", "");

                MappingClass mappingClass = new MappingClass(unobfuscatedName, obfuscatedName);
                currentClass = mappingClass;
                classList.Add(mappingClass);
            }
            else if (line.Contains("->")) {
                // Method
                if(line.Contains(":")) {
                    string[] methodParts = line.Split(" -> ");
                    string obfuscatedName = methodParts[1].Trim();

                    string[] methodParts2 = line.Split(" ");
                    string methodName = methodParts2[1].Trim();
                    string types = methodParts2[0].Trim();

                    if(currentClass == null) {
                        Console.WriteLine("Error: currentClass is null!");
                        return;
                    }

                    if(currentClass.Methods == null) {
                        Console.WriteLine("Error: currentClass.Methods is null!");
                        return;
                    }

                    string[] types2 = types.Split(":");
                    string returnType = types2[2].Trim();

                    if(!currentClass.Methods.ContainsKey(methodName)) {
                        currentClass.Methods[methodName] = obfuscatedName + ":" + returnType;
                    }
                  
                }
                // Field
                else {
                    string[] fieldParts = line.Split(" -> ");
                    string obfuscatedName = fieldParts[1].Trim();

                    string[] fieldParts2 = line.Split(" ");
                    string fieldName = fieldParts2[1].Trim();
                    string types = fieldParts2[0].Trim();
                    string fieldType = types.Trim();

                    if (currentClass == null)  {
                        Console.WriteLine("Error: currentClass is null!");
                        return;
                    }

                    if (currentClass.Fields == null) {
                        Console.WriteLine("Error: currentClass.Fields is null!");
                        return;
                    }

                    if (!currentClass.Fields.ContainsKey(fieldName)) {
                        currentClass.Fields[fieldName] = obfuscatedName + ":" + fieldType;
                    }
                }  
            }
        }

        Console.WriteLine("Parsing complete!");
        Console.WriteLine("------------------------------");

        Console.WriteLine("Enter class to generate: ");
        string classToMake = Console.ReadLine();
        MappingClass mappingClass1 = getByName(classToMake);

        if (mappingClass1 == null) {
            Console.WriteLine("Error: class " + classToMake + " not found!");
            return;
        }

        Console.WriteLine("Class: " + mappingClass1.Name + " -> " + mappingClass1.ObfuscatedName);

        string classCode = ClassGenerator.generate(mappingClass1);

        // Write to file

        // Write it to file and make packages as folders
        string[] packageParts = mappingClass1.Name.Split(".");
        string packagePath = "out/";
        for (int i = 0; i < packageParts.Length - 1; i++) {
            packagePath += packageParts[i] + "/";
        }

        // Create the directories
        Directory.CreateDirectory(packagePath);
        File.WriteAllText(packagePath + packageParts[packageParts.Length - 1] + ".java", classCode);
    }


    public static MappingClass getByName(string name) {
        foreach (MappingClass mappingClass in classList) {
            if (mappingClass.Name == name || mappingClass.ObfuscatedName == name) {
                return mappingClass;
            }
        }

        return null;
    }
}