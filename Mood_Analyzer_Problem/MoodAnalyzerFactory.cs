using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Mood_Analyzer_Problem
{
    public class MoodAnalyzerFactory
    {/* UC4:- create default Constructor - Use Reflection to Create MoodAnalyser with default Constructor
              - Create MoodAnalyserFactory and specify static method to create MoodAnalyser Objec
              MoodAnalyserObject to create MoodAnalyser object 
        */
        public object CreateMoodAnalyzerObject(string className, string constructor)
        {
            //MoodAnalyzerProblem.MoodAnalyzer
            string pattern = @"." + constructor + "$";
            Match result = Regex.Match(className, pattern); 

            if (result.Success) 
            {
                try
                {    //constructor and classname both are matching

                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyzerType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyzerType); //Activator class
                    return res;
                }
                catch (NullReferenceException)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND, "class not found");//class name not maching that time we run
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "constructor not found");//Constructor name not maching that time we run
            }
        }
    }
}
