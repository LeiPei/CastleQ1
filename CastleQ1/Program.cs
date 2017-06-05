using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] {10, 10, 10, 15, 15, 15, 13,13,18,18,18,17,17,20};
            var numCastlesToBuild = NumOfCastles(array);
            Console.WriteLine("we need to build " + numCastlesToBuild + " castles");
            Console.ReadKey();
        }

        /// <summary>
        /// This function will calculate how many castles will be built. 
        /// </summary>
        /// <param name="array">the array of a stretch of land</param>
        /// <returns>how many castles will be built</returns>
        static int NumOfCastles(int[] array)
        {
            int numCastlesToBuild = 0;

            // check if the array is empty
            if(array!=null && array.Length >= 3)
            {
                int pre = 0;
                int cur = 1;
                int next = 2;
                while(next < array.Length)
                {
                    if (array[pre] > array[cur]) // might be valley
                    {
                        if(array[next] > array[cur])
                        {
                            numCastlesToBuild++;
                            next++;
                            cur = next - 1;
                            pre = cur - 1;
                        } else if(array[next] == array[cur])
                        {
                            next++;
                        } else
                        {
                            next++;
                            cur = next - 1;
                            pre = cur - 1;
                        }
                    }
                    else if (array[pre] < array[cur]) // might be peak
                    { 
                        if(array[next] < array[cur])
                        {
                            numCastlesToBuild++;
                            next++;
                            cur = next - 1;
                            pre = cur - 1;
                        } else if(array[next] == array[cur])
                        {
                            next++;
                        } else
                        {
                            next++;
                            cur = next - 1;
                            pre = cur - 1;
                        }

                    } else
                    {
                        next++;
                        cur = next - 1;
                        pre = cur - 1;
                    }     
                }
            } else if(array != null)
            {
                numCastlesToBuild = 1; // always build one castle if the array has one or two members
            }

            if(array != null && array.Length >= 3 && numCastlesToBuild == 0)
            {
                // the array has been sorted, always build one castle
                numCastlesToBuild = 1;
            }
            return numCastlesToBuild;
        }

    }
}
