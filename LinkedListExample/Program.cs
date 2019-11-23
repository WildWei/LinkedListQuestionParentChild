using System;
using System.Collections.Generic;

namespace LinkedListExample
{
    class Program
    {
        const string exampleStr = "AA-,BB-,AA-AC,BB-BC,BB-BD,BD-CC";

        private static Dictionary<string, string> relationShipDic = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            string value = "CC";

            var result = searchRoot(value);

            Console.WriteLine(result);
        }

        /// <summary>
        /// 查詢Root Parent
        /// </summary>
        /// Example
        /// value = "BB-,BB-BD,BD-CC"
        /// relationArray = { "BB-","BB-BD","BD-CC" }
        /// 
        /// 第一筆 => dic("BB","");
        /// 第二筆 => dic("BB","BD");
        /// 第二筆 => dic("BD","CC");
        /// 實際上 => BB -> BD -> CC 這整個是串連再一起的
        /// 
        /// 當輸入值是 "CC"
        /// dic["CC"] = "BD"
        /// dic["BD"] = "BB"
        /// dic["BB"] = null => 由此可知 "BB" is root Parent
        /// 
        /// <param name="value"></param>
        /// <returns></returns>
        private static string searchRoot(string value)
        {

            var relationShipArray = exampleStr.Split(',');

            for (int i = 0; i < relationShipArray.Length; i++)
            {
                var relationShip = relationShipArray[i].Split('-');
                
                if (string.IsNullOrEmpty(relationShip[1]))
                {
                    relationShipDic.Add(relationShip[0], string.Empty);
                    continue;
                }
                relationShipDic.Add(relationShip[1], relationShip[0]);
            }

            string answer = SearchAnswer(value);

            return answer;
        }

        /// <summary>
        /// 查詢目前已建立的關係清單去查詢父親是誰(遞回的方式查詢)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string SearchAnswer(string value)
        {
            var parent = relationShipDic[value];

            if (string.IsNullOrEmpty(parent))
            {
                return value;
            }

            return SearchAnswer(parent);
        }
    }
}
