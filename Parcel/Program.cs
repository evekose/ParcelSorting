using System;
using System.Collections.Generic;

namespace Parcel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParcelLineFitConroller(BoxSizes);
        }
        public static bool ParcelLineFitConroller(List<BoxSize> boxSizes)
        {
            //väikese algustähega kuna on lokaalne muutuja 
            bool parcelFits = false;

            foreach (BoxSize box in boxSizes)
            {
                Console.WriteLine("New sorting line starts");

                var boxLenthInHalf = box.Length / 2;
                var halfBoxDiagonalNotSqrt = (boxLenthInHalf * boxLenthInHalf) + (box.Width * box.Width);
                var halfParcelDiagonal = Math.Sqrt(halfBoxDiagonalNotSqrt);

                foreach (SortingLineParam sortingLine in box.SortingLineParams)
                {

                    float lineWidth = 0;
                    var sortingLineNotSqrt = (sortingLine.LineWidth * sortingLine.LineWidth) + (lineWidth * lineWidth);
                    var cornerDiagonal = Math.Sqrt(sortingLineNotSqrt);

                    //if(sortingLine.LineWidth >= prop && prop <= prop)
                    //1
                    if(sortingLine.LineWidth >= halfParcelDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    }
                    //2
                    else if (sortingLine.LineWidth>= halfParcelDiagonal && lineWidth >= halfParcelDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    }
                    //3
                    else if (box.Width <= halfParcelDiagonal && lineWidth >= halfParcelDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    }
                    //4
                    else if (box.Width <= halfParcelDiagonal)
                    {
                        Console.WriteLine("Sorting line width is {0} and it fits", sortingLine.LineWidth);
                    }
                    //5
                    else if (sortingLine.LineWidth <= halfParcelDiagonal && sortingLine.LineWidth >= cornerDiagonal)
                    {
                        parcelFits = sortingLine.LineWidth <= halfParcelDiagonal && sortingLine.LineWidth >= cornerDiagonal;
                        var result = parcelFits
                        ? "Sorting line width is " + sortingLine.LineWidth + " and it fits" : 
                            "It doesn't fit to the sorting line and needs to be wider";

                        Console.WriteLine(result);
                    }
                    else
                    {
                        Console.WriteLine("It doesn't fit to the sorting line and needs to be wider.");
                    }
                }
            }

            return parcelFits;
        }
        
        public static readonly List<BoxSize> BoxSizes = new List<BoxSize>
    {
        new BoxSize
        {
            Length = 120,
            Width = 60,
            SortingLineParams = new List<SortingLineParam>
            {
                new SortingLineParam
                {
                    LineWidth = 100
                },
                new SortingLineParam
                {
                    LineWidth= 75
                }
            }
        },
        new BoxSize
        {
            Length = 100,
            Width = 35,
            SortingLineParams = new List<SortingLineParam>
            {
                new SortingLineParam
                {
                    LineWidth = 75
                },
                new SortingLineParam
                {
                    LineWidth= 50
                },
                new SortingLineParam
                {
                    LineWidth = 80
                },
new SortingLineParam
                {
                    LineWidth= 100
                },
                new SortingLineParam
                {
                    LineWidth= 37
                }
            }
        },
new BoxSize
        {
            Length = 70,
            Width = 50,
            SortingLineParams = new List<SortingLineParam>
            {
                new SortingLineParam
                {
                    LineWidth = 60
                },
                new SortingLineParam
                {
                    LineWidth= 60
                },
new SortingLineParam
                {
                    LineWidth = 55
                },
                new SortingLineParam
                {
                    LineWidth= 90
                }
            }
        }
    };
    }



    public class BoxSize
    {
        public int Length { get; set; }
        public int Width { get; set; }

        public List<SortingLineParam> SortingLineParams { get; set; } = new List<SortingLineParam>();
    }

    public class SortingLineParam
    {
        public int LineWidth { get; set; }
    }
}